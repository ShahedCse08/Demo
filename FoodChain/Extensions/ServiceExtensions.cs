using AspNetCoreRateLimit;
using Contracts.Interfaces.Authentication;
using Contracts.Interfaces.DataShaping;
using Contracts.Interfaces.Logger;
using Contracts.Interfaces.Repository;
using DinkToPdf;
using DinkToPdf.Contracts;
using EmailService.Interfaces;
using EmailService.Models;
using EmailService.Services;
using Entities;
using Entities.Context;
using Entities.DataTransferObjects.Retrieve;
using Entities.Models;
using LoggerService.Services.logger;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.DataShaping;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.ActionFilter;
using Demo.Controllers;
using Demo.Formatter;
using Demo.Utility;

namespace Demo.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options => { });
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options => { options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddScoped<ILoggerManager, LoggerManager>();
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("Demo")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
        builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));

        public static void ConfigureCustomActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateCompanyExistsAttribute>();
            services.AddScoped<ValidateEmployeeForCompanyExistsAttribute>();
        }

        

        public static void ConfigureAcceptHeaderMediaTypeActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidateMediaTypeAttribute>();
        }

        public static void ConfigureHATEOASLink(this IServiceCollection services)
        {
            services.AddScoped<EmployeeLinks>();
        }

        public static void ConfigureDataShaperService(this IServiceCollection services)
        {
            services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();

        }

        public static void AddCustomMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters
                      .OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

                if (newtonsoftJsonOutputFormatter != null)
                {
                    newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.codemaze.hateoas+json");
                    newtonsoftJsonOutputFormatter
                    .SupportedMediaTypes.Add("application/vnd.codemaze.apiroot+json");

                }

                var xmlOutputFormatter = config.OutputFormatters
                      .OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

                if (xmlOutputFormatter != null)
                {
                    xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.codemaze.hateoas+xml");
                    xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.codemaze.apiroot+xml");
                }
            });
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
                opt.Conventions.Controller<CompaniesController>().HasApiVersion(new ApiVersion(1, 0));
                opt.Conventions.Controller<CompaniesV2Controller>().HasDeprecatedApiVersion(new ApiVersion(2, 0));

            });

        }

        public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();
        public static void ConfigureHttpCacheHeaders(this IServiceCollection services) => services.AddHttpCacheHeaders(
 (expirationOpt) =>
 {
     expirationOpt.MaxAge = 65;
     expirationOpt.CacheLocation = CacheLocation.Private;
 },
 (validationOpt) =>
 {
     validationOpt.MustRevalidate = true;
 });

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit= 30,
                    Period = "5m"
                }
            };

            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });

            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }

        public static void ConfigureEmailService(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole),builder.Services);
            builder.AddSignInManager().AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders().AddRoles<IdentityRole>();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            var secretKey = "DukePlanetSecretKey"; 
            //Environment.GetEnvironmentVariable("SECRET");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new
    SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

        public static void ConfigureAuthenticationService(this IServiceCollection services) => services.AddScoped<IAuthenticationManager, AuthenticationManager>();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Umme Kulsum Demo API",
                    //Version = "v1",
                  //  Description = "",
                  //  TermsOfService = new Uri("https://example.com/terms"),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Admin",
                    //    Email = "admin@dukeplanet.com",
                    //    Url = new Uri("http://www.dukeplanet.com/"),
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "API LICX",
                    //    Url = new Uri("https://example.com/license"),
                    //}

                });
                s.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Umme Kulsum Demo API",
                    Version = "v2"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });


             s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                          {
              {
                        new OpenApiSecurityScheme {
                                Reference = new OpenApiReference
                              { 
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                               },
                        Name = "Bearer", },
                      new List<string>() }
                });

            });



        }


        public static void ConfigureMultiPartBodyLength(this IServiceCollection services) {
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }


        public static void ConfigurePDFToolsConverter(this IServiceCollection services) {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        }


}
}

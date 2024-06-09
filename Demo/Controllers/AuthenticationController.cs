using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces.Authentication;
using Contracts.Interfaces.Logger;
using EmailService.Interfaces;
using EmailService.Models;
using Entities.DataTransferObjects.Auth;
using Entities.DataTransferObjects.Role;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OtpNet;
using Demo.ActionFilter;


namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        private readonly IAuthenticationManager _authManager;
        private readonly IMemoryCache _memoryCache;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<User> _signInManager;
        public static readonly string DefaultProvider;

        public AuthenticationController(ILoggerManager logger, IMapper mapper,
       UserManager<User> userManager,  IAuthenticationManager authManager, IMemoryCache memoryCache , IEmailSender emailSender, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)

        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            _memoryCache = memoryCache;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        //[HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        //{
        //    if (userForRegistration == null || !ModelState.IsValid)
        //        return BadRequest();

        //    var user = _mapper.Map<User>(userForRegistration);
        //    var result = await _userManager.CreateAsync(user, userForRegistration.Password);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.TryAddModelError(error.Code, error.Description);
                    
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
        //    return StatusCode(201);
        //}


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }


        [HttpPost("uploadProfilePicture"), DisableRequestSizeLimit]
        public IActionResult UploadProfilePicture()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
            return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() ,  });
         }


        //[HttpPost("User"), Authorize]
        [HttpGet("User")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetUserInfo([FromQuery] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }
            var userInfo = await _userManager.FindByNameAsync(user.UserName);
            var roles = await _userManager.GetRolesAsync(userInfo); 
            var userDto = _mapper.Map<UserDto>(userInfo);
            userDto.Roles = roles;
            return Ok(userDto);
        }

        [HttpGet("Roles"), Authorize]
        public  IActionResult GetRoles()
        {
            var roleInfo =  _roleManager.Roles;
            var roles = _mapper.Map<IEnumerable<RoleDto>>(roleInfo);
            return Ok(roles);
        }

        [HttpGet("Users"), Authorize]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users;
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("RolesByUser")]
        public async Task<IActionResult> GetRolesByUser(string userId)   // automapper syntax missing
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarn($"{nameof(GetRolesByUser)}:User Not Found");
                return Unauthorized("User Not Found");
            }

            var roles = _roleManager.Roles;
            var roleDto = new List<RoleForUserDto>();
            foreach (var role in roles) {

                var roleForUserDto = new RoleForUserDto
                {
                    Id = role.Id,
                    Name = role.Name,
            };
                var result = await _userManager.IsInRoleAsync(user, role.Name);
                roleForUserDto.IsSelected = result;

                roleDto.Add(roleForUserDto);
            }
            return Ok(roleDto);
        }


        [HttpPut("UpdateRole/{userId}")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> UpdateRole([FromBody] IEnumerable<RoleManipulatorDto>   roleManipulatorDto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                _logger.LogWarn($"{nameof(UpdateUser)}: User Not Found");
                return NotFound("User Not Found");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded) {
                _logger.LogWarn($"{nameof(UpdateRole)}: Faild to remove user role");
                return NotFound("Faild to remove user roles");
            }

            result = await _userManager.AddToRolesAsync(user, roleManipulatorDto.Where(x=>x.IsSelected).Select(y=>y.Name));

            if (!result.Succeeded)
            {
                _logger.LogWarn($"{nameof(UpdateRole)}: Faild to add user role");
                return NotFound("Faild to remove user roles");
            }

            return Ok("User Roles Updated");

        }

        [HttpPut("UpdateUser/{id}")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> UpdateUser([FromBody] UserForManipulationDto userForManipulationDto, string id)
        {
            var existUser = await _userManager.FindByIdAsync(id);

            if (existUser == null)
            {
                _logger.LogWarn($"{nameof(UpdateUser)}: User Not Found");
                return NotFound();
            }

            _mapper.Map(userForManipulationDto, existUser);
            var result = await _userManager.UpdateAsync(existUser);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                }
                return BadRequest(ModelState);
            }
            //  await _userManager.AddToRolesAsync(user, userForManipulationDto.Roles);
            return NoContent();

        }

        //[HttpPost("UpdateUser")]

        //[ServiceFilter(typeof(ValidationFilterAttribute))]

        //public async Task<IActionResult> UpdateUser([FromBody] UserForManipulationDto userForManipulationDto)
        //{
        //    var existUser = _userManager.FindByIdAsync(userForManipulationDto.Id);

        //    if (existUser == null) { 
        //        _logger.LogWarn($"{nameof(UpdateUser)}: User Not Found");
        //        return NotFound();
        //    }

        //    var user = _mapper.Map<User>(userForManipulationDto);


        //    var result = await _userManager.UpdateAsync(user);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.TryAddModelError(error.Code, error.Description);

        //        }
        //        return BadRequest(ModelState);
        //    }
        //  //  await _userManager.AddToRolesAsync(user, userForManipulationDto.Roles);
        //    return NoContent();

        //}



        [HttpPost("forgetPassword")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordModel)
        {

           
          //  var secretKey = "Duke";
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user != null)
            {
               //var  provider = await _userManager.GetValidTwoFactorProvidersAsync(user);

                // token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var totp = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");//new Totp(Encoding.UTF8.GetBytes(secretKey), totpSize: 6);
                var message = new Message(new string[] { "" + forgotPasswordModel.Email }, new string[] {}, "Reset Password OTP", "Your OTP is : "+ totp);
                 _emailSender.SendEmail(message);
            }

           return Ok();
        }


        [HttpPost("otpvalidator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> OtpValidator([FromBody] OtpValidatorDto otpValidator)
        {
            var user = await _userManager.FindByEmailAsync(otpValidator.Email);
        
            if (user == null)
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();

            }
            var result = await _userManager.VerifyTwoFactorTokenAsync(user, "Email", otpValidator.TwoFactorCode);

            if (result)
            {
                return Ok(new { Token = await _userManager.GeneratePasswordResetTokenAsync(user) });
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return Unauthorized();
            }
        }



        [HttpPost("resetpassword")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);

            // var result = await _signInManager.TwoFactorSignInAsync("Email", otpValidator.TwoFactorCode, otpValidator.RememberUser, rememberClient: false);

            if (user == null)
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();

            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.ResetToken, resetPasswordDto.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return Unauthorized();
            }
        }


    }
}

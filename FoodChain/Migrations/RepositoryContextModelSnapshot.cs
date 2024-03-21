﻿// <auto-generated />
using System;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            Country = "USA",
                            Name = "IT_Solutions Ltd"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Address = "312 Forest Avenue, BF 923",
                            Country = "USA",
                            Name = "Admin_Solutions Ltd"
                        });
                });

            modelBuilder.Entity("Entities.Models.Email.EmailContent", b =>
                {
                    b.Property<int>("EmailContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bcc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailContentId");

                    b.ToTable("EmailContent");
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Age = 26,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Sam Raiden",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Age = 30,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Jana McLeaf",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Age = 35,
                            CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Kane Miller",
                            Position = "Administrator"
                        });
                });

            modelBuilder.Entity("Entities.Models.Demo.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DayName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e8f7aa4f-7665-44c5-bc95-787c21a3709d"),
                            DayName = "Saturday"
                        },
                        new
                        {
                            Id = new Guid("07b89cb9-fbb3-4f53-bb92-9b4b2e38c244"),
                            DayName = "Sunday"
                        },
                        new
                        {
                            Id = new Guid("617015bf-1ad1-4aa3-8b33-deb0bb4695b7"),
                            DayName = "Monday"
                        },
                        new
                        {
                            Id = new Guid("084fcdcf-fe24-4f07-bfaa-e7ca017ed4ff"),
                            DayName = "Tuesday"
                        },
                        new
                        {
                            Id = new Guid("7dad6383-779f-4cd8-8081-ef069fbf4e50"),
                            DayName = "Wednesday"
                        },
                        new
                        {
                            Id = new Guid("796f72c0-e41c-4661-965b-b80091bab18f"),
                            DayName = "Thursday"
                        },
                        new
                        {
                            Id = new Guid("a9e44b30-1c61-4170-808a-daff4fefabe2"),
                            DayName = "Friday"
                        });
                });

            modelBuilder.Entity("Entities.Models.Demo.FoodMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MenuCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VendorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("MealTypeId");

                    b.HasIndex("PackageId");

                    b.ToTable("FoodMenus");
                });

            modelBuilder.Entity("Entities.Models.Demo.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b9da871-8a3d-481f-b1b3-805440d55001"),
                            ItemName = "Rice"
                        },
                        new
                        {
                            Id = new Guid("649108f3-0fa3-4fe4-b9bd-cf47a6ce5925"),
                            ItemName = "Red Lentil"
                        },
                        new
                        {
                            Id = new Guid("3ea42539-e4a5-43df-9306-dc711a880c47"),
                            ItemName = "Mashed Potato"
                        },
                        new
                        {
                            Id = new Guid("c6ed9bfb-7cf4-4abb-be8c-64fbd49775f8"),
                            ItemName = "Khichri"
                        },
                        new
                        {
                            Id = new Guid("968fe7c0-f691-463f-bffb-e054b67b3d39"),
                            ItemName = "Rui fish curry"
                        },
                        new
                        {
                            Id = new Guid("973ddbdb-a252-4fd1-9b30-0700fbd5d0c7"),
                            ItemName = "Hilsha fish curry"
                        },
                        new
                        {
                            Id = new Guid("7e088cb4-5285-497e-835e-cbc7f272fb78"),
                            ItemName = "Hilsha fish fry"
                        },
                        new
                        {
                            Id = new Guid("7c2aae64-532b-4c26-a368-ac18246002c0"),
                            ItemName = "Egg curry"
                        },
                        new
                        {
                            Id = new Guid("eb342c57-e5da-4cc9-a4e2-87820a7f02fb"),
                            ItemName = "Deef"
                        },
                        new
                        {
                            Id = new Guid("98d196eb-0059-4314-bac5-f1d37e67136b"),
                            ItemName = "Chicken curry"
                        },
                        new
                        {
                            Id = new Guid("ca7767f7-b92d-42ac-924b-08c0e2c9ae4b"),
                            ItemName = "Chicken roast"
                        },
                        new
                        {
                            Id = new Guid("e2e009b9-bfb1-429f-be8d-8f0e4e293af8"),
                            ItemName = "Polao"
                        },
                        new
                        {
                            Id = new Guid("db748aa9-5627-4359-9c4e-856786ad6430"),
                            ItemName = "Chicken Polao"
                        },
                        new
                        {
                            Id = new Guid("1037a235-58d0-43fb-b936-7f0022658767"),
                            ItemName = "Kacchi Biriani"
                        },
                        new
                        {
                            Id = new Guid("5e0911b0-2cad-4c63-9373-5b308fbda727"),
                            ItemName = "Mutton Curry"
                        });
                });

            modelBuilder.Entity("Entities.Models.Demo.MealType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MealTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5605952f-8a67-4d21-ad25-02fafa687d84"),
                            TypeName = "Break Fast"
                        },
                        new
                        {
                            Id = new Guid("36899ed8-cff9-401b-a3ae-39ff6f870e8e"),
                            TypeName = "Lunch"
                        },
                        new
                        {
                            Id = new Guid("fe3a6760-763d-4aed-a807-c5b90fdd669c"),
                            TypeName = "Snacks"
                        },
                        new
                        {
                            Id = new Guid("29344037-8b40-48c1-b742-da56208e8225"),
                            TypeName = "Dinner"
                        });
                });

            modelBuilder.Entity("Entities.Models.Demo.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DistributorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderStateId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Models.Demo.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Entities.Models.Demo.OrderState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("96b4b93e-144d-415c-9f24-08fce568a4ae"),
                            StateName = "Add to cart"
                        },
                        new
                        {
                            Id = new Guid("3bbe9cd9-f03b-407a-85cd-ebea1c3bfbf7"),
                            StateName = "Order picked"
                        },
                        new
                        {
                            Id = new Guid("43427e1b-5422-4677-b7ef-ab63ad6a30c6"),
                            StateName = "On the way"
                        },
                        new
                        {
                            Id = new Guid("bc1e22cb-8473-4529-8dc1-96919ecffba3"),
                            StateName = "Delivered"
                        },
                        new
                        {
                            Id = new Guid("ba4b22aa-953c-41d7-9989-5c32ee97fe6b"),
                            StateName = "Paid"
                        });
                });

            modelBuilder.Entity("Entities.Models.Demo.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b"),
                            ImagePath = "assets/images/photo1.jpg",
                            PackageName = "Chicken Burger"
                        },
                        new
                        {
                            Id = new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9"),
                            ImagePath = "assets/images/photo2.jpg",
                            PackageName = "Rice and fish platter"
                        },
                        new
                        {
                            Id = new Guid("75dbbfa3-1d70-444a-8b25-49b8ae0f2021"),
                            ImagePath = "assets/images/photo3.jpg",
                            PackageName = "Chicken biriany"
                        },
                        new
                        {
                            Id = new Guid("bc171ae5-74d1-4c61-a3ef-65a4d245d1a3"),
                            ImagePath = "assets/images/photo4.jpg",
                            PackageName = "Vat and vorta"
                        },
                        new
                        {
                            Id = new Guid("99990751-0ce7-4172-ad8f-baed9476a397"),
                            ImagePath = "assets/images/photo5.jpg",
                            PackageName = "Beef khichuri"
                        });
                });

            modelBuilder.Entity("Entities.Models.Demo.PackageDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PackageDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageDetails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e87299b-2609-49e5-ba7e-5139a9a3995a"),
                            ItemId = new Guid("6b9da871-8a3d-481f-b1b3-805440d55001"),
                            PackageId = new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b")
                        },
                        new
                        {
                            Id = new Guid("42083e40-eeed-431d-899c-dddb72a0d4ce"),
                            ItemId = new Guid("973ddbdb-a252-4fd1-9b30-0700fbd5d0c7"),
                            PackageId = new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b")
                        },
                        new
                        {
                            Id = new Guid("488ec5d4-ce3e-43c7-968e-5ee60d956fce"),
                            ItemId = new Guid("3ea42539-e4a5-43df-9306-dc711a880c47"),
                            PackageId = new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b")
                        },
                        new
                        {
                            Id = new Guid("f0ef12e1-a24b-4fbf-a29f-284ca2ecf721"),
                            ItemId = new Guid("649108f3-0fa3-4fe4-b9bd-cf47a6ce5925"),
                            PackageId = new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b")
                        },
                        new
                        {
                            Id = new Guid("a90130af-4fc7-4008-b8b0-936d73101318"),
                            ItemId = new Guid("6b9da871-8a3d-481f-b1b3-805440d55001"),
                            PackageId = new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9")
                        },
                        new
                        {
                            Id = new Guid("7c9d92ff-f251-47f2-9b89-d77897c62903"),
                            ItemId = new Guid("5e0911b0-2cad-4c63-9373-5b308fbda727"),
                            PackageId = new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9")
                        },
                        new
                        {
                            Id = new Guid("83934c9c-aedf-4c8c-aefc-83c4eac19f5d"),
                            ItemId = new Guid("649108f3-0fa3-4fe4-b9bd-cf47a6ce5925"),
                            PackageId = new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9")
                        });
                });

            modelBuilder.Entity("Entities.Models.Demo.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Entities.Models.UsersProfilePicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserProfilePictureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfilePicture");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "4f56f0db-01fa-48db-9ae3-b1ca48baabf6",
                            ConcurrencyStamp = "71f4ae10-f84e-49f3-9e6f-47eb6f7333d4",
                            Name = "Consumer",
                            NormalizedName = "CONSUMER"
                        },
                        new
                        {
                            Id = "7c8a1493-bb90-4335-9c81-c3a02f78e34d",
                            ConcurrencyStamp = "590f2617-0eaf-4c0a-8ebc-334a65850596",
                            Name = "Vendor",
                            NormalizedName = "VENDOR"
                        },
                        new
                        {
                            Id = "22c17d38-bcfc-41d9-8d34-c3a951d3a265",
                            ConcurrencyStamp = "61fbd5b2-bca4-4556-b6a7-7f419e9e3a11",
                            Name = "Distributor",
                            NormalizedName = "DISTRIBUTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Demo.FoodMenu", b =>
                {
                    b.HasOne("Entities.Models.Demo.Day", "Day")
                        .WithMany("FoodMenus")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Demo.MealType", "MealType")
                        .WithMany("FoodMenus")
                        .HasForeignKey("MealTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Demo.Package", "Item")
                        .WithMany("FoodMenus")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Demo.Order", b =>
                {
                    b.HasOne("Entities.Models.Demo.OrderState", "OrderState")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Demo.OrderDetail", b =>
                {
                    b.HasOne("Entities.Models.Demo.FoodMenu", "FoodMenu")
                        .WithMany("OrderDetails")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Demo.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Demo.PackageDetail", b =>
                {
                    b.HasOne("Entities.Models.Demo.Item", "Item")
                        .WithMany("PackageDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Demo.Package", "Package")
                        .WithMany("PackageDetails")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Demo.Payment", b =>
                {
                    b.HasOne("Entities.Models.Demo.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

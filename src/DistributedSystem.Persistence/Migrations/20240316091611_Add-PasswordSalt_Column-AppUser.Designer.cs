﻿// <auto-generated />
using System;
using DistributedSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DistributedSystem.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240316091611_Add-PasswordSalt_Column-AppUser")]
    partial class AddPasswordSalt_ColumnAppUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.Action", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Actions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9c955674-7377-4b52-b5f4-82eab10fe6ed",
                            IsActive = true,
                            Name = "GET",
                            SortOrder = 1
                        },
                        new
                        {
                            Id = "3e700c49-37ee-4baa-8384-b1fe9f95f822",
                            IsActive = true,
                            Name = "POST",
                            SortOrder = 1
                        },
                        new
                        {
                            Id = "51e900fa-9445-486f-bd27-47bb1684673d",
                            IsActive = true,
                            Name = "PUT",
                            SortOrder = 1
                        },
                        new
                        {
                            Id = "8892ffdc-c7af-49cd-af76-d221c6642799",
                            IsActive = true,
                            Name = "DELETE",
                            SortOrder = 1
                        });
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.ActionInFunction", b =>
                {
                    b.Property<string>("ActionId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FunctionId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ActionId", "FunctionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("ActionInFunctions", (string)null);

                    b.HasData(
                        new
                        {
                            ActionId = "3e700c49-37ee-4baa-8384-b1fe9f95f822",
                            FunctionId = "1156b66d-ef2f-471e-9e37-44dfb2aea415"
                        },
                        new
                        {
                            ActionId = "51e900fa-9445-486f-bd27-47bb1684673d",
                            FunctionId = "8344a326-5e0f-4389-a251-832aae182286"
                        },
                        new
                        {
                            ActionId = "8892ffdc-c7af-49cd-af76-d221c6642799",
                            FunctionId = "e4bb65d0-3ff6-4182-af22-33a91e844af9"
                        },
                        new
                        {
                            ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed",
                            FunctionId = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c"
                        },
                        new
                        {
                            ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed",
                            FunctionId = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc"
                        });
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("424c4755-379e-440c-b67e-d53a4d615113"),
                            Description = "Administrator role with full access",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            RoleCode = "ADM"
                        },
                        new
                        {
                            Id = new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6"),
                            Description = "Standard user role with limited access",
                            Name = "User",
                            NormalizedName = "USER",
                            RoleCode = "USR"
                        });
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDirector")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsHeadOfDepartment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("IsReceipient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(-1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", (string)null);
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.Function", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CssClass")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Functions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c",
                            CssClass = "ProductApi",
                            Name = "Retrieve all products",
                            ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                            SortOrder = 2,
                            Url = "http://localhost:5000/api/v1/products"
                        },
                        new
                        {
                            Id = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc",
                            CssClass = "ProductApi",
                            Name = "Retrieve the details for product 1",
                            ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                            SortOrder = 2,
                            Url = "http://localhost:5000/api/v1/products/1"
                        },
                        new
                        {
                            Id = "1156b66d-ef2f-471e-9e37-44dfb2aea415",
                            CssClass = "ProductApi",
                            Name = "Create a new product",
                            ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                            SortOrder = 2,
                            Url = "http://localhost:5000/api/v1/products"
                        },
                        new
                        {
                            Id = "8344a326-5e0f-4389-a251-832aae182286",
                            CssClass = "ProductApi",
                            Name = "Update the details of product 1 if it exists",
                            ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                            SortOrder = 2,
                            Url = "http://localhost:5000/api/v1/products/1"
                        },
                        new
                        {
                            Id = "e4bb65d0-3ff6-4182-af22-33a91e844af9",
                            CssClass = "ProductApi",
                            Name = "Remove product 1",
                            ParentId = "13e2f21a-4283-4ff8-bb7a-096e7b89e0f0",
                            SortOrder = 2,
                            Url = "http://localhost:5000/api/v1/products/1"
                        });
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.Permission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FunctionId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ActionId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId", "FunctionId", "ActionId");

                    b.HasIndex("ActionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("Permissions", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("424c4755-379e-440c-b67e-d53a4d615113"),
                            FunctionId = "1156b66d-ef2f-471e-9e37-44dfb2aea415",
                            ActionId = "3e700c49-37ee-4baa-8384-b1fe9f95f822"
                        },
                        new
                        {
                            RoleId = new Guid("424c4755-379e-440c-b67e-d53a4d615113"),
                            FunctionId = "8344a326-5e0f-4389-a251-832aae182286",
                            ActionId = "51e900fa-9445-486f-bd27-47bb1684673d"
                        },
                        new
                        {
                            RoleId = new Guid("424c4755-379e-440c-b67e-d53a4d615113"),
                            FunctionId = "e4bb65d0-3ff6-4182-af22-33a91e844af9",
                            ActionId = "8892ffdc-c7af-49cd-af76-d221c6642799"
                        },
                        new
                        {
                            RoleId = new Guid("424c4755-379e-440c-b67e-d53a4d615113"),
                            FunctionId = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c",
                            ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed"
                        },
                        new
                        {
                            RoleId = new Guid("424c4755-379e-440c-b67e-d53a4d615113"),
                            FunctionId = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc",
                            ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed"
                        },
                        new
                        {
                            RoleId = new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6"),
                            FunctionId = "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c",
                            ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed"
                        },
                        new
                        {
                            RoleId = new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6"),
                            FunctionId = "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc",
                            ActionId = "9c955674-7377-4b52-b5f4-82eab10fe6ed"
                        });
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOnUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("ModifiedOnUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("DistributedSystem.Persistence.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("OccurredOnUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("ProcessedOnUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.ActionInFunction", b =>
                {
                    b.HasOne("DistributedSystem.Domain.Entities.Identity.Action", null)
                        .WithMany("ActionInFunctions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DistributedSystem.Domain.Entities.Identity.Function", null)
                        .WithMany("ActionInFunctions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.Permission", b =>
                {
                    b.HasOne("DistributedSystem.Domain.Entities.Identity.Action", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DistributedSystem.Domain.Entities.Identity.Function", null)
                        .WithMany("Permissions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DistributedSystem.Domain.Entities.Identity.AppRole", null)
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("DistributedSystem.Domain.Entities.Identity.AppRole", null)
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DistributedSystem.Domain.Entities.Identity.AppUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DistributedSystem.Domain.Entities.Identity.AppUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("DistributedSystem.Domain.Entities.Identity.AppRole", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DistributedSystem.Domain.Entities.Identity.AppUser", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DistributedSystem.Domain.Entities.Identity.AppUser", null)
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.Action", b =>
                {
                    b.Navigation("ActionInFunctions");

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.AppRole", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Permissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Tokens");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DistributedSystem.Domain.Entities.Identity.Function", b =>
                {
                    b.Navigation("ActionInFunctions");

                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}

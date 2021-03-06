﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recinia.Entities;

namespace Recinia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Recinia.Entities.Adress", b =>
                {
                    b.Property<int>("AddId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(20);

                    b.Property<int>("PersonId");

                    b.Property<string>("State");

                    b.Property<string>("StreetName")
                        .HasColumnName("Street")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("AddId");

                    b.ToTable("Adr","Adress");
                });

            modelBuilder.Entity("Recinia.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
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

            modelBuilder.Entity("Recinia.Entities.Person", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("Numéro");

                    b.Property<string>("Display")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("[FirstName]+'  '+[LastName]");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName")
                        .IsConcurrencyToken();

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ID", "Numéro");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Numéro = "123654",
                            Display = "",
                            FirstName = "Omar",
                            LastName = "Karmous",
                            TimeStamp = new byte[] { 1, 166, 229, 101, 170, 208, 214, 72 }
                        },
                        new
                        {
                            ID = 2,
                            Numéro = "789654",
                            Display = "",
                            FirstName = "Mario",
                            LastName = "brutti",
                            TimeStamp = new byte[] { 241, 231, 229, 101, 170, 208, 214, 72 }
                        });
                });

            modelBuilder.Entity("Recinia.Entities.Publication", b =>
                {
                    b.Property<Guid>("PubID");

                    b.Property<string>("AspNetUserId");

                    b.Property<string>("AspNetUsersId");

                    b.Property<string>("Image");

                    b.Property<string>("TimePost")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("contenu");

                    b.HasKey("PubID");

                    b.HasIndex("AspNetUsersId");

                    b.ToTable("Publications");

                    b.HasData(
                        new
                        {
                            PubID = new Guid("a580e935-d7dc-439e-86b1-cda4bae5df50"),
                            AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
                            Image = "qqsdfghbjnkjnkj",
                            contenu = "Préparation"
                        },
                        new
                        {
                            PubID = new Guid("a4fd2488-9bd6-4f74-86f4-b3c3834031eb"),
                            AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
                            Image = "Pomme",
                            contenu = "Fiche Technique"
                        },
                        new
                        {
                            PubID = new Guid("a68a1387-f5aa-4981-84ab-12b024e40f40"),
                            AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
                            Image = "azertyuicvb",
                            contenu = "Védio"
                        },
                        new
                        {
                            PubID = new Guid("9455c079-8628-4944-9f2e-b0abd1e64087"),
                            AspNetUserId = "9c879b33-b99d-4456-ad2b-c362f6fc858a",
                            Image = "5222222222222",
                            contenu = "Image"
                        });
                });

            modelBuilder.Entity("Recinia.Models.Hobbies", b =>
                {
                    b.Property<Guid>("HobbieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AspNetUserId");

                    b.Property<string>("AspNetUsersId");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<int>("Rating");

                    b.HasKey("HobbieID");

                    b.HasIndex("AspNetUsersId");

                    b.ToTable("Hobby");
                });

            modelBuilder.Entity("Recinia.Models.Individual", b =>
                {
                    b.Property<Guid>("IndividualID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("AspNetUserId");

                    b.Property<string>("AspNetUsersId");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.HasKey("IndividualID");

                    b.HasIndex("AspNetUsersId");

                    b.ToTable("Individual");
                });

            modelBuilder.Entity("Recinia.Models.Organization", b =>
                {
                    b.Property<Guid>("OrganizationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("AspNetUserId");

                    b.Property<string>("AspNetUsersId");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("City");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("Profession");

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.HasKey("OrganizationID");

                    b.HasIndex("AspNetUsersId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Recinia.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Recinia.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Recinia.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Recinia.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Recinia.Entities.Publication", b =>
                {
                    b.HasOne("Recinia.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("AspNetUsersId");
                });

            modelBuilder.Entity("Recinia.Models.Hobbies", b =>
                {
                    b.HasOne("Recinia.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("AspNetUsersId");
                });

            modelBuilder.Entity("Recinia.Models.Individual", b =>
                {
                    b.HasOne("Recinia.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("AspNetUsersId");
                });

            modelBuilder.Entity("Recinia.Models.Organization", b =>
                {
                    b.HasOne("Recinia.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("AspNetUsersId");
                });
#pragma warning restore 612, 618
        }
    }
}

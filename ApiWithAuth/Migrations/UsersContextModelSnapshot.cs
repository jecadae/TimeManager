﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ApiWithAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiWithAuth.Migrations
{
    [DbContext(typeof(UsersContext))]
    partial class UsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiWithAuth.Entity.AppPlan", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("done")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("AppPlans");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppQuest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AppPlanId")
                        .HasColumnType("bigint");

                    b.Property<string>("AppUserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discription")
                        .HasColumnType("text");

                    b.Property<List<string>>("Links")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AppPlanId");

                    b.ToTable("AppQuests");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<int?>("AppUserIconsId")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserIconsId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppUserIcon", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("AppUserId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<byte[]>("ImageArray")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("AppUserIcons");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppPlan", b =>
                {
                    b.HasOne("ApiWithAuth.Entity.AppUser", null)
                        .WithMany("UserPlans")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppQuest", b =>
                {
                    b.HasOne("ApiWithAuth.Entity.AppPlan", null)
                        .WithMany("Quests")
                        .HasForeignKey("AppPlanId");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppUser", b =>
                {
                    b.HasOne("ApiWithAuth.Entity.AppUserIcon", "AppUserIcon")
                        .WithOne("AppUser")
                        .HasForeignKey("ApiWithAuth.Entity.AppUser", "AppUserIconsId")
                        .HasPrincipalKey("ApiWithAuth.Entity.AppUserIcon", "AppUserId");

                    b.Navigation("AppUserIcon");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppPlan", b =>
                {
                    b.Navigation("Quests");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppUser", b =>
                {
                    b.Navigation("UserPlans");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppUserIcon", b =>
                {
                    b.Navigation("AppUser");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using ApiWithAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiWithAuth.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230407141014_123")]
    partial class _123
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiWithAuth.Entity.AppPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Creater")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("done")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("AppPlans");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppQuest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppPlanId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Parent")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AppPlanId");

                    b.ToTable("AppQuest");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppQuest", b =>
                {
                    b.HasOne("ApiWithAuth.Entity.AppPlan", null)
                        .WithMany("Quests")
                        .HasForeignKey("AppPlanId");
                });

            modelBuilder.Entity("ApiWithAuth.Entity.AppPlan", b =>
                {
                    b.Navigation("Quests");
                });
#pragma warning restore 612, 618
        }
    }
}

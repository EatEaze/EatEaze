﻿// <auto-generated />
using System;
using EatEaze.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EatEaze.Data.Migrations
{
    [DbContext(typeof(EatEazeDataContext))]
    [Migration("20231113215035_PriceMigration")]
    partial class PriceMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EatEaze.Data.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Position", b =>
                {
                    b.Property<Guid>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("RestarauntId")
                        .HasColumnType("uuid");

                    b.HasKey("PositionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RestarauntId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.PositionInOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionsInOrders");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Restaraunt", b =>
                {
                    b.Property<Guid>("RestarauntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RestarauntName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RestarauntId");

                    b.ToTable("Restaraunts");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.RestarauntInCity", b =>
                {
                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RestarauntId")
                        .HasColumnType("uuid");

                    b.HasKey("CityId", "RestarauntId");

                    b.HasIndex("RestarauntId");

                    b.ToTable("RestarauntsInCities");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Order", b =>
                {
                    b.HasOne("EatEaze.Data.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Position", b =>
                {
                    b.HasOne("EatEaze.Data.Entities.Category", "Category")
                        .WithMany("Positions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EatEaze.Data.Entities.Restaraunt", "Restaraunt")
                        .WithMany("Positions")
                        .HasForeignKey("RestarauntId");

                    b.Navigation("Category");

                    b.Navigation("Restaraunt");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.PositionInOrder", b =>
                {
                    b.HasOne("EatEaze.Data.Entities.Order", "Order")
                        .WithMany("PositionsInOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EatEaze.Data.Entities.Position", "Position")
                        .WithMany("PositionsInOrders")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.RestarauntInCity", b =>
                {
                    b.HasOne("EatEaze.Data.Entities.City", "City")
                        .WithMany("RestarauntsInCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EatEaze.Data.Entities.Restaraunt", "Restaraunt")
                        .WithMany("RestarauntsInCities")
                        .HasForeignKey("RestarauntId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Restaraunt");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.User", b =>
                {
                    b.HasOne("EatEaze.Data.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Category", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.City", b =>
                {
                    b.Navigation("RestarauntsInCities");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Order", b =>
                {
                    b.Navigation("PositionsInOrders");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Position", b =>
                {
                    b.Navigation("PositionsInOrders");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.Restaraunt", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("RestarauntsInCities");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EatEaze.Data.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

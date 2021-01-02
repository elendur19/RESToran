﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RESToran.DataAccess;

namespace RESToran.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20210102124516_Restaurant_Email_Pass2")]
    partial class Restaurant_Email_Pass2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("RESToran.Models.Dish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("HouseSpecial")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("RESToran.Models.ReservationPeriod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("DishId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TableDescription")
                        .HasColumnType("text");

                    b.Property<long>("TableId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("TableId");

                    b.ToTable("ReservationPeriod");
                });

            modelBuilder.Entity("RESToran.Models.Restaurant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HoursOpened")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("RESToran.Models.Table", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("NumberOfSeats")
                        .HasColumnType("double precision");

                    b.Property<string>("RestName_Number")
                        .HasColumnType("text");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestName_Number")
                        .IsUnique();

                    b.HasIndex("RestaurantId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("RESToran.Models.Dish", b =>
                {
                    b.HasOne("RESToran.Models.Restaurant", null)
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RESToran.Models.ReservationPeriod", b =>
                {
                    b.HasOne("RESToran.Models.Dish", null)
                        .WithMany("ReservationPeriod")
                        .HasForeignKey("DishId");

                    b.HasOne("RESToran.Models.Table", null)
                        .WithMany("ReservationPeriod")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RESToran.Models.Table", b =>
                {
                    b.HasOne("RESToran.Models.Restaurant", null)
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RESToran.Models.Dish", b =>
                {
                    b.Navigation("ReservationPeriod");
                });

            modelBuilder.Entity("RESToran.Models.Restaurant", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RESToran.Models.Table", b =>
                {
                    b.Navigation("ReservationPeriod");
                });
#pragma warning restore 612, 618
        }
    }
}

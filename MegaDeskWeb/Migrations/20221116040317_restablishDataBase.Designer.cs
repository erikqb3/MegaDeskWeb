﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegaDeskWeb.Migrations
{
    [DbContext(typeof(MegaDeskWebContext))]
    [Migration("20221116040317_restablishDataBase")]
    partial class restablishDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("MegaDeskWeb.Models.Desk", b =>
                {
                    b.Property<int>("DeskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RushOptionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("depth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("drawerCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("width")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeskId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("RushOptionId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DeskQuote", b =>
                {
                    b.Property<int>("DeskQuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("contactInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("contactMethod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("finishDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("quoteTotalPrice")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("TEXT");

                    b.HasKey("DeskQuoteId");

                    b.HasIndex("DeskId");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.HasKey("MaterialId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.RushOption", b =>
                {
                    b.Property<int>("RushOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("basePrice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("days")
                        .HasColumnType("INTEGER");

                    b.Property<int>("modifier")
                        .HasColumnType("INTEGER");

                    b.HasKey("RushOptionId");

                    b.ToTable("RushOption");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.Desk", b =>
                {
                    b.HasOne("MegaDeskWeb.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaDeskWeb.Models.RushOption", "RushOption")
                        .WithMany()
                        .HasForeignKey("RushOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("RushOption");
                });

            modelBuilder.Entity("MegaDeskWeb.Models.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskWeb.Models.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desk");
                });
#pragma warning restore 612, 618
        }
    }
}

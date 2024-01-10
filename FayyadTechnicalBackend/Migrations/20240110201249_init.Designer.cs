﻿// <auto-generated />
using System;
using FayyadTechnicalBackend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FayyadTechnicalBackend.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240110201249_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FayyadTechnicalBackend.Models.Cart", b =>
                {
                    b.Property<int?>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CartId"));

                    b.Property<int?>("ItemsId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("ItemsId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("FayyadTechnicalBackend.Models.Items", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FayyadTechnicalBackend.Models.Cart", b =>
                {
                    b.HasOne("FayyadTechnicalBackend.Models.Items", "Items")
                        .WithMany()
                        .HasForeignKey("ItemsId");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
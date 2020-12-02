﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShoppApi.Repositories.Contexts;

namespace ShoppApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201201234308_UpdateV1")]
    partial class UpdateV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ShoppApi.DTO.CartProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CartId")
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SkuOid")
                        .HasColumnType("uuid");

                    b.Property<double>("UnitValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("SkuOid");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("ShoppApi.Model.Cart", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("carts");
                });

            modelBuilder.Entity("ShoppApi.Model.Product", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Oid");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ShoppApi.Model.Sku", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Inventory")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("ProductOid")
                        .HasColumnType("uuid");

                    b.HasKey("Oid");

                    b.HasIndex("ProductOid");

                    b.ToTable("skus");
                });

            modelBuilder.Entity("ShoppApi.DTO.CartProduct", b =>
                {
                    b.HasOne("ShoppApi.Model.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("ShoppApi.Model.Sku", "Sku")
                        .WithMany()
                        .HasForeignKey("SkuOid");
                });

            modelBuilder.Entity("ShoppApi.Model.Sku", b =>
                {
                    b.HasOne("ShoppApi.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductOid");
                });
#pragma warning restore 612, 618
        }
    }
}

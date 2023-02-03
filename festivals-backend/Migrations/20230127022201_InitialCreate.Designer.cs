﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace festivals.Migrations
{
    [DbContext(typeof(FestivalDbContext))]
    [Migration("20230127022201_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Artist", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("id"));

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<int?>("Festivalid")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("Festivalid");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Festival", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("id"));

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Festivals");
                });

            modelBuilder.Entity("Artist", b =>
                {
                    b.HasOne("Festival", "Festival")
                        .WithMany("Artist")
                        .HasForeignKey("Festivalid");

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("Festival", b =>
                {
                    b.Navigation("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}
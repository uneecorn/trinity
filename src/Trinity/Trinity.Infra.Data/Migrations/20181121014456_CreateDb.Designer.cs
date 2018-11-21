﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trinity.Infra.Data.Context;

namespace Trinity.Infra.Data.Migrations
{
    [DbContext(typeof(TrinityContext))]
    [Migration("20181121014456_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trinity.Domain.Model.Album", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("VarChar")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnName("UpdateDate")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Trinity.Domain.Model.Band", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<short>("FoundationYear")
                        .HasColumnName("FoundationYear")
                        .HasColumnType("SmallInt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VarChar")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnName("UpdateDate")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("Trinity.Domain.Model.Music", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AlbumId");

                    b.Property<long>("BandId");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate")
                        .HasColumnType("DateTime");

                    b.Property<long>("Duration")
                        .HasColumnName("DurationTicks")
                        .HasColumnType("BigInt");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("VarChar")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnName("UpdateDate")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("BandId");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("Trinity.Domain.Model.Music", b =>
                {
                    b.HasOne("Trinity.Domain.Model.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId");

                    b.HasOne("Trinity.Domain.Model.Band", "Band")
                        .WithMany()
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SystemInfo.Persistance.DataBaseContext;

#nullable disable

namespace SystemInfo.Persistance.Migrations
{
    [DbContext(typeof(Storage))]
    [Migration("20240814132735_AddClientSystemInfoEntity")]
    partial class AddClientSystemInfoEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SystemInfo.Domain.Entities.ClientSystemInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CpuProcess")
                        .HasColumnType("float");

                    b.Property<int>("NumbersSum")
                        .HasColumnType("int");

                    b.Property<double>("RamProcess")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ClientSystemInfos");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using master_bppm.Models;

#nullable disable

namespace master_bppm.Migrations
{
    [DbContext(typeof(SQLContext))]
    [Migration("20230926043122_EditDataType")]
    partial class EditDataType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("master_bppm.Models.XXB7_ESS_BPPM_LOG_MASTER_DATA", b =>
                {
                    b.Property<int>("LOG_MASTER_DATA_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LOG_MASTER_DATA_ID"));

                    b.Property<int>("BPPM_ITEM_ID")
                        .HasColumnType("int");

                    b.Property<string>("DETAILS")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LOCATION")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("MACHINE")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("ORACLE_ITEM_CODE")
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("ORACLE_ITEM_DESCRIPTION")
                        .HasMaxLength(240)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("ORACLE_ITEM_ID")
                        .HasColumnType("int");

                    b.Property<string>("ORGANIZATION")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PHOTO_URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STATUS")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("TIME_STAMP")
                        .HasColumnType("datetime2");

                    b.Property<string>("UOM")
                        .HasMaxLength(25)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("USER")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("LOG_MASTER_DATA_ID");

                    b.ToTable("XXB7_ESS_BPPM_LOG_MASTER_DATA");
                });

            modelBuilder.Entity("master_bppm.Models.XXB7_ESS_BPPM_MASTER_DATA", b =>
                {
                    b.Property<int>("BPPM_ITEM_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BPPM_ITEM_ID"));

                    b.Property<int?>("AVAILABILITY")
                        .HasColumnType("int");

                    b.Property<string>("DETAILS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LOCATION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MACHINE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MAX_QTY")
                        .HasColumnType("int");

                    b.Property<int?>("MIN_QTY")
                        .HasColumnType("int");

                    b.Property<string>("ORACLE_ITEM_CODE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ORACLE_ITEM_DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ORACLE_ITEM_ID")
                        .HasColumnType("int");

                    b.Property<string>("ORGANIZATION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PHOTO_URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STATUS")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<int?>("UNIT_PRICE")
                        .HasColumnType("int");

                    b.Property<string>("UOM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("USAGE_PER_YEAR")
                        .HasColumnType("int");

                    b.HasKey("BPPM_ITEM_ID");

                    b.ToTable("XXB7_ESS_BPPM_MASTER_DATA");
                });
#pragma warning restore 612, 618
        }
    }
}

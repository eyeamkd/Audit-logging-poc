﻿// <auto-generated />
using System;
using AuditLoggerPoc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuditLoggerPoc.Migrations.AuditTrailDb
{
    [DbContext(typeof(AuditTrailDbContext))]
    [Migration("20230412112218_New-DbContext")]
    partial class NewDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("AuditLoggerPoc.AuditTrailData", b =>
                {
                    b.Property<Guid>("TrailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("affectedColumns")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("newValues")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("oldValues")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("primaryKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TrailId");

                    b.ToTable("AuditTrails", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using CQRS.Library.BorrowingHistoryApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CQRS.Library.BorrowingHistoryApi.Migrations
{
    [DbContext(typeof(BorrowingHistoryDbContext))]
    [Migration("20250301133135_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CQRS.Library.BorrowingHistoryApi.Infrastructure.Entity.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CQRS.Library.BorrowingHistoryApi.Infrastructure.Entity.Borrower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("CQRS.Library.BorrowingHistoryApi.Infrastructure.Entity.BorrowingHistoryItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BookAuthor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BorrowedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("BorrowerAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BorrowerEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BorrowerId")
                        .HasColumnType("uuid");

                    b.Property<string>("BorrowerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BorrowerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HasReturned")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ReturnedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId", "BookId", "ValidUntil", "HasReturned");

                    b.ToTable("BorrowingHistoryItems");
                });
#pragma warning restore 612, 618
        }
    }
}

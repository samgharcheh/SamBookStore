﻿// <auto-generated />
using System;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Infrastructure.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20210326154835_init-db")]
    partial class initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(350)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("BookStore.Domain.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .IsRequired();

                    b.HasOne("BookStore.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .IsRequired();
                });

            modelBuilder.Entity("BookStore.Domain.Models.Book", b =>
                {
                    b.HasOne("BookStore.Domain.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookStore.Domain.Models.Category", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

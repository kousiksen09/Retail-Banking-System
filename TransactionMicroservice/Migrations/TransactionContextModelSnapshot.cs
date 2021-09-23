﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionMicroservice;

namespace TransactionMicroservice.Migrations
{
    [DbContext(typeof(TransactionContext))]
    partial class TransactionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionMicroservice.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("minBalance")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TransactionMicroservice.Models.TransactionHistory", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime2");

                    b.Property<double>("TransactionAmount")
                        .HasColumnType("float");

                    b.Property<double>("destination_balance")
                        .HasColumnType("float");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("source_balance")
                        .HasColumnType("float");

                    b.HasKey("TransactionId");

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("TransactionMicroservice.Models.TransactionStatus", b =>
                {
<<<<<<< HEAD
<<<<<<< HEAD
                    b.Property<int>("Id")
                        .HasColumnType("int");

=======
>>>>>>> a83808bc7b9313aea7cd35d3addc0b6e1007d6ec
=======
>>>>>>> a83808bc7b9313aea7cd35d3addc0b6e1007d6ec
                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TransactionStatus");
                });
#pragma warning restore 612, 618
        }
    }
}

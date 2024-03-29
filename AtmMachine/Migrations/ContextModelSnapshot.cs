﻿// <auto-generated />
using System;
using AtmMachine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtmMachine.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AtmMachine.Models.Money", b =>
                {
                    b.Property<int>("moneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("money")
                        .HasColumnType("real");

                    b.HasKey("moneyId");

                    b.ToTable("Moneys");
                });

            modelBuilder.Entity("AtmMachine.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("hashed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("moneyId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("salted")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("moneyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AtmMachine.Models.User", b =>
                {
                    b.HasOne("AtmMachine.Models.Money", "money")
                        .WithMany()
                        .HasForeignKey("moneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("money");
                });
#pragma warning restore 612, 618
        }
    }
}

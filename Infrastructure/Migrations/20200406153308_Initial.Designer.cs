﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20200406153308_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.CuentaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CuentaBancaria");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CuentaBancaria");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoFinanciero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CuentaBancariaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorConsignacion")
                        .HasColumnType("float");

                    b.Property<double>("ValorRetiro")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CuentaBancariaId");

                    b.ToTable("MovimientoFinanciero");
                });

            modelBuilder.Entity("Domain.Entities.CuentaAhorro", b =>
                {
                    b.HasBaseType("Domain.Entities.CuentaBancaria");

                    b.HasDiscriminator().HasValue("CuentaAhorro");
                });

            modelBuilder.Entity("Domain.Entities.CuentaCorriente", b =>
                {
                    b.HasBaseType("Domain.Entities.CuentaBancaria");

                    b.HasDiscriminator().HasValue("CuentaCorriente");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoFinanciero", b =>
                {
                    b.HasOne("Domain.Entities.CuentaBancaria", "CuentaBancaria")
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaBancariaId");
                });
#pragma warning restore 612, 618
        }
    }
}
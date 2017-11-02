﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using MvcDemo.Models;
using System;

namespace MvcDemo.Migrations
{
    [DbContext(typeof(ContaContexto))]
    [Migration("20171025220709_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("MvcDemo.Models.ContaDeLuz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataDeLeitura")
                        .IsRequired();

                    b.Property<string>("DataDoPagamento")
                        .IsRequired();

                    b.Property<int>("KwGasto");

                    b.Property<float>("MediaDeConsumo");

                    b.Property<int>("NumLeitura");

                    b.Property<float>("ValorPagar");

                    b.HasKey("Id");

                    b.ToTable("Conta");
                });
#pragma warning restore 612, 618
        }
    }
}

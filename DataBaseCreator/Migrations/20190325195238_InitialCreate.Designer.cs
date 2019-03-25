﻿// <auto-generated />
using System;
using DataBaseCreator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBaseCreator.Migrations
{
    [DbContext(typeof(TestTempContext))]
    [Migration("20190325195238_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataBaseCreator.TestTemp", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("airTemperature");

                    b.Property<float>("chemicalConcentration");

                    b.Property<DateTime>("measureTime");

                    b.Property<float>("surfaceTemperature");

                    b.Property<float>("visibility");

                    b.Property<float>("waterIceThickness");

                    b.Property<float>("windSpeed");

                    b.HasKey("id");

                    b.ToTable("Temp");
                });
#pragma warning restore 612, 618
        }
    }
}

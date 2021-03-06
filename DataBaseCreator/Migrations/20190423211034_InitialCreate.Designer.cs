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
    [Migration("20190423211034_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataBaseCreator.DBTrafficIntensity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("dbTemperatureid");

                    b.Property<float>("intenstiy");

                    b.Property<DateTime>("measureTime");

                    b.Property<int>("roadSegmentId");

                    b.HasKey("id");

                    b.HasIndex("dbTemperatureid");

                    b.ToTable("Intensity");
                });

            modelBuilder.Entity("DataBaseCreator.DBWeatherCondition", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("humidity");

                    b.Property<DateTime>("measureTime");

                    b.Property<float>("pressure");

                    b.Property<float>("temperature");

                    b.Property<int>("visibility");

                    b.Property<float>("windDeg");

                    b.Property<float>("windSpeed");

                    b.HasKey("id");

                    b.ToTable("WeatherCondition");
                });

            modelBuilder.Entity("DataBaseCreator.DBTrafficIntensity", b =>
                {
                    b.HasOne("DataBaseCreator.DBWeatherCondition", "dbTemperature")
                        .WithMany("dbTrafficIntensity")
                        .HasForeignKey("dbTemperatureid");
                });
#pragma warning restore 612, 618
        }
    }
}

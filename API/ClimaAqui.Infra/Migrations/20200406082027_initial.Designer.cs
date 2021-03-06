﻿// <auto-generated />
using System;
using ClimaAqui.Infra.Configuracao.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClimaAqui.Infra.Migrations
{
    [DbContext(typeof(AplicacaoContexto))]
    [Migration("20200406082027_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("coordId");

                    b.Property<string>("country");

                    b.Property<string>("name");

                    b.Property<int>("population");

                    b.Property<int>("sunrise");

                    b.Property<int>("sunset");

                    b.Property<int>("timezone");

                    b.HasKey("Id");

                    b.HasIndex("coordId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Clouds", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("all");

                    b.HasKey("Id");

                    b.ToTable("Clouds");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("cityId");

                    b.Property<int>("cnt");

                    b.Property<string>("cod");

                    b.Property<int>("message");

                    b.HasKey("Id");

                    b.HasIndex("cityId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Coord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("lat");

                    b.Property<double>("lon");

                    b.HasKey("Id");

                    b.ToTable("Coord");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConsultaId");

                    b.Property<int?>("cloudsId");

                    b.Property<int>("dt");

                    b.Property<string>("dt_txt");

                    b.Property<int?>("mainId");

                    b.Property<int?>("rainId");

                    b.Property<int?>("sysId");

                    b.Property<int?>("windId");

                    b.HasKey("Id");

                    b.HasIndex("ConsultaId");

                    b.HasIndex("cloudsId");

                    b.HasIndex("mainId");

                    b.HasIndex("rainId");

                    b.HasIndex("sysId");

                    b.HasIndex("windId");

                    b.ToTable("List");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Main", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("feels_like");

                    b.Property<int>("grnd_level");

                    b.Property<int>("humidity");

                    b.Property<int>("pressure");

                    b.Property<int>("sea_level");

                    b.Property<double>("temp");

                    b.Property<double>("temp_kf");

                    b.Property<double>("temp_max");

                    b.Property<double>("temp_min");

                    b.HasKey("Id");

                    b.ToTable("Main");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Rain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("__invalid_name__3h");

                    b.HasKey("Id");

                    b.ToTable("Rain");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Sys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("pod");

                    b.HasKey("Id");

                    b.ToTable("Sys");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ListId");

                    b.Property<string>("description");

                    b.Property<string>("icon");

                    b.Property<string>("main");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Wind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("deg");

                    b.Property<double>("speed");

                    b.HasKey("Id");

                    b.ToTable("Wind");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.City", b =>
                {
                    b.HasOne("ClimaAqui.Dominio.Entidades.Coord", "coord")
                        .WithMany()
                        .HasForeignKey("coordId");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Consulta", b =>
                {
                    b.HasOne("ClimaAqui.Dominio.Entidades.City", "city")
                        .WithMany()
                        .HasForeignKey("cityId");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.List", b =>
                {
                    b.HasOne("ClimaAqui.Dominio.Entidades.Consulta")
                        .WithMany("list")
                        .HasForeignKey("ConsultaId");

                    b.HasOne("ClimaAqui.Dominio.Entidades.Clouds", "clouds")
                        .WithMany()
                        .HasForeignKey("cloudsId");

                    b.HasOne("ClimaAqui.Dominio.Entidades.Main", "main")
                        .WithMany()
                        .HasForeignKey("mainId");

                    b.HasOne("ClimaAqui.Dominio.Entidades.Rain", "rain")
                        .WithMany()
                        .HasForeignKey("rainId");

                    b.HasOne("ClimaAqui.Dominio.Entidades.Sys", "sys")
                        .WithMany()
                        .HasForeignKey("sysId");

                    b.HasOne("ClimaAqui.Dominio.Entidades.Wind", "wind")
                        .WithMany()
                        .HasForeignKey("windId");
                });

            modelBuilder.Entity("ClimaAqui.Dominio.Entidades.Weather", b =>
                {
                    b.HasOne("ClimaAqui.Dominio.Entidades.List")
                        .WithMany("weather")
                        .HasForeignKey("ListId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_PNT1.Context;

#nullable disable

namespace Proyecto_PNT1.Migrations
{
    [DbContext(typeof(ProyectoDatabaseContext))]
    [Migration("20240626005219_ProyectoPNT1")]
    partial class ProyectoPNT1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_PNT1.Models.Calificacion", b =>
                {
                    b.Property<int>("CalificacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalificacionId"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropuestaId")
                        .HasColumnType("int");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CalificacionId");

                    b.HasIndex("PropuestaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Calificaciones");
                });

            modelBuilder.Entity("Proyecto_PNT1.Models.Propuesta", b =>
                {
                    b.Property<int>("PropuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropuestaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaLimite")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PropuestaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Propuestas");
                });

            modelBuilder.Entity("Proyecto_PNT1.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("ApellidoUsuario")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Proyecto_PNT1.Models.Calificacion", b =>
                {
                    b.HasOne("Proyecto_PNT1.Models.Propuesta", "Propuesta")
                        .WithMany()
                        .HasForeignKey("PropuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_PNT1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propuesta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto_PNT1.Models.Propuesta", b =>
                {
                    b.HasOne("Proyecto_PNT1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
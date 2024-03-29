﻿// <auto-generated />
using LugoTechCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LugoTechCrud.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191214212053_initialize")]
    partial class initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LugoTechCrud.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos");

                    b.Property<string>("Contra");

                    b.Property<bool>("Estado");

                    b.Property<string>("Genero");

                    b.Property<string>("Nacionalidad");

                    b.Property<string>("NombreUsuario");

                    b.Property<string>("Nombres");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}

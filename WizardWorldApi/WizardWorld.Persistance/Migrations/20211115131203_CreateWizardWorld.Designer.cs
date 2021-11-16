﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WizardWorld.Persistance;

namespace WizardWorld.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211115131203_CreateWizardWorld")]
    partial class CreateWizardWorld
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WizardWorld.Persistance.Models.Spells.Spell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanBeVerbal")
                        .HasColumnType("boolean");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<string>("Effect")
                        .HasColumnType("text");

                    b.Property<int>("Light")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Spells");
                });
#pragma warning restore 612, 618
        }
    }
}

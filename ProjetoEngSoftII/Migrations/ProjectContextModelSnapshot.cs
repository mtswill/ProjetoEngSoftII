﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetoEngSoftII.Data;

namespace ProjetoEngSoftII.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ProjetoEngSoftII.Models.CarteiraVacinacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PacienteCpf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PacienteCpf");

                    b.ToTable("carteira_vacinacao");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Paciente", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<string>("Cns")
                        .HasColumnType("text")
                        .HasColumnName("cns");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_nascimento");

                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Rg")
                        .HasColumnType("text")
                        .HasColumnName("rg");

                    b.HasKey("Cpf");

                    b.ToTable("paciente");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Vacina", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("vacina");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.CarteiraVacinacao", b =>
                {
                    b.HasOne("ProjetoEngSoftII.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteCpf");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}

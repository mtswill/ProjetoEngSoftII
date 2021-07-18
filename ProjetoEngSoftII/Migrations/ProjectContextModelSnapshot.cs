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
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PacienteCpf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PacienteCpf");

                    b.ToTable("carteira_vacinacao");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Enderecos.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("text")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .HasColumnType("text")
                        .HasColumnName("cidade");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<string>("Estado")
                        .HasColumnType("text")
                        .HasColumnName("estado");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text")
                        .HasColumnName("logradouro");

                    b.Property<string>("Numero")
                        .HasColumnType("text")
                        .HasColumnName("numero");

                    b.HasKey("Id");

                    b.ToTable("endereco");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Paciente", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("Cns")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Rg")
                        .HasColumnType("text");

                    b.HasKey("Cpf");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("paciente");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Vacinas.MarcaVacinaCovid", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Marca")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("marca_vacina_covid");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Vacinas.Vacinado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataVacinacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Dose")
                        .HasColumnType("text");

                    b.Property<string>("Lote")
                        .HasColumnType("text");

                    b.Property<long>("MarcaVacinaCovidId")
                        .HasColumnType("bigint");

                    b.Property<string>("PacienteCpf")
                        .HasColumnType("text");

                    b.Property<long>("VacinadorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MarcaVacinaCovidId")
                        .IsUnique();

                    b.HasIndex("PacienteCpf")
                        .IsUnique();

                    b.HasIndex("VacinadorId")
                        .IsUnique();

                    b.ToTable("vacinado");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Vacinas.Vacinador", b =>
                {
                    b.Property<long>("RegistroProfissional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("RegistroProfissional");

                    b.ToTable("vacinador");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.CarteiraVacinacao", b =>
                {
                    b.HasOne("ProjetoEngSoftII.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteCpf");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Paciente", b =>
                {
                    b.HasOne("ProjetoEngSoftII.Models.Enderecos.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("ProjetoEngSoftII.Models.Paciente", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ProjetoEngSoftII.Models.Vacinas.Vacinado", b =>
                {
                    b.HasOne("ProjetoEngSoftII.Models.Vacinas.MarcaVacinaCovid", "MarcaVacinaCovid")
                        .WithOne()
                        .HasForeignKey("ProjetoEngSoftII.Models.Vacinas.Vacinado", "MarcaVacinaCovidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoEngSoftII.Models.Paciente", "Paciente")
                        .WithOne()
                        .HasForeignKey("ProjetoEngSoftII.Models.Vacinas.Vacinado", "PacienteCpf");

                    b.HasOne("ProjetoEngSoftII.Models.Vacinas.Vacinador", "Vacinador")
                        .WithOne()
                        .HasForeignKey("ProjetoEngSoftII.Models.Vacinas.Vacinado", "VacinadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaVacinaCovid");

                    b.Navigation("Paciente");

                    b.Navigation("Vacinador");
                });
#pragma warning restore 612, 618
        }
    }
}

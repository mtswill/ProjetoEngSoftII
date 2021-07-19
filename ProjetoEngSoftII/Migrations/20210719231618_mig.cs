using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjetoEngSoftII.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cep = table.Column<string>(type: "text", nullable: true),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<string>(type: "text", nullable: true),
                    cidade = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marca_vacina_covid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca_vacina_covid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vacinador",
                columns: table => new
                {
                    RegistroProfissional = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacinador", x => x.RegistroProfissional);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Cns = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_paciente_endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carteira_vacinacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteCpf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carteira_vacinacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carteira_vacinacao_paciente_PacienteCpf",
                        column: x => x.PacienteCpf,
                        principalTable: "paciente",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacinado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteCpf = table.Column<string>(type: "text", nullable: true),
                    DataVacinacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataPrevisaoSegundaDose = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MarcaVacinaCovidId = table.Column<long>(type: "bigint", nullable: false),
                    Dose = table.Column<string>(type: "text", nullable: true),
                    Lote = table.Column<string>(type: "text", nullable: true),
                    VacinadorRegistroProfissional = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacinado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vacinado_marca_vacina_covid_MarcaVacinaCovidId",
                        column: x => x.MarcaVacinaCovidId,
                        principalTable: "marca_vacina_covid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vacinado_paciente_PacienteCpf",
                        column: x => x.PacienteCpf,
                        principalTable: "paciente",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vacinado_vacinador_VacinadorRegistroProfissional",
                        column: x => x.VacinadorRegistroProfissional,
                        principalTable: "vacinador",
                        principalColumn: "RegistroProfissional",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carteira_vacinacao_PacienteCpf",
                table: "carteira_vacinacao",
                column: "PacienteCpf");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_EnderecoId",
                table: "paciente",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacinado_MarcaVacinaCovidId",
                table: "vacinado",
                column: "MarcaVacinaCovidId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacinado_PacienteCpf",
                table: "vacinado",
                column: "PacienteCpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacinado_VacinadorRegistroProfissional",
                table: "vacinado",
                column: "VacinadorRegistroProfissional",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carteira_vacinacao");

            migrationBuilder.DropTable(
                name: "vacinado");

            migrationBuilder.DropTable(
                name: "marca_vacina_covid");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "vacinador");

            migrationBuilder.DropTable(
                name: "endereco");
        }
    }
}

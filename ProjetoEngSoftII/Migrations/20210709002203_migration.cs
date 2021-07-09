using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjetoEngSoftII.Migrations
{
    public partial class migration : Migration
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
                    marca = table.Column<string>(type: "text", nullable: true),
                    tipo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca_vacina_covid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vacina",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    cpf = table.Column<string>(type: "text", nullable: false),
                    cns = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rg = table.Column<string>(type: "text", nullable: true),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.cpf);
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
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacinado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteCpf = table.Column<string>(type: "text", nullable: true),
                    data_vacinacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MarcaVacinaCovidId = table.Column<long>(type: "bigint", nullable: false),
                    dose = table.Column<string>(type: "text", nullable: true)
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
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Restrict);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carteira_vacinacao");

            migrationBuilder.DropTable(
                name: "vacina");

            migrationBuilder.DropTable(
                name: "vacinado");

            migrationBuilder.DropTable(
                name: "marca_vacina_covid");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "endereco");
        }
    }
}

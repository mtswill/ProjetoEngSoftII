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
                name: "carteira_vacinacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carteira_vacinacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    cep = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<string>(type: "text", nullable: false),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    cidade = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => new { x.cep, x.numero });
                });

            migrationBuilder.CreateTable(
                name: "vacina",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    CarteiraVacinacaoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacina", x => x.id);
                    table.ForeignKey(
                        name: "FK_vacina_carteira_vacinacao_CarteiraVacinacaoId",
                        column: x => x.CarteiraVacinacaoId,
                        principalTable: "carteira_vacinacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cns = table.Column<string>(type: "text", nullable: true),
                    CarteiraVacinacaoId = table.Column<int>(type: "integer", nullable: true),
                    nome = table.Column<string>(type: "text", nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    rg = table.Column<string>(type: "text", nullable: true),
                    EnderecoCep = table.Column<string>(type: "text", nullable: true),
                    EnderecoNumero = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.id);
                    table.ForeignKey(
                        name: "FK_paciente_carteira_vacinacao_CarteiraVacinacaoId",
                        column: x => x.CarteiraVacinacaoId,
                        principalTable: "carteira_vacinacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_paciente_endereco_EnderecoCep_EnderecoNumero",
                        columns: x => new { x.EnderecoCep, x.EnderecoNumero },
                        principalTable: "endereco",
                        principalColumns: new[] { "cep", "numero" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paciente_CarteiraVacinacaoId",
                table: "paciente",
                column: "CarteiraVacinacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_paciente_EnderecoCep_EnderecoNumero",
                table: "paciente",
                columns: new[] { "EnderecoCep", "EnderecoNumero" });

            migrationBuilder.CreateIndex(
                name: "IX_vacina_CarteiraVacinacaoId",
                table: "vacina",
                column: "CarteiraVacinacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "vacina");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "carteira_vacinacao");
        }
    }
}

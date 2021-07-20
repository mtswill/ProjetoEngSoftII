using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEngSoftII.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vacinado_MarcaVacinaCovidId",
                table: "vacinado");

            migrationBuilder.DropIndex(
                name: "IX_vacinado_PacienteCpf",
                table: "vacinado");

            migrationBuilder.DropIndex(
                name: "IX_vacinado_VacinadorRegistroProfissional",
                table: "vacinado");

            migrationBuilder.CreateIndex(
                name: "IX_vacinado_MarcaVacinaCovidId",
                table: "vacinado",
                column: "MarcaVacinaCovidId");

            migrationBuilder.CreateIndex(
                name: "IX_vacinado_PacienteCpf",
                table: "vacinado",
                column: "PacienteCpf");

            migrationBuilder.CreateIndex(
                name: "IX_vacinado_VacinadorRegistroProfissional",
                table: "vacinado",
                column: "VacinadorRegistroProfissional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vacinado_MarcaVacinaCovidId",
                table: "vacinado");

            migrationBuilder.DropIndex(
                name: "IX_vacinado_PacienteCpf",
                table: "vacinado");

            migrationBuilder.DropIndex(
                name: "IX_vacinado_VacinadorRegistroProfissional",
                table: "vacinado");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEngSoftII.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPrevisaoSegundaDose",
                table: "vacinado",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiasParaSegundaDose",
                table: "marca_vacina_covid",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiasParaSegundaDose",
                table: "marca_vacina_covid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPrevisaoSegundaDose",
                table: "vacinado",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}

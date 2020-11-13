using Microsoft.EntityFrameworkCore.Migrations;

namespace PortafolioWebAdministracion.Migrations
{
    public partial class CampoUnidadTiempo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duracion",
                table: "Certificacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UnidadTiempo",
                table: "Certificacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnidadTiempo",
                table: "Certificacion");

            migrationBuilder.AlterColumn<string>(
                name: "Duracion",
                table: "Certificacion",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

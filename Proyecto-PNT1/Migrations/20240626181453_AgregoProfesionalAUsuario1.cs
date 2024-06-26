using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class AgregoProfesionalAUsuario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Experiencia",
                table: "Usuarios",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profesion",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experiencia",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Profesion",
                table: "Usuarios");
        }
    }
}

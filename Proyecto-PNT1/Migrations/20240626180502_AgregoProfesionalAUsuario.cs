using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class AgregoProfesionalAUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsProfesional",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsProfesional",
                table: "Usuarios");
        }
    }
}

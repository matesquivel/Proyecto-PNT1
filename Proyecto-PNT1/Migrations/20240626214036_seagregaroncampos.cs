using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class seagregaroncampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Remuneracion",
                table: "Propuestas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Propuestas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remuneracion",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Propuestas");
        }
    }
}

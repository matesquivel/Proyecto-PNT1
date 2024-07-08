using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_PNT1.Migrations
{
    public partial class SeAgregaValidacionesPostulaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreadorId",
                table: "Propuestas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(nullable: false),
                    ProfesionalId = table.Column<int>(nullable: false),
                    FechaContacto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactos_Usuarios_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contactos_Usuarios_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_EmpresaId",
                table: "Contactos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ProfesionalId",
                table: "Contactos",
                column: "ProfesionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Propuestas");
        }
    }
}

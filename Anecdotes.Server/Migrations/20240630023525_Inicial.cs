/*PASO 6 => GENERAMOS LA PRIMER MIGRACION A LA BASE DE DATOS:

		* VAMOS A "TOOLS" -> "NUGET PACKAGE MANAGER" -> "PACKAGE MANAGER CONSOLE":
			
							+ Add Migration nombre_para_esa_migracion
							+ Update-database (para enviar cambios a en este caso SQLSERVER, esto creara los campos del MODELO como columnas en la base de datos) */


using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anecdotes.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioRegistrado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRegistrado", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRegistrado");
        }
    }
}

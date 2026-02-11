using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoM.Migrations
{
    /// <inheritdoc />
    public partial class Uno_muchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasificacionId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clasificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificaciones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ClasificacionId",
                table: "Productos",
                column: "ClasificacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Clasificaciones_ClasificacionId",
                table: "Productos",
                column: "ClasificacionId",
                principalTable: "Clasificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Clasificaciones_ClasificacionId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Clasificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ClasificacionId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ClasificacionId",
                table: "Productos");
        }
    }
}

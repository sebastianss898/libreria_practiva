using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionBibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class Correcciontablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Libro_LibroId",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Miembro_MiembroId",
                table: "Prestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prestamo",
                table: "Prestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miembro",
                table: "Miembro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libro",
                table: "Libro");

            migrationBuilder.RenameTable(
                name: "Prestamo",
                newName: "Prestamos");

            migrationBuilder.RenameTable(
                name: "Miembro",
                newName: "Miembros");

            migrationBuilder.RenameTable(
                name: "Libro",
                newName: "Libros");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_MiembroId",
                table: "Prestamos",
                newName: "IX_Prestamos_MiembroId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_LibroId",
                table: "Prestamos",
                newName: "IX_Prestamos_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prestamos",
                table: "Prestamos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miembros",
                table: "Miembros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libros",
                table: "Libros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Libros_LibroId",
                table: "Prestamos",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Miembros_MiembroId",
                table: "Prestamos",
                column: "MiembroId",
                principalTable: "Miembros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Libros_LibroId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Miembros_MiembroId",
                table: "Prestamos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prestamos",
                table: "Prestamos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miembros",
                table: "Miembros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libros",
                table: "Libros");

            migrationBuilder.RenameTable(
                name: "Prestamos",
                newName: "Prestamo");

            migrationBuilder.RenameTable(
                name: "Miembros",
                newName: "Miembro");

            migrationBuilder.RenameTable(
                name: "Libros",
                newName: "Libro");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_MiembroId",
                table: "Prestamo",
                newName: "IX_Prestamo_MiembroId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_LibroId",
                table: "Prestamo",
                newName: "IX_Prestamo_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prestamo",
                table: "Prestamo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miembro",
                table: "Miembro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libro",
                table: "Libro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Libro_LibroId",
                table: "Prestamo",
                column: "LibroId",
                principalTable: "Libro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Miembro_MiembroId",
                table: "Prestamo",
                column: "MiembroId",
                principalTable: "Miembro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

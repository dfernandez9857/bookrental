using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookrental.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClientLoanForeignRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_prestamo_ejemplar",
                table: "detalle_prestamo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "prestamo",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "lista_negra_cliente",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "detalle_prestamo",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cliente",
                newName: "id");

            migrationBuilder.CreateIndex(
                name: "IX_prestamo_cliente_id",
                table: "prestamo",
                column: "cliente_id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_prestamo_ejemplar_ejemplar_id",
                table: "detalle_prestamo",
                column: "ejemplar_id",
                principalTable: "ejemplar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_prestamo_cliente_cliente_id",
                table: "prestamo",
                column: "cliente_id",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_prestamo_ejemplar_ejemplar_id",
                table: "detalle_prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_prestamo_cliente_cliente_id",
                table: "prestamo");

            migrationBuilder.DropIndex(
                name: "IX_prestamo_cliente_id",
                table: "prestamo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "prestamo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "lista_negra_cliente",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "detalle_prestamo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cliente",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_prestamo_ejemplar",
                table: "detalle_prestamo",
                column: "ejemplar_id",
                principalTable: "ejemplar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

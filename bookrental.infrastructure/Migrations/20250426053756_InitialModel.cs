using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookrental.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    documento_identidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ejemplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    habilitado_prestamo = table.Column<bool>(type: "bit", nullable: false),
                    estado_ejemplar_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ejemplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    fecha_prestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_devolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_devolver = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado_prestamo_id = table.Column<int>(type: "int", nullable: false),
                    usuario_registra_prestamo = table.Column<int>(type: "int", nullable: false),
                    canal_prestamo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lista_negra_cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lista_negra_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lista_negra_cliente_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prestamo_id = table.Column<int>(type: "int", nullable: false),
                    ejemplar_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_prestamo_ejemplar",
                        column: x => x.ejemplar_id,
                        principalTable: "ejemplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalle_prestamo_prestamo_prestamo_id",
                        column: x => x.prestamo_id,
                        principalTable: "prestamo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalle_prestamo_ejemplar_id",
                table: "detalle_prestamo",
                column: "ejemplar_id");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_prestamo_prestamo_id",
                table: "detalle_prestamo",
                column: "prestamo_id");

            migrationBuilder.CreateIndex(
                name: "IX_lista_negra_cliente_cliente_id",
                table: "lista_negra_cliente",
                column: "cliente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_prestamo");

            migrationBuilder.DropTable(
                name: "lista_negra_cliente");

            migrationBuilder.DropTable(
                name: "ejemplar");

            migrationBuilder.DropTable(
                name: "prestamo");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}

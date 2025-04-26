using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookrental.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookCopy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
             .Sql("INSERT INTO ejemplar(habilitado_prestamo, estado_ejemplar_id) VALUES(1, 1);");
            migrationBuilder
              .Sql("INSERT INTO ejemplar(habilitado_prestamo, estado_ejemplar_id) VALUES(1, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

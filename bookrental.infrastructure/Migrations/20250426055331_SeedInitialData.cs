using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookrental.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
              .Sql("INSERT INTO cliente(nombres, apellidos, documento_identidad) VALUES('Franco Diego', 'Fernandez Cruz', '48358399');");
            migrationBuilder
               .Sql("INSERT INTO cliente(nombres, apellidos, documento_identidad) VALUES('Manuel', 'Neuer', '234345');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

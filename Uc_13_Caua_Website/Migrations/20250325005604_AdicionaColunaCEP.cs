using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uc_13_Caua_Website.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaColunaCEP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Cliente",
                newName: "CPF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Cliente",
                newName: "CNPJ");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    public partial class RenameEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereço",
                table: "EnderecoEntrega",
                newName: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "EnderecoEntrega",
                newName: "Endereço");
        }
    }
}

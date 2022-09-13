using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Pokemon",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pokemon",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pokemon",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pokemon",
                newName: "id");
        }
    }
}

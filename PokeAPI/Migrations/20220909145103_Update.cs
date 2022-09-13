using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Sprites_SpriteId",
                table: "Pokemon");

            migrationBuilder.RenameColumn(
                name: "SpriteId",
                table: "Pokemon",
                newName: "SpritesId");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemon_SpriteId",
                table: "Pokemon",
                newName: "IX_Pokemon_SpritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Sprites_SpritesId",
                table: "Pokemon",
                column: "SpritesId",
                principalTable: "Sprites",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Sprites_SpritesId",
                table: "Pokemon");

            migrationBuilder.RenameColumn(
                name: "SpritesId",
                table: "Pokemon",
                newName: "SpriteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pokemon_SpritesId",
                table: "Pokemon",
                newName: "IX_Pokemon_SpriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Sprites_SpriteId",
                table: "Pokemon",
                column: "SpriteId",
                principalTable: "Sprites",
                principalColumn: "Id");
        }
    }
}

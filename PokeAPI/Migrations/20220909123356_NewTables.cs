using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpriteId",
                table: "Pokemon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sprites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontDefault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontShiny = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    TypeNameId = table.Column<int>(type: "int", nullable: true),
                    PokemonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Types_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Types_TypeNames_TypeNameId",
                        column: x => x.TypeNameId,
                        principalTable: "TypeNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpriteId",
                table: "Pokemon",
                column: "SpriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_PokemonId",
                table: "Types",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_TypeNameId",
                table: "Types",
                column: "TypeNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Sprites_SpriteId",
                table: "Pokemon",
                column: "SpriteId",
                principalTable: "Sprites",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Sprites_SpriteId",
                table: "Pokemon");

            migrationBuilder.DropTable(
                name: "Sprites");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "TypeNames");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpriteId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "SpriteId",
                table: "Pokemon");
        }
    }
}

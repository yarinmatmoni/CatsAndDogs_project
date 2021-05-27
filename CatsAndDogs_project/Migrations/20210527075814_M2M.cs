using Microsoft.EntityFrameworkCore.Migrations;

namespace CatsAndDogs_project.Migrations
{
    public partial class M2M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogBreed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogBreedDogs",
                columns: table => new
                {
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    DogsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreedDogs", x => new { x.BreedId, x.DogsId });
                    table.ForeignKey(
                        name: "FK_DogBreedDogs_DogBreed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "DogBreed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogBreedDogs_Dogs_DogsId",
                        column: x => x.DogsId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogBreedDogs_DogsId",
                table: "DogBreedDogs",
                column: "DogsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogBreedDogs");

            migrationBuilder.DropTable(
                name: "DogBreed");
        }
    }
}

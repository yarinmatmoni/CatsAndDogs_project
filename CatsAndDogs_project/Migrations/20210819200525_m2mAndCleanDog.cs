using Microsoft.EntityFrameworkCore.Migrations;

namespace CatsAndDogs_project.Migrations
{
    public partial class m2mAndCleanDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogBreedsDogs");

            migrationBuilder.DropTable(
                name: "DogBreeds");

            migrationBuilder.DropTable(
                name: "Dogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogBreeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeExpectancy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Match = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogBreedsDogs",
                columns: table => new
                {
                    BreedsId = table.Column<int>(type: "int", nullable: false),
                    DogsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreedsDogs", x => new { x.BreedsId, x.DogsId });
                    table.ForeignKey(
                        name: "FK_DogBreedsDogs_DogBreeds_BreedsId",
                        column: x => x.BreedsId,
                        principalTable: "DogBreeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogBreedsDogs_Dogs_DogsId",
                        column: x => x.DogsId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogBreedsDogs_DogsId",
                table: "DogBreedsDogs",
                column: "DogsId");
        }
    }
}

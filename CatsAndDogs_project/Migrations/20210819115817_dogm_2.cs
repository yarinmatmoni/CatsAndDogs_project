using Microsoft.EntityFrameworkCore.Migrations;

namespace CatsAndDogs_project.Migrations
{
    public partial class dogm_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breed_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed_2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dog_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeExpectancy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Match = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog_2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breed_2Dog_2",
                columns: table => new
                {
                    ListBreedId = table.Column<int>(type: "int", nullable: false),
                    ListDogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed_2Dog_2", x => new { x.ListBreedId, x.ListDogId });
                    table.ForeignKey(
                        name: "FK_Breed_2Dog_2_Breed_2_ListBreedId",
                        column: x => x.ListBreedId,
                        principalTable: "Breed_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Breed_2Dog_2_Dog_2_ListDogId",
                        column: x => x.ListDogId,
                        principalTable: "Dog_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breed_2Dog_2_ListDogId",
                table: "Breed_2Dog_2",
                column: "ListDogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breed_2Dog_2");

            migrationBuilder.DropTable(
                name: "Breed_2");

            migrationBuilder.DropTable(
                name: "Dog_2");
        }
    }
}

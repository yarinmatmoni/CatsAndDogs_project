using Microsoft.EntityFrameworkCore.Migrations;

namespace CatsAndDogs_project.Migrations
{
    public partial class cat_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedCat_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCat_2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cat_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeExpectancy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreedCat_2Cat_2",
                columns: table => new
                {
                    BreedCatListId = table.Column<int>(type: "int", nullable: false),
                    CatListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCat_2Cat_2", x => new { x.BreedCatListId, x.CatListId });
                    table.ForeignKey(
                        name: "FK_BreedCat_2Cat_2_BreedCat_2_BreedCatListId",
                        column: x => x.BreedCatListId,
                        principalTable: "BreedCat_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedCat_2Cat_2_Cat_2_CatListId",
                        column: x => x.CatListId,
                        principalTable: "Cat_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedCat_2Cat_2_CatListId",
                table: "BreedCat_2Cat_2",
                column: "CatListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedCat_2Cat_2");

            migrationBuilder.DropTable(
                name: "BreedCat_2");

            migrationBuilder.DropTable(
                name: "Cat_2");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CatsAndDogs_project.Migrations
{
    public partial class guidedog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuideDog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageGuied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed_2Id = table.Column<int>(type: "int", nullable: false),
                    AvgLife = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AvgWeight = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AvgHeight = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Training = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideDog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuideDog_Breed_2_Breed_2Id",
                        column: x => x.Breed_2Id,
                        principalTable: "Breed_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuideDog_Breed_2Id",
                table: "GuideDog",
                column: "Breed_2Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuideDog");
        }
    }
}

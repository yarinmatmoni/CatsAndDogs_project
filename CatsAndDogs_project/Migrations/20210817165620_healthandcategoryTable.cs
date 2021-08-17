using Microsoft.EntityFrameworkCore.Migrations;

namespace CatsAndDogs_project.Migrations
{
    public partial class healthandcategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Health",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HealthCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Health_CategoryId",
                table: "Health",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Health_HealthCategory_CategoryId",
                table: "Health",
                column: "CategoryId",
                principalTable: "HealthCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Health_HealthCategory_CategoryId",
                table: "Health");

            migrationBuilder.DropTable(
                name: "HealthCategory");

            migrationBuilder.DropIndex(
                name: "IX_Health_CategoryId",
                table: "Health");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Health");
        }
    }
}

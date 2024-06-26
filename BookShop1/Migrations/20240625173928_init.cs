using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookId1",
                table: "Review",
                column: "BookId1",
                unique: true,
                filter: "[BookId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Book_BookId1",
                table: "Review",
                column: "BookId1",
                principalTable: "Book",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Book_BookId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_BookId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Review");
        }
    }
}

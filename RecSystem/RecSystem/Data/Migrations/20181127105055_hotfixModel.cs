using Microsoft.EntityFrameworkCore.Migrations;

namespace RecSystem.Data.Migrations
{
    public partial class hotfixModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_CustomerId1",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CustomerId1",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Ratings");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AspNetUsersId",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerId",
                table: "Ratings",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_CustomerId",
                table: "Ratings",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_CustomerId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_CustomerId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Ratings");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "Ratings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerId1",
                table: "Ratings",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_CustomerId1",
                table: "Ratings",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

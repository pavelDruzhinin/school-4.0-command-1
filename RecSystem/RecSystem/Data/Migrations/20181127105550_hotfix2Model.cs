using Microsoft.EntityFrameworkCore.Migrations;

namespace RecSystem.Data.Migrations
{
    public partial class hotfix2Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Ratings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspNetUsersId",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);
        }
    }
}

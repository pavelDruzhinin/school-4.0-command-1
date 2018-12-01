using Microsoft.EntityFrameworkCore.Migrations;

namespace RecSystem.Data.Migrations
{
    public partial class urlItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Items");
        }
    }
}

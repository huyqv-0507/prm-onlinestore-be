using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addIsSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "isSold",
                table: "Shoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSold",
                table: "Shoes");
        }
    }
}

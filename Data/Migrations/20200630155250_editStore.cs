using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Stores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Username",
                table: "Stores",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);
        }
    }
}

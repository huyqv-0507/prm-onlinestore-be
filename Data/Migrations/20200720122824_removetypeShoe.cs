using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class removetypeShoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Shoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Shoes",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}

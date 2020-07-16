using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editUser02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

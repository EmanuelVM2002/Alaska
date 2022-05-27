using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alaska.Web.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCity",
                table: "Restaurant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCity",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

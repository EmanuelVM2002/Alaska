using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alaska.Web.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Restaurant_Id",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_City_Id",
                table: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_NomRestaurante",
                table: "Restaurant",
                column: "NomRestaurante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_NomCiudad",
                table: "City",
                column: "NomCiudad",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Restaurant_NomRestaurante",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_City_NomCiudad",
                table: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Id",
                table: "Restaurant",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_Id",
                table: "City",
                column: "Id",
                unique: true);
        }
    }
}

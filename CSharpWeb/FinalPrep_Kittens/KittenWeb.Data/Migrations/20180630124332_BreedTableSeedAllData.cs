using Microsoft.EntityFrameworkCore.Migrations;

namespace KittenWeb.Data.Migrations
{
    public partial class BreedTableSeedAllData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "ImageUrl", "Type" },
                values: new object[,]
                {
                    { 1, "/Images/street-transcended.jpg", "Street Transcended" },
                    { 2, "/Images/american-shorthair.jpg", "American Shorthair" },
                    { 3, "/Images/munchkin.jpg", "Munchkin" },
                    { 4, "/Images/siamese.jpg", "Siamese" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

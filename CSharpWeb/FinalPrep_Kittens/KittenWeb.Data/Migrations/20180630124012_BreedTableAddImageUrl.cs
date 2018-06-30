using Microsoft.EntityFrameworkCore.Migrations;

namespace KittenWeb.Data.Migrations
{
    public partial class BreedTableAddImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Breeds",
                maxLength: 512,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Breeds");

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Street Transcended" },
                    { 2, "American Shorthair" },
                    { 3, "Munchkin" },
                    { 4, "Siamese" }
                });
        }
    }
}

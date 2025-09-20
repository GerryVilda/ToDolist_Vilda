using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDolist_Vilda.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RecipeTitles",
                columns: new[] { "Id", "TitleName" },
                values: new object[] { 1, "Pancakes" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Instructions", "RecipeTitleId" },
                values: new object[] { 1, "Mix ingredients and fry.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Measure", "Name", "RecipeId", "UnitOfMeasure" },
                values: new object[,]
                {
                    { 1, 2.0, "Flour", 1, "cups" },
                    { 2, 1.5, "Milk", 1, "cups" },
                    { 3, 2.0, "Eggs", 1, "pcs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeTitles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

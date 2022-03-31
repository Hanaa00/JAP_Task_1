using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class seedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "CategoryId", "Description", "RecipeName", "RecipePhoto" },
                values: new object[] { 1, 1, "Pizza sa sirom", "Margerita", null });

            migrationBuilder.InsertData(
                table: "RecipeDetails",
                columns: new[] { "IngredientsId", "RecipeId", "MesureUnit", "Quantity" },
                values: new object[] { 1, 1, 1, 150f });

            migrationBuilder.InsertData(
                table: "RecipeDetails",
                columns: new[] { "IngredientsId", "RecipeId", "MesureUnit", "Quantity" },
                values: new object[] { 2, 1, 2, 20f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumns: new[] { "IngredientsId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumns: new[] { "IngredientsId", "RecipeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

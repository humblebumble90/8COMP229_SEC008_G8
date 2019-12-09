using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Migrations
{
    public partial class review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Recipes_RecipeId",
                table: "Reviews",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Recipes_RecipeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Reviews");
        }
    }
}

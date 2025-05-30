using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "Foods",
                newName: "FoodTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodTypeID",
                table: "Foods",
                column: "FoodTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodTypes_FoodTypeID",
                table: "Foods",
                column: "FoodTypeID",
                principalTable: "FoodTypes",
                principalColumn: "FoodTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodTypes_FoodTypeID",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FoodTypeID",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "FoodTypeID",
                table: "Foods",
                newName: "TypeID");
        }
    }
}

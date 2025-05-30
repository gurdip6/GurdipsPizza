using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountID",
                table: "Orders",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_AccountID",
                table: "Orders",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_AccountID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Orders");
        }
    }
}

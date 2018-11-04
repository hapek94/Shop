using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class DiscountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_DiscountId",
                table: "Items",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Discounts_DiscountId",
                table: "Items",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Discounts_DiscountId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_DiscountId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Items");
        }
    }
}

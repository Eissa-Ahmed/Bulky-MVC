using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Prouducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prouducts_CategoryId",
                table: "Prouducts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prouducts_Categories_CategoryId",
                table: "Prouducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prouducts_Categories_CategoryId",
                table: "Prouducts");

            migrationBuilder.DropIndex(
                name: "IX_Prouducts_CategoryId",
                table: "Prouducts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Prouducts");
        }
    }
}

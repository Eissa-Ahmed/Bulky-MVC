﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Prouducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Prouducts");
        }
    }
}

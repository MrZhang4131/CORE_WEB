using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Web.Migrations
{
    /// <inheritdoc />
    public partial class Update3173 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Login",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Login",
                table: "PublishingHouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Login",
                table: "AuthorCount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Last_Login",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Last_Login",
                table: "PublishingHouse");

            migrationBuilder.DropColumn(
                name: "Last_Login",
                table: "AuthorCount");
        }
    }
}

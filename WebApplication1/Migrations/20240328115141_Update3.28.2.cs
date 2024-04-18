using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Web.Migrations
{
    /// <inheritdoc />
    public partial class Update3282 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookID",
                table: "BookList");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "BookList",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookName",
                table: "BookList");

            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "BookList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

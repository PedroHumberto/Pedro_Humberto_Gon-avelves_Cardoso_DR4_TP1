using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amigos.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Friends");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Friends",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

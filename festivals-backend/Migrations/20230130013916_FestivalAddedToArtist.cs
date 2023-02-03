using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace festivals.Migrations
{
    /// <inheritdoc />
    public partial class FestivalAddedToArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Festivals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Artists",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Festivals",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artists",
                newName: "id");
        }
    }
}

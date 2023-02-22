using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish._01.Migrations
{
    /// <inheritdoc />
    public partial class NewCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Contributor_ContributorID",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_ContributorID",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "ContributorID",
                table: "Song");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContributorID",
                table: "Song",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Song_ContributorID",
                table: "Song",
                column: "ContributorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Contributor_ContributorID",
                table: "Song",
                column: "ContributorID",
                principalTable: "Contributor",
                principalColumn: "ID");
        }
    }
}

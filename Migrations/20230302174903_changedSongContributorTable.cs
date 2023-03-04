using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish._01.Migrations
{
    /// <inheritdoc />
    public partial class changedSongContributorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongContributor_Contributor_ContributorID",
                table: "SongContributor");

            migrationBuilder.DropForeignKey(
                name: "FK_SongContributor_Song_SongID",
                table: "SongContributor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongContributor",
                table: "SongContributor");

            migrationBuilder.DropIndex(
                name: "IX_SongContributor_SongID",
                table: "SongContributor");

            migrationBuilder.RenameTable(
                name: "SongContributor",
                newName: "SongContributors");

            migrationBuilder.RenameIndex(
                name: "IX_SongContributor_ContributorID",
                table: "SongContributors",
                newName: "IX_SongContributors_ContributorID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SongContributors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongContributors",
                table: "SongContributors",
                columns: new[] { "SongID", "ContributorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SongContributors_Contributor_ContributorID",
                table: "SongContributors",
                column: "ContributorID",
                principalTable: "Contributor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongContributors_Song_SongID",
                table: "SongContributors",
                column: "SongID",
                principalTable: "Song",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongContributors_Contributor_ContributorID",
                table: "SongContributors");

            migrationBuilder.DropForeignKey(
                name: "FK_SongContributors_Song_SongID",
                table: "SongContributors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongContributors",
                table: "SongContributors");

            migrationBuilder.RenameTable(
                name: "SongContributors",
                newName: "SongContributor");

            migrationBuilder.RenameIndex(
                name: "IX_SongContributors_ContributorID",
                table: "SongContributor",
                newName: "IX_SongContributor_ContributorID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "SongContributor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongContributor",
                table: "SongContributor",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SongContributor_SongID",
                table: "SongContributor",
                column: "SongID");

            migrationBuilder.AddForeignKey(
                name: "FK_SongContributor_Contributor_ContributorID",
                table: "SongContributor",
                column: "ContributorID",
                principalTable: "Contributor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongContributor_Song_SongID",
                table: "SongContributor",
                column: "SongID",
                principalTable: "Song",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

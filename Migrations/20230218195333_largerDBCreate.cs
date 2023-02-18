using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish._01.Migrations
{
    /// <inheritdoc />
    public partial class largerDBCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongGenre");

            migrationBuilder.AddColumn<int>(
                name: "ContributorID",
                table: "Song",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "int", nullable: false),
                    SongsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresID, x.SongsID });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genre_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Song_SongsID",
                        column: x => x.SongsID,
                        principalTable: "Song",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_ContributorID",
                table: "Song",
                column: "ContributorID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsID",
                table: "GenreSong",
                column: "SongsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Contributor_ContributorID",
                table: "Song",
                column: "ContributorID",
                principalTable: "Contributor",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Contributor_ContributorID",
                table: "Song");

            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropIndex(
                name: "IX_Song_ContributorID",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "ContributorID",
                table: "Song");

            migrationBuilder.CreateTable(
                name: "SongGenre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SongGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongGenre_Song_SongID",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongGenre_GenreID",
                table: "SongGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenre_SongID",
                table: "SongGenre",
                column: "SongID");
        }
    }
}

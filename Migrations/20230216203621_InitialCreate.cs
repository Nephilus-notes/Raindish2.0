using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raindish._01.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contributor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pedal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeySignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionRecording = table.Column<bool>(type: "bit", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    WrittenOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TabsLyricsURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioFileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Song_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SongContributor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongID = table.Column<int>(type: "int", nullable: false),
                    ContributorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongContributor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SongContributor_Contributor_ContributorID",
                        column: x => x.ContributorID,
                        principalTable: "Contributor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongContributor_Song_SongID",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongGenre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "SongPedal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongID = table.Column<int>(type: "int", nullable: false),
                    PedalID = table.Column<int>(type: "int", nullable: false),
                    AlternativeTabURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternativeAudioURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongPedal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SongPedal_Pedal_PedalID",
                        column: x => x.PedalID,
                        principalTable: "Pedal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongPedal_Song_SongID",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_UserId",
                table: "Song",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SongContributor_ContributorID",
                table: "SongContributor",
                column: "ContributorID");

            migrationBuilder.CreateIndex(
                name: "IX_SongContributor_SongID",
                table: "SongContributor",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenre_GenreID",
                table: "SongGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenre_SongID",
                table: "SongGenre",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_SongPedal_PedalID",
                table: "SongPedal",
                column: "PedalID");

            migrationBuilder.CreateIndex(
                name: "IX_SongPedal_SongID",
                table: "SongPedal",
                column: "SongID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongContributor");

            migrationBuilder.DropTable(
                name: "SongGenre");

            migrationBuilder.DropTable(
                name: "SongPedal");

            migrationBuilder.DropTable(
                name: "Contributor");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Pedal");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace HansJhonnyAPI.Migrations
{
    public partial class AddedMinutesAndSecondsInDataModelSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "SongLength",
                table: "Song");

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seconds",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Seconds",
                table: "Song");

            migrationBuilder.AddColumn<string>(
                name: "SongLength",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

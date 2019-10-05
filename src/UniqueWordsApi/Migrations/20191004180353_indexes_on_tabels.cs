using Microsoft.EntityFrameworkCore.Migrations;

namespace UniqueWordsApi.Migrations
{
    public partial class indexes_on_tabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WatchlistWords_Word",
                table: "WatchlistWords");

            migrationBuilder.DropIndex(
                name: "IX_RecordedWords_Word",
                table: "RecordedWords");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistWords_Word",
                table: "WatchlistWords",
                column: "Word",
                unique: true,
                filter: "[Word] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecordedWords_Word",
                table: "RecordedWords",
                column: "Word",
                unique: true,
                filter: "[Word] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WatchlistWords_Word",
                table: "WatchlistWords");

            migrationBuilder.DropIndex(
                name: "IX_RecordedWords_Word",
                table: "RecordedWords");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistWords_Word",
                table: "WatchlistWords",
                column: "Word");

            migrationBuilder.CreateIndex(
                name: "IX_RecordedWords_Word",
                table: "RecordedWords",
                column: "Word");
        }
    }
}

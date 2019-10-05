using Microsoft.EntityFrameworkCore.Migrations;

namespace UniqueWordsApi.Migrations
{
    public partial class BasseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecordedWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordedWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchlistWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistWords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordedWords_Word",
                table: "RecordedWords",
                column: "Word");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistWords_Word",
                table: "WatchlistWords",
                column: "Word");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordedWords");

            migrationBuilder.DropTable(
                name: "WatchlistWords");
        }
    }
}

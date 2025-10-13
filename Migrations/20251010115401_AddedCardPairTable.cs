using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryGame.Migrations
{
    /// <inheritdoc />
    public partial class AddedCardPairTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PairEntity",
                columns: table => new
                {
                    PairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairEntity", x => x.PairId);
                });

            migrationBuilder.CreateTable(
                name: "CardEntity",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    IsMatched = table.Column<bool>(type: "bit", nullable: false),
                    PairId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardEntity", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_CardEntity_PairEntity_PairId",
                        column: x => x.PairId,
                        principalTable: "PairEntity",
                        principalColumn: "PairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardEntity_PairId",
                table: "CardEntity",
                column: "PairId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardEntity");

            migrationBuilder.DropTable(
                name: "PairEntity");
        }
    }
}

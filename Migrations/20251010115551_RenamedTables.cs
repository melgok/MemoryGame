using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryGame.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardEntity_PairEntity_PairId",
                table: "CardEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PairEntity",
                table: "PairEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardEntity",
                table: "CardEntity");

            migrationBuilder.RenameTable(
                name: "PairEntity",
                newName: "Pairs");

            migrationBuilder.RenameTable(
                name: "CardEntity",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_CardEntity_PairId",
                table: "Cards",
                newName: "IX_Cards_PairId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pairs",
                table: "Pairs",
                column: "PairId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Pairs_PairId",
                table: "Cards",
                column: "PairId",
                principalTable: "Pairs",
                principalColumn: "PairId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Pairs_PairId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pairs",
                table: "Pairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Pairs",
                newName: "PairEntity");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "CardEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_PairId",
                table: "CardEntity",
                newName: "IX_CardEntity_PairId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PairEntity",
                table: "PairEntity",
                column: "PairId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardEntity",
                table: "CardEntity",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardEntity_PairEntity_PairId",
                table: "CardEntity",
                column: "PairId",
                principalTable: "PairEntity",
                principalColumn: "PairId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

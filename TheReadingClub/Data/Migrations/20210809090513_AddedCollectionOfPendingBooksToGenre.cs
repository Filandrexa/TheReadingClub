using Microsoft.EntityFrameworkCore.Migrations;

namespace TheReadingClub.Data.Migrations
{
    public partial class AddedCollectionOfPendingBooksToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_BookPendingApprovals_BookPendingApprovalId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_BookPendingApprovalId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "BookPendingApprovalId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "BookPendingApprovalGenre",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    PendingApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPendingApprovalGenre", x => new { x.GenresId, x.PendingApprovalId });
                    table.ForeignKey(
                        name: "FK_BookPendingApprovalGenre_BookPendingApprovals_PendingApprovalId",
                        column: x => x.PendingApprovalId,
                        principalTable: "BookPendingApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPendingApprovalGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPendingApprovalGenre_PendingApprovalId",
                table: "BookPendingApprovalGenre",
                column: "PendingApprovalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPendingApprovalGenre");

            migrationBuilder.AddColumn<int>(
                name: "BookPendingApprovalId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_BookPendingApprovalId",
                table: "Genres",
                column: "BookPendingApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_BookPendingApprovals_BookPendingApprovalId",
                table: "Genres",
                column: "BookPendingApprovalId",
                principalTable: "BookPendingApprovals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

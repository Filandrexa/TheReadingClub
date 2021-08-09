using Microsoft.EntityFrameworkCore.Migrations;

namespace TheReadingClub.Data.Migrations
{
    public partial class TwoNewEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookPendingApprovalId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorPendingApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPendingApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPendingApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPendingApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPendingApprovals_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_BookPendingApprovalId",
                table: "Genres",
                column: "BookPendingApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPendingApprovals_AuthorId",
                table: "BookPendingApprovals",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_BookPendingApprovals_BookPendingApprovalId",
                table: "Genres",
                column: "BookPendingApprovalId",
                principalTable: "BookPendingApprovals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_BookPendingApprovals_BookPendingApprovalId",
                table: "Genres");

            migrationBuilder.DropTable(
                name: "AuthorPendingApprovals");

            migrationBuilder.DropTable(
                name: "BookPendingApprovals");

            migrationBuilder.DropIndex(
                name: "IX_Genres_BookPendingApprovalId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "BookPendingApprovalId",
                table: "Genres");
        }
    }
}

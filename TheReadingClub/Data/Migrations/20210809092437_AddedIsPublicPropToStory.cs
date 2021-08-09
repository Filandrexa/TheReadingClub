using Microsoft.EntityFrameworkCore.Migrations;

namespace TheReadingClub.Data.Migrations
{
    public partial class AddedIsPublicPropToStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Stories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Stories");
        }
    }
}

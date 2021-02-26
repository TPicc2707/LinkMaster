using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class UpdateSpongebobMemeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "SpongebobMeme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "SpongebobMeme",
                nullable: false,
                defaultValue: 0);
        }
    }
}

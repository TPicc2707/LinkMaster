using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class Update_Spongebob_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpongebobMeme_SpongeBobCharacter_SpongebobCharacterId",
                table: "SpongebobMeme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpongeBobCharacter",
                table: "SpongeBobCharacter");

            migrationBuilder.RenameTable(
                name: "SpongeBobCharacter",
                newName: "SpongebobCharacter");

            migrationBuilder.AddColumn<string>(
                name: "Image_Url",
                table: "SpongebobCharacter",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpongebobCharacter",
                table: "SpongebobCharacter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpongebobMeme_SpongebobCharacter_SpongebobCharacterId",
                table: "SpongebobMeme",
                column: "SpongebobCharacterId",
                principalTable: "SpongebobCharacter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpongebobMeme_SpongebobCharacter_SpongebobCharacterId",
                table: "SpongebobMeme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpongebobCharacter",
                table: "SpongebobCharacter");

            migrationBuilder.DropColumn(
                name: "Image_Url",
                table: "SpongebobCharacter");

            migrationBuilder.RenameTable(
                name: "SpongebobCharacter",
                newName: "SpongeBobCharacter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpongeBobCharacter",
                table: "SpongeBobCharacter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpongebobMeme_SpongeBobCharacter_SpongebobCharacterId",
                table: "SpongebobMeme",
                column: "SpongebobCharacterId",
                principalTable: "SpongeBobCharacter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

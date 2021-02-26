using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class Add_Spongebob_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpongeBobCharacter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Created_DateTime = table.Column<DateTime>(nullable: false),
                    Modified_DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpongeBobCharacter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpongebobMeme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Meme_Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: false),
                    Created_DateTime = table.Column<DateTime>(nullable: false),
                    Modified_DateTime = table.Column<DateTime>(nullable: false),
                    SpongebobCharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpongebobMeme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpongebobMeme_SpongeBobCharacter_SpongebobCharacterId",
                        column: x => x.SpongebobCharacterId,
                        principalTable: "SpongeBobCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpongebobMeme_SpongebobCharacterId",
                table: "SpongebobMeme",
                column: "SpongebobCharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpongebobMeme");

            migrationBuilder.DropTable(
                name: "SpongeBobCharacter");
        }
    }
}

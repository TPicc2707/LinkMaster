using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class Create_SpongebobQuotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpongebobQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quote = table.Column<string>(nullable: true),
                    Episode_Number = table.Column<string>(nullable: true),
                    Created_DateTime = table.Column<DateTime>(nullable: false),
                    Modified_DateTime = table.Column<DateTime>(nullable: false),
                    SpongebobCharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpongebobQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpongebobQuotes_SpongebobCharacter_SpongebobCharacterId",
                        column: x => x.SpongebobCharacterId,
                        principalTable: "SpongebobCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpongebobQuotes_SpongebobCharacterId",
                table: "SpongebobQuotes",
                column: "SpongebobCharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpongebobQuotes");
        }
    }
}

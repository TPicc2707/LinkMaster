using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class AllowanceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allowance",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    AllowanceRemaining = table.Column<double>(nullable: false),
                    IsAllowanceRemainingPositive = table.Column<bool>(nullable: false),
                    StartingAllowance = table.Column<double>(nullable: false),
                    Created_DateTime = table.Column<DateTime>(nullable: true),
                    Modified_DateTime = table.Column<DateTime>(nullable: true),
                    PersonGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Allowance_Person_PersonGuid",
                        column: x => x.PersonGuid,
                        principalTable: "Person",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_PersonGuid",
                table: "Allowance",
                column: "PersonGuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowance");
        }
    }
}

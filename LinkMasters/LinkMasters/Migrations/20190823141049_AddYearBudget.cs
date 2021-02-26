using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class AddYearBudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearBudget",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartedAllowance = table.Column<double>(nullable: false),
                    AllowanceLeft = table.Column<double>(nullable: false),
                    PositiveAllowance = table.Column<bool>(nullable: false),
                    CalendarId = table.Column<int>(nullable: true),
                    PersonGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearBudget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearBudget_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YearBudget_Person_PersonGuid",
                        column: x => x.PersonGuid,
                        principalTable: "Person",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearBudget_CalendarId",
                table: "YearBudget",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_YearBudget_PersonGuid",
                table: "YearBudget",
                column: "PersonGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearBudget");
        }
    }
}

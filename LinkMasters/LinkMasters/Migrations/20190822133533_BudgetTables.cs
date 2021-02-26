using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class BudgetTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonGuid",
                table: "Budget",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budget_PersonGuid",
                table: "Budget",
                column: "PersonGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_Person_PersonGuid",
                table: "Budget",
                column: "PersonGuid",
                principalTable: "Person",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_Person_PersonGuid",
                table: "Budget");

            migrationBuilder.DropIndex(
                name: "IX_Budget_PersonGuid",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "PersonGuid",
                table: "Budget");
        }
    }
}

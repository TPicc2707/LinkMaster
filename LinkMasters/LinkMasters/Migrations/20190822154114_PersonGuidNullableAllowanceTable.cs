using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class PersonGuidNullableAllowanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowance_Person_PersonGuid",
                table: "Allowance");

            migrationBuilder.DropIndex(
                name: "IX_Allowance_PersonGuid",
                table: "Allowance");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonGuid",
                table: "Allowance",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_PersonGuid",
                table: "Allowance",
                column: "PersonGuid",
                unique: true,
                filter: "[PersonGuid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowance_Person_PersonGuid",
                table: "Allowance",
                column: "PersonGuid",
                principalTable: "Person",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowance_Person_PersonGuid",
                table: "Allowance");

            migrationBuilder.DropIndex(
                name: "IX_Allowance_PersonGuid",
                table: "Allowance");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonGuid",
                table: "Allowance",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_PersonGuid",
                table: "Allowance",
                column: "PersonGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Allowance_Person_PersonGuid",
                table: "Allowance",
                column: "PersonGuid",
                principalTable: "Person",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

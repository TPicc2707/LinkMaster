using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class AddNextMonthUpdateAllowanceOnPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastMonthUpdateAllowance",
                table: "Person",
                newName: "NextMonthUpdateAllowance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextMonthUpdateAllowance",
                table: "Person",
                newName: "LastMonthUpdateAllowance");
        }
    }
}

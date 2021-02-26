using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMasters.Migrations
{
    public partial class AddAllowanceSpentToYearBudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AllowanceSpent",
                table: "YearBudget",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowanceSpent",
                table: "YearBudget");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Week4.EntityFrk.EF.Migrations
{
    public partial class PriorityIsActiveFlagAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Priorities",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Priorities");
        }
    }
}

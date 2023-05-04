using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWithAuth.Migrations
{
    public partial class Rename_Attribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AppQuests",
                newName: "IsReady");

            migrationBuilder.RenameColumn(
                name: "done",
                table: "AppPlans",
                newName: "IsReady");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsReady",
                table: "AppQuests",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "IsReady",
                table: "AppPlans",
                newName: "done");
        }
    }
}

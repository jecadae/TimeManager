using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWithAuth.Migrations
{
    public partial class N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPlans_Users_AppUserId",
                table: "AppPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AppUserIcons_AppUserIconsId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "IdentityUser<int>");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AppUserIconsId",
                table: "IdentityUser<int>",
                newName: "IX_IdentityUser<int>_AppUserIconsId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "IdentityUser<int>",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser<int>",
                table: "IdentityUser<int>",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPlans_IdentityUser<int>_AppUserId",
                table: "AppPlans",
                column: "AppUserId",
                principalTable: "IdentityUser<int>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser<int>_AppUserIcons_AppUserIconsId",
                table: "IdentityUser<int>",
                column: "AppUserIconsId",
                principalTable: "AppUserIcons",
                principalColumn: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPlans_IdentityUser<int>_AppUserId",
                table: "AppPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser<int>_AppUserIcons_AppUserIconsId",
                table: "IdentityUser<int>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser<int>",
                table: "IdentityUser<int>");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "IdentityUser<int>");

            migrationBuilder.RenameTable(
                name: "IdentityUser<int>",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUser<int>_AppUserIconsId",
                table: "Users",
                newName: "IX_Users_AppUserIconsId");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPlans_Users_AppUserId",
                table: "AppPlans",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AppUserIcons_AppUserIconsId",
                table: "Users",
                column: "AppUserIconsId",
                principalTable: "AppUserIcons",
                principalColumn: "AppUserId");
        }
    }
}

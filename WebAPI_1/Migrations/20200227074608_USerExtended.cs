using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_1.Migrations
{
    public partial class USerExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImage_User_UserId",
                table: "ProfileImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileImage",
                table: "ProfileImage");

            migrationBuilder.RenameTable(
                name: "ProfileImage",
                newName: "Profileimages");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileImage_UserId",
                table: "Profileimages",
                newName: "IX_Profileimages_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profileimages",
                table: "Profileimages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profileimages_User_UserId",
                table: "Profileimages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profileimages_User_UserId",
                table: "Profileimages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profileimages",
                table: "Profileimages");

            migrationBuilder.RenameTable(
                name: "Profileimages",
                newName: "ProfileImage");

            migrationBuilder.RenameIndex(
                name: "IX_Profileimages_UserId",
                table: "ProfileImage",
                newName: "IX_ProfileImage_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileImage",
                table: "ProfileImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImage_User_UserId",
                table: "ProfileImage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

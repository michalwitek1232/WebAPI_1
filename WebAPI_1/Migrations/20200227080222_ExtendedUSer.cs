using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_1.Migrations
{
    public partial class ExtendedUSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profileimages_User_UserId",
                table: "Profileimages");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Profileimages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profileimages_User_UserId",
                table: "Profileimages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profileimages_User_UserId",
                table: "Profileimages");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Profileimages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Profileimages_User_UserId",
                table: "Profileimages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

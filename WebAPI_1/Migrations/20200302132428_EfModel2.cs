using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_1.Migrations
{
    public partial class EfModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventmodels_User_OwnerId",
                table: "Eventmodels");

            migrationBuilder.DropIndex(
                name: "IX_Eventmodels_OwnerId",
                table: "Eventmodels");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Eventmodels");

            migrationBuilder.AddColumn<string>(
                name: "OwnerUsername",
                table: "Eventmodels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerUsername",
                table: "Eventmodels");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Eventmodels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventmodels_OwnerId",
                table: "Eventmodels",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventmodels_User_OwnerId",
                table: "Eventmodels",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

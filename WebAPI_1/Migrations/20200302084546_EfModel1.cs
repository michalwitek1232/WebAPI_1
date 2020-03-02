using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_1.Migrations
{
    public partial class EfModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Eventmodels");

            migrationBuilder.DropColumn(
                name: "Creator_ID",
                table: "Eventmodels");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Eventmodels");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Eventmodels",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Creator",
                table: "Eventmodels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Creator_ID",
                table: "Eventmodels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Eventmodels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

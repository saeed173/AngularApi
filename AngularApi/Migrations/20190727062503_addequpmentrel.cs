using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApi.Migrations
{
    public partial class addequpmentrel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_equpments_EquipmentName_ID",
                table: "equpments",
                column: "EquipmentName_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_equpments_equpmentNames_EquipmentName_ID",
                table: "equpments",
                column: "EquipmentName_ID",
                principalTable: "equpmentNames",
                principalColumn: "EquipmentName_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equpments_equpmentNames_EquipmentName_ID",
                table: "equpments");

            migrationBuilder.DropIndex(
                name: "IX_equpments_EquipmentName_ID",
                table: "equpments");
        }
    }
}

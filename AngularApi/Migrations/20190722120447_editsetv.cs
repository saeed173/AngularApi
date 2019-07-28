using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApi.Migrations
{
    public partial class editsetv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usagetype",
                table: "sets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "sets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usagetype",
                table: "sets");

            migrationBuilder.DropColumn(
                name: "username",
                table: "sets");
        }
    }
}

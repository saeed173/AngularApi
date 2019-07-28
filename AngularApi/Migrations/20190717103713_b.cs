using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApi.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equpments",
                columns: table => new
                {
                    Equipment_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipmentName_ID = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Pyear = table.Column<string>(maxLength: 10, nullable: true),
                    PurchaseTime = table.Column<string>(maxLength: 10, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TechSpec = table.Column<string>(nullable: true),
                    Usage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equpments", x => x.Equipment_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equpments");
        }
    }
}

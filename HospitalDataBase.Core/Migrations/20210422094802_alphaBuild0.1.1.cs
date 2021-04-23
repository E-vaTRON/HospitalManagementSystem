using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class alphaBuild011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RpoupID",
                table: "DeviceServices",
                newName: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "DeviceServices",
                newName: "RpoupID");
        }
    }
}

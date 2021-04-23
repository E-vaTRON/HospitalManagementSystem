using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class AlphaBuildv012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "DeviceServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultFromType",
                table: "DeviceServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultFromType",
                table: "DeviceServices");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "DeviceServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

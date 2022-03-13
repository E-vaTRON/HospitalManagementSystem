using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalDataBase.Core.Migrations
{
    public partial class RenameAtribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "AnalysationTests");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Patients",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "DeviceServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "DeviceServices");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Patients",
                newName: "Sex");

            migrationBuilder.AddColumn<string>(
                name: "PatientID",
                table: "AnalysationTests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

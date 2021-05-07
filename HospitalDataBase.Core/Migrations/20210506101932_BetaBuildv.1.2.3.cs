using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class BetaBuildv123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "PatientRecipient",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ResultFromType",
                table: "AnalysationTests");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "DeviceServices",
                newName: "ResultFromType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResultFromType",
                table: "DeviceServices",
                newName: "Result");

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientRecipient",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultFromType",
                table: "AnalysationTests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class littleTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorComment",
                table: "AnalysationTests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorComment",
                table: "AnalysationTests");
        }
    }
}

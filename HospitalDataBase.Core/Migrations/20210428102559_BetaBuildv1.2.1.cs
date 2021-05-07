using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class BetaBuildv121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorID",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_DoctorID",
                table: "Exams",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_EmployeeID",
                table: "Exams",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_DoctorID",
                table: "Exams",
                column: "DoctorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_EmployeeID",
                table: "Exams",
                column: "EmployeeID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_DoctorID",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_EmployeeID",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_DoctorID",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_EmployeeID",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "AspNetUsers");
        }
    }
}

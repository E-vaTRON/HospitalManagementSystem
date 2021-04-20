using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class AlphaBuildv01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "Analysations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Analysations_PatientID",
                table: "Analysations",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Analysations_Patients_PatientID",
                table: "Analysations",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analysations_Patients_PatientID",
                table: "Analysations");

            migrationBuilder.DropIndex(
                name: "IX_Analysations_PatientID",
                table: "Analysations");

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "Analysations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

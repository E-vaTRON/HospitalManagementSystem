using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class BetaBuildv120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysationTests_Patients_PatientID",
                table: "AnalysationTests");

            migrationBuilder.DropForeignKey(
                name: "FK_GetGoodsImportations_Drugs_GoodID",
                table: "GetGoodsImportations");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsExportations_Drugs_GoodID",
                table: "GoodsExportations");

            migrationBuilder.DropIndex(
                name: "IX_GoodsExportations_GoodID",
                table: "GoodsExportations");

            migrationBuilder.DropIndex(
                name: "IX_GetGoodsImportations_GoodID",
                table: "GetGoodsImportations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_AnalysationTests_PatientID",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "ResultFromType",
                table: "DeviceServices");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Inventories",
                newName: "InventoryID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Exams",
                newName: "LineID");

            migrationBuilder.AlterColumn<string>(
                name: "GoodID",
                table: "GoodsExportations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamID",
                table: "GoodsExportations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "GoodsExportations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "GoodID",
                table: "GetGoodsImportations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "GetGoodsImportations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ExamID",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LineID",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Result",
                table: "DeviceServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "AnalysationTests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamID",
                table: "AnalysationTests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultFromType",
                table: "AnalysationTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsExportations_ExamID",
                table: "GoodsExportations",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsExportations_InventoryID",
                table: "GoodsExportations",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_GetGoodsImportations_InventoryID",
                table: "GetGoodsImportations",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysationTests_ExamID",
                table: "AnalysationTests",
                column: "ExamID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysationTests_Exams_ExamID",
                table: "AnalysationTests",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GetGoodsImportations_Inventories_InventoryID",
                table: "GetGoodsImportations",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsExportations_Exams_ExamID",
                table: "GoodsExportations",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsExportations_Inventories_InventoryID",
                table: "GoodsExportations",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysationTests_Exams_ExamID",
                table: "AnalysationTests");

            migrationBuilder.DropForeignKey(
                name: "FK_GetGoodsImportations_Inventories_InventoryID",
                table: "GetGoodsImportations");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsExportations_Exams_ExamID",
                table: "GoodsExportations");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsExportations_Inventories_InventoryID",
                table: "GoodsExportations");

            migrationBuilder.DropIndex(
                name: "IX_GoodsExportations_ExamID",
                table: "GoodsExportations");

            migrationBuilder.DropIndex(
                name: "IX_GoodsExportations_InventoryID",
                table: "GoodsExportations");

            migrationBuilder.DropIndex(
                name: "IX_GetGoodsImportations_InventoryID",
                table: "GetGoodsImportations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_AnalysationTests_ExamID",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "ExamID",
                table: "GoodsExportations");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "GoodsExportations");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "GetGoodsImportations");

            migrationBuilder.DropColumn(
                name: "ExamID",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "ResultFromType",
                table: "AnalysationTests");

            migrationBuilder.RenameColumn(
                name: "InventoryID",
                table: "Inventories",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "LineID",
                table: "Exams",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "GoodID",
                table: "GoodsExportations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoodID",
                table: "GetGoodsImportations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExamID",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "DeviceServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ResultFromType",
                table: "DeviceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "AnalysationTests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsExportations_GoodID",
                table: "GoodsExportations",
                column: "GoodID");

            migrationBuilder.CreateIndex(
                name: "IX_GetGoodsImportations_GoodID",
                table: "GetGoodsImportations",
                column: "GoodID");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysationTests_PatientID",
                table: "AnalysationTests",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysationTests_Patients_PatientID",
                table: "AnalysationTests",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GetGoodsImportations_Drugs_GoodID",
                table: "GetGoodsImportations",
                column: "GoodID",
                principalTable: "Drugs",
                principalColumn: "GoodID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsExportations_Drugs_GoodID",
                table: "GoodsExportations",
                column: "GoodID",
                principalTable: "Drugs",
                principalColumn: "GoodID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

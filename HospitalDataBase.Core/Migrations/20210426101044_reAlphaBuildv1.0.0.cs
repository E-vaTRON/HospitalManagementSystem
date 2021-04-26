using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDataBase.Core.Migrations
{
    public partial class reAlphaBuildv100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysationTests_DeviceServices_DeviceServiceID",
                table: "AnalysationTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceServices",
                table: "DeviceServices");

            migrationBuilder.DropIndex(
                name: "IX_AnalysationTests_DeviceServiceID",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "DeviceServices");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "DeviceServiceID",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "ResultFrom",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AnalysationTests");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceID",
                table: "DeviceServices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceID",
                table: "AnalysationTests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceServices",
                table: "DeviceServices",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysationTests_DeviceID",
                table: "AnalysationTests",
                column: "DeviceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysationTests_DeviceServices_DeviceID",
                table: "AnalysationTests",
                column: "DeviceID",
                principalTable: "DeviceServices",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysationTests_DeviceServices_DeviceID",
                table: "AnalysationTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceServices",
                table: "DeviceServices");

            migrationBuilder.DropIndex(
                name: "IX_AnalysationTests_DeviceID",
                table: "AnalysationTests");

            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "AnalysationTests");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceID",
                table: "DeviceServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "DeviceServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AnalysationTests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeviceServiceID",
                table: "AnalysationTests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AnalysationTests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AnalysationTests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultFrom",
                table: "AnalysationTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "AnalysationTests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceServices",
                table: "DeviceServices",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysationTests_DeviceServiceID",
                table: "AnalysationTests",
                column: "DeviceServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysationTests_DeviceServices_DeviceServiceID",
                table: "AnalysationTests",
                column: "DeviceServiceID",
                principalTable: "DeviceServices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

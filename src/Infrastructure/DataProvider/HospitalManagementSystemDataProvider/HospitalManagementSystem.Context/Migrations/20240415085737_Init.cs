using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Context.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingAppointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingAppointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    GoodName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ActiveIngredientName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    GoodType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UnitPrice = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    HealthInsurancePrice = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ICD",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Importation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Billnumber = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RecordDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReceiptDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tax = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDevice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    SmallID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    GroupID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDevice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    ServicePrice = table.Column<int>(type: "int", nullable: false),
                    HealthInsurancePrice = table.Column<int>(type: "int", nullable: false),
                    ResultFromType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: true),
                    BookingAppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExam_BookingAppointment_BookingAppointmentId",
                        column: x => x.BookingAppointmentId,
                        principalTable: "BookingAppointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DiagnosisCode = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ICDId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosis_ICD_ICDId",
                        column: x => x.ICDId,
                        principalTable: "ICD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodSuppling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    GoodInformation = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrinaryAmount = table.Column<int>(type: "int", nullable: false),
                    ImportationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodSuppling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodSuppling_Drug_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodSuppling_Importation_ImportationId",
                        column: x => x.ImportationId,
                        principalTable: "Importation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceInventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CurrentAmount = table.Column<int>(type: "int", nullable: false),
                    MedicalDeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceInventory_MedicalDevice_MedicalDeviceId",
                        column: x => x.MedicalDeviceId,
                        principalTable: "MedicalDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceInventory_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExamEposode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DateTakeExam = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateReExam = table.Column<DateTime>(type: "datetime", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    RecordDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    MedicalExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExamEposode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExamEposode_MedicalExam_MedicalExamId",
                        column: x => x.MedicalExamId,
                        principalTable: "MedicalExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DateOfReferral = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Urgency = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    MedicalExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referral_MedicalExam_MedicalExamId",
                        column: x => x.MedicalExamId,
                        principalTable: "MedicalExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAssignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAssignment_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisTreatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiagnosisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosisTreatment_Diagnosis_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosisTreatment_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugInventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CurrentAmount = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GoodSupplingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugInventory_GoodSuppling_GoodSupplingId",
                        column: x => x.GoodSupplingId,
                        principalTable: "GoodSuppling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugInventory_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DeviceInventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceService_DeviceInventory_DeviceInventoryId",
                        column: x => x.DeviceInventoryId,
                        principalTable: "DeviceInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReExamAppointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    MedicalExamEposodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReExamAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReExamAppointment_MedicalExamEposode_MedicalExamEposodeId",
                        column: x => x.MedicalExamEposodeId,
                        principalTable: "MedicalExamEposode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAllocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicalExamEposodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAllocation_MedicalExamEposode_MedicalExamEposodeId",
                        column: x => x.MedicalExamEposodeId,
                        principalTable: "MedicalExamEposode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAllocation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentExamEpisode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicalExamEpisodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentExamEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentExamEpisode_MedicalExamEposode_MedicalExamEpisodeId",
                        column: x => x.MedicalExamEpisodeId,
                        principalTable: "MedicalExamEposode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentExamEpisode_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferralDoctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ReferralStatus = table.Column<string>(type: "nvarchar", nullable: true),
                    ReferredDoctorId = table.Column<string>(type: "nvarchar", nullable: false),
                    ReferralId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralDoctor_Referral_ReferralId",
                        column: x => x.ReferralId,
                        principalTable: "Referral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugPrescription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    MedicalExamEposodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DrugInventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugPrescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugPrescription_DrugInventory_DrugInventoryId",
                        column: x => x.DrugInventoryId,
                        principalTable: "DrugInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugPrescription_MedicalExamEposode_MedicalExamEposodeId",
                        column: x => x.MedicalExamEposodeId,
                        principalTable: "MedicalExamEposode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DSymptom = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DoctorComment = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Result = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DeviceServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicalExamEposodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisTest_DeviceService_DeviceServiceId",
                        column: x => x.DeviceServiceId,
                        principalTable: "DeviceService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysisTest_MedicalExamEposode_MedicalExamEposodeId",
                        column: x => x.MedicalExamEposodeId,
                        principalTable: "MedicalExamEposode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    AssignmentStatus = table.Column<string>(type: "nvarchar", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar", nullable: false),
                    MedicalExamEposodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferralDoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentHistory_MedicalExamEposode_MedicalExamEposodeId",
                        column: x => x.MedicalExamEposodeId,
                        principalTable: "MedicalExamEposode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentHistory_ReferralDoctor_ReferralDoctorId",
                        column: x => x.ReferralDoctorId,
                        principalTable: "ReferralDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisTest");

            migrationBuilder.DropTable(
                name: "AssignmentHistory");

            migrationBuilder.DropTable(
                name: "DiagnosisTreatment");

            migrationBuilder.DropTable(
                name: "DrugPrescription");

            migrationBuilder.DropTable(
                name: "ReExamAppointment");

            migrationBuilder.DropTable(
                name: "RoomAllocation");

            migrationBuilder.DropTable(
                name: "RoomAssignment");

            migrationBuilder.DropTable(
                name: "TreatmentExamEpisode");

            migrationBuilder.DropTable(
                name: "DeviceService");

            migrationBuilder.DropTable(
                name: "ReferralDoctor");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "DrugInventory");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "MedicalExamEposode");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "DeviceInventory");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "ICD");

            migrationBuilder.DropTable(
                name: "GoodSuppling");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "MedicalDevice");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "MedicalExam");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "Importation");

            migrationBuilder.DropTable(
                name: "BookingAppointment");
        }
    }
}

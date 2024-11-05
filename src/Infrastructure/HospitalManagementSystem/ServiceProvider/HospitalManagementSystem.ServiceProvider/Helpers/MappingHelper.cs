namespace HospitalManagementSystem.ServiceProvider;

public class MappingHelper : Profile
{
    public MappingHelper()
    {
        AllowNullCollections = true;
        AllowNullDestinationValues = true;

        var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

        CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
        CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

        CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
        CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);

        // BookingAppointment
        CreateMap<Domain.BookingAppointment, InputBookingAppointmentDTO>().ReverseMap();
        CreateMap<Domain.BookingAppointment, OutputBookingAppointmentDTO>().ReverseMap();
        CreateMap<InputBookingAppointmentDTO, OutputBookingAppointmentDTO>().ReverseMap();

        // ReExamAppointment
        CreateMap<Domain.ReExamAppointment, InputReExamAppointmentDTO>().ReverseMap();
        CreateMap<Domain.ReExamAppointment, OutputReExamAppointmentDTO>().ReverseMap();
        CreateMap<InputReExamAppointmentDTO, OutputReExamAppointmentDTO>().ReverseMap();

        // Referral
        CreateMap<Domain.Referral, InputReferralDTO>().ReverseMap();
        CreateMap<Domain.Referral, OutputReferralDTO>().ReverseMap();
        CreateMap<InputReferralDTO, OutputReferralDTO>().ReverseMap();

        // ReferralDoctor
        CreateMap<Domain.ReferralDoctor, InputReferralDoctorDTO>().ReverseMap();
        CreateMap<Domain.ReferralDoctor, OutputReferralDoctorDTO>().ReverseMap();
        CreateMap<InputReferralDoctorDTO, OutputReferralDoctorDTO>().ReverseMap();

        // Department
        CreateMap<Domain.Department, InputDepartmentDTO>().ReverseMap();
        CreateMap<Domain.Department, OutputDepartmentDTO>().ReverseMap();
        CreateMap<InputDepartmentDTO, OutputDepartmentDTO>().ReverseMap();

        // Room
        CreateMap<Domain.Room, InputRoomDTO>().ReverseMap();
        CreateMap<Domain.Room, OutputRoomDTO>().ReverseMap();
        CreateMap<InputRoomDTO, OutputRoomDTO>().ReverseMap();

        // RoomAllocation
        CreateMap<Domain.RoomAllocation, InputRoomAllocationDTO>().ReverseMap();
        CreateMap<Domain.RoomAllocation, OutputRoomAllocationDTO>().ReverseMap();
        CreateMap<InputRoomAllocationDTO, OutputRoomAllocationDTO>().ReverseMap();

        // Drug
        CreateMap<Domain.Drug, InputDrugDTO>().ReverseMap();
        CreateMap<Domain.Drug, OutputDrugDTO>().ReverseMap();
        CreateMap<InputDrugDTO, OutputDrugDTO>().ReverseMap();

        // DrugInventory
        CreateMap<Domain.DrugInventory, InputDrugInventoryDTO>().ReverseMap();
        CreateMap<Domain.DrugInventory, OutputDrugInventoryDTO>().ReverseMap();
        CreateMap<InputDrugInventoryDTO, OutputDrugInventoryDTO>().ReverseMap();

        // DrugPrescription
        CreateMap<Domain.DrugPrescription, InputDrugPrescriptionDTO>().ReverseMap();
        CreateMap<Domain.DrugPrescription, OutputDrugPrescriptionDTO>().ReverseMap();
        CreateMap<InputDrugPrescriptionDTO, OutputDrugPrescriptionDTO>().ReverseMap();

        // Storage
        CreateMap<Domain.Storage, InputStorageDTO>().ReverseMap();
        CreateMap<Domain.Storage, OutputStorageDTO>().ReverseMap();
        CreateMap<InputStorageDTO, OutputStorageDTO>().ReverseMap();

        // GoodSuppling
        CreateMap<Domain.GoodSuppling, InputGoodSupplingDTO>().ReverseMap();
        CreateMap<Domain.GoodSuppling, OutputGoodSupplingDTO>().ReverseMap();
        CreateMap<InputGoodSupplingDTO, OutputGoodSupplingDTO>().ReverseMap();

        // Importation
        CreateMap<Domain.Importation, InputImportationDTO>().ReverseMap();
        CreateMap<Domain.Importation, OutputImportationDTO>().ReverseMap();
        CreateMap<InputImportationDTO, OutputImportationDTO>().ReverseMap();

        // DeviceInventory
        CreateMap<Domain.DeviceInventory, InputDeviceInventoryDTO>().ReverseMap();
        CreateMap<Domain.DeviceInventory, OutputDeviceInventoryDTO>().ReverseMap();
        CreateMap<InputDeviceInventoryDTO, OutputDeviceInventoryDTO>().ReverseMap();

        // AssignmentHistory
        CreateMap<Domain.AssignmentHistory, InputAssignmentHistoryDTO>().ReverseMap();
        CreateMap<Domain.AssignmentHistory, OutputAssignmentHistoryDTO>().ReverseMap();
        CreateMap<InputAssignmentHistoryDTO, OutputAssignmentHistoryDTO>().ReverseMap();

        // Diagnosis
        CreateMap<Domain.Diagnosis, InputDiagnosisDTO>().ReverseMap();
        CreateMap<Domain.Diagnosis, OutputDiagnosisDTO>().ReverseMap();
        CreateMap<InputDiagnosisDTO, OutputDiagnosisDTO>().ReverseMap();

        // DiagnosisTreatment
        CreateMap<Domain.DiagnosisTreatment, InputDiagnosisTreatmentDTO>().ReverseMap();
        CreateMap<Domain.DiagnosisTreatment, OutputDiagnosisTreatmentDTO>().ReverseMap();
        CreateMap<InputDiagnosisTreatmentDTO, OutputDiagnosisTreatmentDTO>().ReverseMap();

        // Diseases
        CreateMap<Domain.Diseases, InputDiseasesDTO>().ReverseMap();
        CreateMap<Domain.Diseases, OutputDiseasesDTO>().ReverseMap();
        CreateMap<InputDiseasesDTO, OutputDiseasesDTO>().ReverseMap();

        // ICDCode
        CreateMap<Domain.ICDCode, InputICDCodeDTO>().ReverseMap();
        CreateMap<Domain.ICDCode, OutputICDCodeDTO>().ReverseMap();
        CreateMap<InputICDCodeDTO, OutputICDCodeDTO>().ReverseMap();

        // ICDVersion
        CreateMap<Domain.ICDVersion, InputICDVersionDTO>().ReverseMap();
        CreateMap<Domain.ICDVersion, OutputICDVersionDTO>().ReverseMap();
        CreateMap<InputICDVersionDTO, OutputICDVersionDTO>().ReverseMap();

        // ICDCodeVersion
        CreateMap<Domain.ICDCodeVersion, InputICDCodeVersionDTO>().ReverseMap();
        CreateMap<Domain.ICDCodeVersion, OutputICDCodeVersionDTO>().ReverseMap();
        CreateMap<InputICDCodeVersionDTO, OutputICDCodeVersionDTO>().ReverseMap();

        // MedicalExam
        CreateMap<Domain.MedicalExam, InputMedicalExamDTO>().ReverseMap();
        CreateMap<Domain.MedicalExam, OutputMedicalExamDTO>().ReverseMap();
        CreateMap<InputMedicalExamDTO, OutputMedicalExamDTO>().ReverseMap();

        // MedicalExamEpisode
        CreateMap<Domain.MedicalExamEpisode, InputMedicalExamEpisodeDTO>().ReverseMap();
        CreateMap<Domain.MedicalExamEpisode, OutputMedicalExamEpisodeDTO>().ReverseMap();
        CreateMap<InputMedicalExamEpisodeDTO, OutputMedicalExamEpisodeDTO>().ReverseMap();

        // Treatment
        CreateMap<Domain.Treatment, InputTreatmentDTO>().ReverseMap();
        CreateMap<Domain.Treatment, OutputTreatmentDTO>().ReverseMap();
        CreateMap<InputTreatmentDTO, OutputTreatmentDTO>().ReverseMap();

        // DeviceService
        CreateMap<Domain.ServiceEpisode, InputServiceEpisodeDTO>().ReverseMap();
        CreateMap<Domain.ServiceEpisode, OutputServiceEpisodeDTO>().ReverseMap();
        CreateMap<InputServiceEpisodeDTO, OutputServiceEpisodeDTO>().ReverseMap();

        // MedicalDevice
        CreateMap<Domain.MedicalDevice, InputMedicalDeviceDTO>().ReverseMap();
        CreateMap<Domain.MedicalDevice, OutputMedicalDeviceDTO>().ReverseMap();
        CreateMap<InputMedicalDeviceDTO, OutputMedicalDeviceDTO>().ReverseMap();

        // MedicalService
        CreateMap<Domain.MedicalService, InputMedicalServiceDTO>().ReverseMap();
        CreateMap<Domain.MedicalService, OutputMedicalServiceDTO>().ReverseMap();
        CreateMap<InputMedicalServiceDTO, OutputMedicalServiceDTO>().ReverseMap();

        // AnalysisTest
        CreateMap<Domain.AnalysisTest, InputAnalysisTestDTO>().ReverseMap();
        CreateMap<Domain.AnalysisTest, OutputAnalysisTestDTO>().ReverseMap();
        CreateMap<InputAnalysisTestDTO, OutputAnalysisTestDTO>().ReverseMap();

        // Bill
        CreateMap<Domain.Bill, InputBillDTO>().ReverseMap();
        CreateMap<Domain.Bill, OutputBillDTO>().ReverseMap();
        CreateMap<InputBillDTO, OutputBillDTO>().ReverseMap();
    }
}

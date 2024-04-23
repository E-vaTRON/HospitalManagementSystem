namespace HospitalManagementSystem.DataProvider;

public class DataContext
{
    #region [ CTor ]
    public DataContext(
        IBookingAppointmentDataProvider bookingAppointmentDataProvider,
        IReExamAppointmentDataProvider reExamAppointmentDataProvider,
        IReferralDataProvider referralDataProvider,
        IReferralDoctorDataProvider referralDoctorDataProvider,

        IDepartmentDataProvider departmentDataProvider,
        IRoomAllocationDataProvider roomAllocationDataProvider,
        IRoomAssignmentDataProvider roomAssignmentDataProvider,
        IRoomDataProvider roomDataProvider,

        IDeviceInventoryDataProvider deviceInventoryDataProvider,
        IDrugInventoryDataProvider drugInventoryDataProvider,
        IDrugDataProvider drugDataProvider,
        IDrugPrescriptionDataProvider drugPrescriptionDataProvider,
        IGoodSupplingDataProvider goodSupplingDataProvider,
        IImportationDataProvider importationDataProvider,
        IStorageDataProvider storageDataProvider,

        IAssignmentHistoryDataProvider assignmentHistoryDataProvider,
        IDiagnosisDataProvider diagnosisDataProvider,
        IDiagnosisTreatmentDataProvider diagnosisTreatmentDataProvider,
        IICDDataProvider icdDataProvider,
        IMedicalExamDataProvider medicalExamDataProvider,
        IMedicalExamEposodeDataProvider medicalExamEposodeDataProvider,
        ITreatmentDataProvider treatmentDataProvider,
        ITreatmentExamEpisodeDataProvider treatmentExamEpisodeDataProvider,

        IAnalysisTestDataProvider analysisTestDataProvider,
        IMedicalDeviceDataProvider medicalDeviceDataProvider,
        IServiceDataProvider serviceDataProvider,
        IDeviceServiceDataProvider deviceServiceDataProvider)
    {
        BookingAppointments = bookingAppointmentDataProvider;
        ReExamAppointments = reExamAppointmentDataProvider;
        Referrals = referralDataProvider;
        ReferralDoctors = referralDoctorDataProvider;

        RoomAllocations = roomAllocationDataProvider;
        RoomAssignments = roomAssignmentDataProvider;
        Rooms = roomDataProvider;
        Departments = departmentDataProvider;

        DeviceInventories = deviceInventoryDataProvider;
        DrugInventories = drugInventoryDataProvider;
        Drugs = drugDataProvider;
        DrugPrescriptions = drugPrescriptionDataProvider;
        GoodSupplings = goodSupplingDataProvider; 
        Importations = importationDataProvider;
        Storages = storageDataProvider;

        AssignmentHistories = assignmentHistoryDataProvider;
        Diagnoses = diagnosisDataProvider;
        DiagnosisTreatments = diagnosisTreatmentDataProvider;
        ICDs = icdDataProvider;
        MedicalExams = medicalExamDataProvider;
        MedicalExamEposodes = medicalExamEposodeDataProvider;
        Treatments = treatmentDataProvider;
        TreatmentExamEpisodes = treatmentExamEpisodeDataProvider;

        AnalysisTests = analysisTestDataProvider;
        MedicalDevices = medicalDeviceDataProvider;
        Services = serviceDataProvider;
        DeviceServices = deviceServiceDataProvider;
    }
    #endregion

    #region [ Methods ]

    #region [ Fuction ]
    public IBookingAppointmentDataProvider BookingAppointments { get; set; }
    public IReExamAppointmentDataProvider ReExamAppointments { get; set; }
    public IReferralDataProvider Referrals { get; set; }
    public IReferralDoctorDataProvider ReferralDoctors { get; set; }
    #endregion

    #region [ Infrastructure ]
    public IDepartmentDataProvider Departments { get; set; }
    public IRoomDataProvider Rooms { get; set; }
    public IRoomAllocationDataProvider RoomAllocations { get; set; }
    public IRoomAssignmentDataProvider RoomAssignments { get; set; }
    #endregion

    #region [ Inventory ]
    public IDrugDataProvider Drugs { get; set; }
    public IDrugInventoryDataProvider DrugInventories { get; set; }
    public IDrugPrescriptionDataProvider DrugPrescriptions { get; set; }
    public IStorageDataProvider Storages { get; set; }
    public IGoodSupplingDataProvider GoodSupplings { get; set; }
    public IImportationDataProvider Importations { get; set; }
    public IDeviceInventoryDataProvider DeviceInventories { get; set; }
    #endregion

    #region [ Medical ]
    public IAssignmentHistoryDataProvider AssignmentHistories { get; set; }
    public IDiagnosisDataProvider Diagnoses { get; set; }
    public IDiagnosisTreatmentDataProvider DiagnosisTreatments { get; set; }
    public IICDDataProvider ICDs { get; set; }
    public ITreatmentDataProvider Treatments { get; set; }
    public ITreatmentExamEpisodeDataProvider TreatmentExamEpisodes { get; set; }
    public IMedicalExamDataProvider MedicalExams { get; set; }
    public IMedicalExamEposodeDataProvider MedicalExamEposodes { get; set; }
    #endregion

    #region [ MedicalDevice ]
    public IAnalysisTestDataProvider AnalysisTests { get; set; }
    public IDeviceServiceDataProvider DeviceServices { get; set; }
    public IMedicalDeviceDataProvider MedicalDevices { get; set; }
    public IServiceDataProvider Services { get; set; }
    #endregion


    #endregion
}

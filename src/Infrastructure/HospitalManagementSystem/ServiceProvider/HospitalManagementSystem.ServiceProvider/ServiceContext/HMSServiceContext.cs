namespace HospitalManagementSystem.ServiceProvider;

public class HMSServiceContext
{
    #region [ CTor ]
    public HMSServiceContext(
        IBookingAppointmentServiceProvider bookingAppointmentServiceProvider,
        IReExamAppointmentServiceProvider reExamAppointmentServiceProvider,
        IReferralServiceProvider referralServiceProvider,
        IReferralDoctorServiceProvider referralDoctorServiceProvider,

        IDepartmentServiceProvider departmentServiceProvider,
        IRoomAllocationServiceProvider roomAllocationServiceProvider,
        IRoomAssignmentServiceProvider roomAssignmentServiceProvider,
        IRoomServiceProvider roomServiceProvider,

        IDeviceInventoryServiceProvider deviceInventoryServiceProvider,
        IDrugInventoryServiceProvider drugInventoryServiceProvider,
        IDrugServiceProvider drugServiceProvider,
        IDrugPrescriptionServiceProvider drugPrescriptionServiceProvider,
        IImportationServiceProvider importationServiceProvider,
        IStorageServiceProvider storageServiceProvider,

        IAssignmentHistoryServiceProvider assignmentHistoryServiceProvider,
        IDiagnosisServiceProvider diagnosisServiceProvider,
        IDiagnosisTreatmentServiceProvider diagnosisTreatmentServiceProvider,
        IDiseasesServiceProvider diseasesServiceProvider, 
        IICDCodeServiceProvider iCDCodeServiceProvider, 
        IICDVersionServiceProvider iCDVersionServiceProvider,
        IICDCodeVersionServiceProvider iCDCodeVersionServiceProvider, 
        IMedicalExamServiceProvider medicalExamServiceProvider,
        IMedicalExamEpisodeServiceProvider medicalExamEpisodeServiceProvider,
        ITreatmentServiceProvider treatmentServiceProvider,

        IAnalysisTestServiceProvider analysisTestServiceProvider,
        IMedicalDeviceServiceProvider medicalDeviceServiceProvider,
        IServiceServiceProvider serviceServiceProvider,
        IDeviceServiceServiceProvider deviceServiceServiceProvider,

        IBillServiceProvider billServiceProvider)
    {
        BookingAppointments = bookingAppointmentServiceProvider;
        ReExamAppointments = reExamAppointmentServiceProvider;
        Referrals = referralServiceProvider;
        ReferralDoctors = referralDoctorServiceProvider;

        RoomAllocations = roomAllocationServiceProvider;
        RoomAssignments = roomAssignmentServiceProvider;
        Rooms = roomServiceProvider;
        Departments = departmentServiceProvider;

        DeviceInventories = deviceInventoryServiceProvider;
        DrugInventories = drugInventoryServiceProvider;
        Drugs = drugServiceProvider;
        DrugPrescriptions = drugPrescriptionServiceProvider;
        Importations = importationServiceProvider;
        Storages = storageServiceProvider;

        AssignmentHistories = assignmentHistoryServiceProvider;
        Diagnoses = diagnosisServiceProvider;
        DiagnosisTreatments = diagnosisTreatmentServiceProvider;
        Diseases = diseasesServiceProvider;
        ICDCodes = iCDCodeServiceProvider;
        ICDCodeVersion = iCDCodeVersionServiceProvider;
        ICDVersion = iCDVersionServiceProvider;
        MedicalExams = medicalExamServiceProvider;
        MedicalExamEpisodes = medicalExamEpisodeServiceProvider;
        Treatments = treatmentServiceProvider;

        AnalysisTests = analysisTestServiceProvider;
        MedicalDevices = medicalDeviceServiceProvider;
        Services = serviceServiceProvider;
        DeviceServices = deviceServiceServiceProvider;

        Bills = billServiceProvider;
    }
    #endregion

    #region [ Methods ]
    #region [ Fuction ]
    public IBookingAppointmentServiceProvider  BookingAppointments { get; set; }
    public IReExamAppointmentServiceProvider   ReExamAppointments  { get; set; }
    public IReferralServiceProvider            Referrals           { get; set; }
    public IReferralDoctorServiceProvider      ReferralDoctors     { get; set; }
    #endregion

    #region [ Infrastructure ]
    public IDepartmentServiceProvider      Departments     { get; set; }
    public IRoomServiceProvider            Rooms           { get; set; }
    public IRoomAllocationServiceProvider  RoomAllocations { get; set; }
    public IRoomAssignmentServiceProvider  RoomAssignments { get; set; }
    #endregion

    #region [ Inventory ]
    public IDrugServiceProvider                Drugs               { get; set; }
    public IDrugInventoryServiceProvider       DrugInventories     { get; set; }
    public IDrugPrescriptionServiceProvider    DrugPrescriptions   { get; set; }
    public IStorageServiceProvider             Storages            { get; set; }
    public IImportationServiceProvider         Importations        { get; set; }
    public IDeviceInventoryServiceProvider     DeviceInventories   { get; set; }
    #endregion

    #region [ Medical ]
    public IAssignmentHistoryServiceProvider       AssignmentHistories     { get; set; }
    public IDiagnosisServiceProvider               Diagnoses               { get; set; }
    public IDiagnosisTreatmentServiceProvider      DiagnosisTreatments     { get; set; }
    public IDiseasesServiceProvider                Diseases                { get; set; }
    public IICDCodeServiceProvider                 ICDCodes                { get; set; }
    public IICDVersionServiceProvider              ICDVersion              { get; set; }
    public IICDCodeVersionServiceProvider          ICDCodeVersion          { get; set; }
    public ITreatmentServiceProvider               Treatments              { get; set; }
    public IMedicalExamServiceProvider             MedicalExams            { get; set; }
    public IMedicalExamEpisodeServiceProvider      MedicalExamEpisodes     { get; set; }
    #endregion

    #region [ MedicalDevice ]
    public IAnalysisTestServiceProvider    AnalysisTests   { get; set; }
    public IDeviceServiceServiceProvider   DeviceServices  { get; set; }
    public IMedicalDeviceServiceProvider   MedicalDevices  { get; set; }
    public IServiceServiceProvider         Services        { get; set; }
    #endregion

    #region [ Transaction ]
    public IBillServiceProvider Bills { get; set; }
    #endregion
    #endregion
}

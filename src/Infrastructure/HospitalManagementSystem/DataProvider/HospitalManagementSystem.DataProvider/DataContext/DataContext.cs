using Microsoft.EntityFrameworkCore.Storage;

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
        //IRoomAssignmentDataProvider roomAssignmentDataProvider,
        IRoomDataProvider roomDataProvider,

        IDeviceInventoryDataProvider deviceInventoryDataProvider,
        IDrugInventoryDataProvider drugInventoryDataProvider,
        IDrugDataProvider drugDataProvider,
        IDrugPrescriptionDataProvider drugPrescriptionDataProvider,
        IImportationDataProvider importationDataProvider,
        IStorageDataProvider storageDataProvider,

        IAssignmentHistoryDataProvider assignmentHistoryDataProvider,
        IDiagnosisDataProvider diagnosisDataProvider,
        IDiagnosisTreatmentDataProvider diagnosisTreatmentDataProvider,
        IDiseasesDataProvider diseasesDataProvider, 
        IICDCodeDataProvider iCDCodeDataProvider, 
        IICDVersionDataProvider iCDVersionDataProvider,
        IICDCodeVersionDataProvider iCDCodeVersionDataProvider, 
        IMedicalExamDataProvider medicalExamDataProvider,
        IMedicalExamEpisodeDataProvider medicalExamEpisodeDataProvider,
        ITreatmentDataProvider treatmentDataProvider,

        IAnalysisTestDataProvider analysisTestDataProvider,
        IMeasurementUnitDataProvider measurementUnitDataProvider,
        IFormTypeDataProvider formTypeDataProvider,
        IMedicalDeviceDataProvider medicalDeviceDataProvider,
        IDeviceUnitDataProvider deviceUnitDataProvider,
        IMedicalDeviceFormDataProvider medicalDeviceFormDataProvider,
        IMedicalServiceDataProvider medicalServiceDataProvider,
        IServiceEpisodeDataProvider serviceEpisodeDataProvider,

        IBillDataProvider billDataProvider)
    {
        BookingAppointments = bookingAppointmentDataProvider;
        ReExamAppointments = reExamAppointmentDataProvider;
        Referrals = referralDataProvider;
        ReferralDoctors = referralDoctorDataProvider;

        RoomAllocations = roomAllocationDataProvider;
        //RoomAssignments = roomAssignmentDataProvider;
        Rooms = roomDataProvider;
        Departments = departmentDataProvider;

        DeviceInventories = deviceInventoryDataProvider;
        DrugInventories = drugInventoryDataProvider;
        Drugs = drugDataProvider;
        DrugPrescriptions = drugPrescriptionDataProvider;
        Importations = importationDataProvider;
        Storages = storageDataProvider;

        AssignmentHistories = assignmentHistoryDataProvider;
        Diagnoses = diagnosisDataProvider;
        DiagnosisTreatments = diagnosisTreatmentDataProvider;
        Diseases = diseasesDataProvider;
        ICDCodes = iCDCodeDataProvider;
        ICDCodeVersions = iCDCodeVersionDataProvider;
        ICDVersions = iCDVersionDataProvider;
        MedicalExams = medicalExamDataProvider;
        MedicalExamEpisodes = medicalExamEpisodeDataProvider;
        Treatments = treatmentDataProvider;

        AnalysisTests = analysisTestDataProvider;
        MeasurementUnits = measurementUnitDataProvider;
        FormTypes = formTypeDataProvider;
        MedicalDevices = medicalDeviceDataProvider;
        DeviceUnits = deviceUnitDataProvider;
        MedicalDeviceForms = medicalDeviceFormDataProvider;
        MedicalServices = medicalServiceDataProvider;
        ServiceEpisodes = serviceEpisodeDataProvider;

        Bills = billDataProvider;
    }
    #endregion

    #region [ Properties ]
    #region [ Fuction ]
    public IBookingAppointmentDataProvider  BookingAppointments { get; set; }
    public IReExamAppointmentDataProvider   ReExamAppointments  { get; set; }
    public IReferralDataProvider            Referrals           { get; set; }
    public IReferralDoctorDataProvider      ReferralDoctors     { get; set; }
    #endregion

    #region [ Infrastructure ]
    public IDepartmentDataProvider      Departments     { get; set; }
    public IRoomDataProvider            Rooms           { get; set; }
    public IRoomAllocationDataProvider  RoomAllocations { get; set; }
    //public IRoomAssignmentDataProvider  RoomAssignments { get; set; }
    #endregion

    #region [ Inventory ]
    public IDrugDataProvider                Drugs               { get; set; }
    public IDrugInventoryDataProvider       DrugInventories     { get; set; }
    public IDrugPrescriptionDataProvider    DrugPrescriptions   { get; set; }
    public IStorageDataProvider             Storages            { get; set; }
    public IImportationDataProvider         Importations        { get; set; }
    public IDeviceInventoryDataProvider     DeviceInventories   { get; set; }
    #endregion

    #region [ Medical ]
    public IAssignmentHistoryDataProvider       AssignmentHistories     { get; set; }
    public IDiagnosisDataProvider               Diagnoses               { get; set; }
    public IDiagnosisTreatmentDataProvider      DiagnosisTreatments     { get; set; }
    public IDiseasesDataProvider                Diseases                { get; set; }
    public IICDCodeDataProvider                 ICDCodes                { get; set; }
    public IICDVersionDataProvider              ICDVersions             { get; set; }
    public IICDCodeVersionDataProvider          ICDCodeVersions         { get; set; }
    public ITreatmentDataProvider               Treatments              { get; set; }
    public IMedicalExamDataProvider             MedicalExams            { get; set; }
    public IMedicalExamEpisodeDataProvider      MedicalExamEpisodes     { get; set; }
    #endregion

    #region [ MedicalDevice ]
    public IAnalysisTestDataProvider        AnalysisTests       { get; set; }
    public IMeasurementUnitDataProvider     MeasurementUnits    { get; set; }
    public IFormTypeDataProvider            FormTypes           { get; set; }
    public IServiceEpisodeDataProvider      ServiceEpisodes     { get; set; }
    public IMedicalDeviceFormDataProvider   MedicalDeviceForms  { get; set; }
    public IDeviceUnitDataProvider          DeviceUnits         { get; set; }
    public IMedicalDeviceDataProvider       MedicalDevices      { get; set; }
    public IMedicalServiceDataProvider      MedicalServices     { get; set; }
    #endregion

    #region [ Transaction ]
    public IBillDataProvider Bills { get; set; }
    #endregion
    #endregion
}

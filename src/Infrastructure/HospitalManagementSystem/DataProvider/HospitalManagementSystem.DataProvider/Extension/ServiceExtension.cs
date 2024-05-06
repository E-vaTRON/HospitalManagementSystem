namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataProviders(this IServiceCollection services)
    {
        services.AddTransient<IBookingAppointmentDataProvider,  BookingAppointmentDataProvider>()
                .AddTransient<IReExamAppointmentDataProvider,   ReExamAppointmentDataProvider>()
                .AddTransient<IReferralDataProvider,            ReferralDataProvider>()
                .AddTransient<IReferralDoctorDataProvider,      ReferralDoctorDataProvider>();

        services.AddTransient<IRoomAllocationDataProvider,  RoomAllocationDataProvider>()
                .AddTransient<IRoomAssignmentDataProvider,  RoomAssignmentDataProvider>()
                .AddTransient<IDepartmentDataProvider,      DepartmentDataProvider>()
                .AddTransient<IRoomDataProvider,            RoomDataProvider>();

        services.AddTransient<IDeviceInventoryDataProvider,     DeviceInventoryDataProvider>()
                .AddTransient<IDrugDataProvider,                DrugDataProvider>()
                .AddTransient<IDrugInventoryDataProvider,       DrugInventoryDataProvider>()
                .AddTransient<IDrugPrescriptionDataProvider,    DrugPrescriptionDataProvider>()
                .AddTransient<IGoodSupplingDataProvider,        GoodSupplingDataProvider>()
                .AddTransient<IImportationDataProvider,         ImportationDataProvider>()
                .AddTransient<IStorageDataProvider,             StorageDataProvider>();

        services.AddTransient<IAssignmentHistoryDataProvider,   AssignmentHistoryDataProvider>()
                .AddTransient<IDiagnosisDataProvider,           DiagnosisDataProvider>()
                .AddTransient<IDiagnosisTreatmentDataProvider,  DiagnosisTreatmentDataProvider>()
                .AddTransient<IICDCodeDataProvider,             ICDCodeDataProvider>()
                .AddTransient<IICDCodeVersionDataProvider,      ICDCodeVersionDataProvider>()
                .AddTransient<IICDVersionDataProvider,          ICDVersionDataProvider>()
                .AddTransient<IDiseasesDataProvider,            DiseasesDataProvider>()
                .AddTransient<IMedicalExamDataProvider,         MedicalExamDataProvider>()
                .AddTransient<IMedicalExamEpisodeDataProvider,  MedicalExamEpisodeDataProvider>()
                .AddTransient<ITreatmentDataProvider,           TreatmentDataProvider>();
        //services.AddTransient<ITreatmentExamEpisodeDataProvider, TreatmentExamEpisodeDataProvider>();

        services.AddTransient<IAnalysisTestDataProvider,    AnalysisTestDataProvider>()
                .AddTransient<IDeviceServiceDataProvider,   DeviceServiceDataProvider>()
                .AddTransient<IMedicalDeviceDataProvider,   MedicalDeviceDataProvider>()
                .AddTransient<IServiceDataProvider,         ServiceDataProvider>();
    }
    #endregion
}
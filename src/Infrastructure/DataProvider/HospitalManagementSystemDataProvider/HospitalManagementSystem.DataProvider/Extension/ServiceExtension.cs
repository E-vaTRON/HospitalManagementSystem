namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataProviders(this IServiceCollection services)
    {
        services.AddTransient<IBookingAppointmentServiceProvider, BookingAppointmentDataProvider>();
        services.AddTransient<IReExamAppointmentServiceProvider, ReExamAppointmentDataProvider>();
        services.AddTransient<IReferralServiceProvider, ReferralDataProvider>();
        services.AddTransient<IReferralDoctorServiceProvider, ReferralDoctorDataProvider>();

        services.AddTransient<IRoomAllocationServiceProvider, RoomAllocationDataProvider>();
        services.AddTransient<IRoomAssignmentServiceProvider, RoomAssignmentDataProvider>();
        services.AddTransient<IDepartmentServiceProvider, DepartmentDataProvider>();
        services.AddTransient<IRoomServiceProvider, RoomDataProvider>();

        services.AddTransient<IDeviceInventoryServiceProvider, DeviceInventoryDataProvider>();
        services.AddTransient<IDrugServiceProvider, DrugDataProvider>();
        services.AddTransient<IDrugInventoryServiceProvider, DrugInventoryDataProvider>();
        services.AddTransient<IDrugPrescriptionServiceProvider, DrugPrescriptionDataProvider>();
        services.AddTransient<IGoodSupplingServiceProvider, GoodSupplingDataProvider>();
        services.AddTransient<IImportationServiceProvider, ImportationDataProvider>();
        services.AddTransient<IStorageServiceProvider, StorageDataProvider>();

        services.AddTransient<IAssignmentHistoryServiceProvider, AssignmentHistoryDataProvider>();
        services.AddTransient<IDiagnosisServiceProvider, DiagnosisDataProvider>();
        services.AddTransient<IDiagnosisTreatmentServiceProvider, DiagnosisTreatmentDataProvider>();
        services.AddTransient<IICDServiceProvider, ICDDataProvider>();
        services.AddTransient<IMedicalExamServiceProvider, MedicalExamDataProvider>();
        services.AddTransient<IMedicalExamEposodeServiceProvider, MedicalExamEposodeDataProvider>();
        services.AddTransient<ITreatmentServiceProvider, TreatmentDataProvider>();
        services.AddTransient<ITreatmentExamEpisodeServiceProvider, TreatmentExamEpisodeDataProvider>();

        services.AddTransient<IAnalysisTestServiceProvider, AnalysisTestDataProvider>();
        services.AddTransient<IDeviceServiceServiceProvider, DeviceServiceDataProvider>();
        services.AddTransient<IMedicalDeviceServiceProvider, MedicalDeviceDataProvider>();
        services.AddTransient<IServiceServiceProvider, ServiceDataProvider>();
    }
    #endregion
}
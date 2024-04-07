namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataProviders<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddTransient<IBookingAppointmentDataProvider, BookingAppointmentDataProvider<TDbContext>>();
        services.AddTransient<IReExamAppointmentDataProvider, ReExamAppointmentDataProvider<TDbContext>>();
        services.AddTransient<IReferralDataProvider, ReferralDataProvider<TDbContext>>();
        services.AddTransient<IReferralDoctorDataProvider, ReferralDoctorDataProvider<TDbContext>>();

        services.AddTransient<IRoomAllocationDataProvider, RoomAllocationDataProvider<TDbContext>>();
        services.AddTransient<IRoomAssignmentDataProvider, RoomAssignmentDataProvider<TDbContext>>();
        services.AddTransient<IDepartmentDataProvider, DepartmentDataProvider<TDbContext>>();
        services.AddTransient<IRoomDataProvider, RoomDataProvider<TDbContext>>();

        services.AddTransient<IDeviceInventoryDataProvider, DeviceInventoryDataProvider<TDbContext>>();
        services.AddTransient<IDrugDataProvider, DrugDataProvider<TDbContext>>();
        services.AddTransient<IDrugInventoryDataProvider, DrugInventoryDataProvider<TDbContext>>();
        services.AddTransient<IDrugPrescriptionDataProvider, DrugPrescriptionDataProvider<TDbContext>>();
        services.AddTransient<IGoodSupplingDataProvider, GoodSupplingDataProvider<TDbContext>>();
        services.AddTransient<IImportationDataProvider, ImportationDataProvider<TDbContext>>();
        services.AddTransient<IStorageDataProvider, StorageDataProvider<TDbContext>>();

        services.AddTransient<IAssignmentHistoryDataProvider, AssignmentHistoryDataProvider<TDbContext>>();
        services.AddTransient<IDiagnosisDataProvider, DiagnosisDataProvider<TDbContext>>();
        services.AddTransient<IDiagnosisTreatmentDataProvider, DiagnosisTreatmentDataProvider<TDbContext>>();
        services.AddTransient<IICDDataProvider, ICDDataProvider<TDbContext>>();
        services.AddTransient<IMedicalExamDataProvider, MedicalExamDataProvider<TDbContext>>();
        services.AddTransient<IMedicalExamEposodeDataProvider, MedicalExamEposodeDataProvider<TDbContext>>();
        services.AddTransient<ITreatmentDataProvider, TreatmentDataProvider<TDbContext>>();
        services.AddTransient<ITreatmentExamEpisodeDataProvider, TreatmentExamEpisodeDataProvider<TDbContext>>();

        services.AddTransient<IAnalysisTestDataProvider, AnalysisTestDataProvider<TDbContext>>();
        services.AddTransient<IDeviceServiceDataProvider, DeviceServiceDataProvider<TDbContext>>();
        services.AddTransient<IMedicalDeviceDataProvider, MedicalDeviceDataProvider<TDbContext>>();
        services.AddTransient<IServiceDataProvider, ServiceDataProvider<TDbContext>>();
    }
    #endregion
}
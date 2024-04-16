namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataProviders(this IServiceCollection services)
    {
        services.AddTransient<IBookingAppointmentDataProvider, BookingAppointmentDataProvider>();
        services.AddTransient<IReExamAppointmentDataProvider, ReExamAppointmentDataProvider>();
        services.AddTransient<IReferralDataProvider, ReferralDataProvider>();
        services.AddTransient<IReferralDoctorDataProvider, ReferralDoctorDataProvider>();

        services.AddTransient<IRoomAllocationDataProvider, RoomAllocationDataProvider>();
        services.AddTransient<IRoomAssignmentDataProvider, RoomAssignmentDataProvider>();
        services.AddTransient<IDepartmentDataProvider, DepartmentDataProvider>();
        services.AddTransient<IRoomDataProvider, RoomDataProvider>();

        services.AddTransient<IDeviceInventoryDataProvider, DeviceInventoryDataProvider>();
        services.AddTransient<IDrugDataProvider, DrugDataProvider>();
        services.AddTransient<IDrugInventoryDataProvider, DrugInventoryDataProvider>();
        services.AddTransient<IDrugPrescriptionDataProvider, DrugPrescriptionDataProvider>();
        services.AddTransient<IGoodSupplingDataProvider, GoodSupplingDataProvider>();
        services.AddTransient<IImportationDataProvider, ImportationDataProvider>();
        services.AddTransient<IStorageDataProvider, StorageDataProvider>();

        services.AddTransient<IAssignmentHistoryDataProvider, AssignmentHistoryDataProvider>();
        services.AddTransient<IDiagnosisDataProvider, DiagnosisDataProvider>();
        services.AddTransient<IDiagnosisTreatmentDataProvider, DiagnosisTreatmentDataProvider>();
        services.AddTransient<IICDDataProvider, ICDDataProvider>();
        services.AddTransient<IMedicalExamDataProvider, MedicalExamDataProvider>();
        services.AddTransient<IMedicalExamEposodeDataProvider, MedicalExamEposodeDataProvider>();
        services.AddTransient<ITreatmentDataProvider, TreatmentDataProvider>();
        services.AddTransient<ITreatmentExamEpisodeDataProvider, TreatmentExamEpisodeDataProvider>();

        services.AddTransient<IAnalysisTestDataProvider, AnalysisTestDataProvider>();
        services.AddTransient<IDeviceServiceDataProvider, DeviceServiceDataProvider>();
        services.AddTransient<IMedicalDeviceDataProvider, MedicalDeviceDataProvider>();
        services.AddTransient<IServiceDataProvider, ServiceDataProvider>();
    }
    #endregion
}
﻿namespace HospitalManagementSystem.ServiceProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemServicesProvider(this IServiceCollection services)
    {
        //services.AddTransient<Func<IdentityContainerEnum, BlobContainerClient>>(provider => container =>
        //{
        //    var config = provider.GetRequiredService<IOptionsMonitor<IdentityAzureStorageConfig>>().CurrentValue;
        //    switch (container)
        //    {
        //        case IdentityContainerEnum.AvatarContainer:
        //            return new BlobContainerClient(config.BlobConnectionString, config.AvatarStorage);

        //        case IdentityContainerEnum.PhotoContainer:
        //            return new BlobContainerClient(config.BlobConnectionString, config.PhotoStorage);

        //        default:
        //            return new BlobContainerClient(config.BlobConnectionString, config.PhotoStorage);
        //    }
        //});

        //services.AddSingleton((provider) =>
        //{
        //    var config = provider.GetRequiredService<IOptionsMonitor<IdentityAzureStorageConfig>>().CurrentValue;
        //    return new StorageSharedKeyCredential(config.AccountName, config.AccountKey);
        //});

        services.AddTransient<HMSServiceContext>();

        services.AddTransient<IBookingAppointmentServiceProvider,   BookingAppointmentServiceProvider>()
                .AddTransient<IReExamAppointmentServiceProvider,    ReExamAppointmentServiceProvider>()
                .AddTransient<IReferralServiceProvider,             ReferralServiceProvider>()
                .AddTransient<IReferralDoctorServiceProvider,       ReferralDoctorServiceProvider>();

        services.AddTransient<IRoomAllocationServiceProvider,   RoomAllocationServiceProvider>()
                //.AddTransient<IRoomAssignmentServiceProvider,   RoomAssignmentServiceProvider>()
                .AddTransient<IDepartmentServiceProvider,       DepartmentServiceProvider>()
                .AddTransient<IRoomServiceProvider,             RoomServiceProvider>();

        services.AddTransient<IDeviceInventoryServiceProvider,  DeviceInventoryServiceProvider>()
                .AddTransient<IDrugServiceProvider,             DrugServiceProvider>()
                .AddTransient<IDrugInventoryServiceProvider,    DrugInventoryServiceProvider>()
                .AddTransient<IDrugPrescriptionServiceProvider, DrugPrescriptionServiceProvider>()
                .AddTransient<IImportationServiceProvider,      ImportationServiceProvider>()
                .AddTransient<IStorageServiceProvider,          StorageServiceProvider>();

        services.AddTransient<IAssignmentHistoryServiceProvider,    AssignmentHistoryServiceProvider>()
                .AddTransient<IDiagnosisServiceProvider,            DiagnosisServiceProvider>()
                .AddTransient<IDiagnosisTreatmentServiceProvider,   DiagnosisTreatmentServiceProvider>()
                .AddTransient<IICDCodeServiceProvider,              ICDCodeServiceProvider>()
                .AddTransient<IICDCodeVersionServiceProvider,       ICDCodeVersionServiceProvider>()
                .AddTransient<IICDVersionServiceProvider,           ICDVersionServiceProvider>()
                .AddTransient<IDiseasesServiceProvider,             DiseasesServiceProvider>()
                .AddTransient<IMedicalExamServiceProvider,          MedicalExamServiceProvider>()
                .AddTransient<IMedicalExamEpisodeServiceProvider,   MedicalExamEpisodeServiceProvider>()
                .AddTransient<ITreatmentServiceProvider,            TreatmentServiceProvider>();
        //services.AddTransient<ITreatmentExamEpisodeDataProvider, TreatmentExamEpisodeDataProvider>();

        services.AddTransient<IAnalysisTestServiceProvider,     AnalysisTestServiceProvider>()
                .AddTransient<IDeviceServiceServiceProvider,    DeviceServiceServiceProvider>()
                .AddTransient<IMedicalDeviceServiceProvider,    MedicalDeviceServiceProvider>()
                .AddTransient<IServiceServiceProvider,          ServiceServiceProvider>();

        services.AddTransient<IBillServiceProvider, BillServiceProvider>();
    }



    public static void AddHospitalManagementSystemServicesProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHospitalManagementSystemServicesProvider();
    }
    #endregion
}

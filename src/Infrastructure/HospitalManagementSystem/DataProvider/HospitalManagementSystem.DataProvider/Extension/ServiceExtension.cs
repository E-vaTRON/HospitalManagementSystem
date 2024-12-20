﻿using HospitalManagementSystem.Application;
using Microsoft.Extensions.Configuration;

namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataProviders(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient<DataContext>();

        services.AddTransient<IBookingAppointmentDataProvider,  BookingAppointmentDataProvider>()
                .AddTransient<IReExamAppointmentDataProvider,   ReExamAppointmentDataProvider>()
                .AddTransient<IReferralDataProvider,            ReferralDataProvider>()
                .AddTransient<IReferralDoctorDataProvider,      ReferralDoctorDataProvider>();

        services.AddTransient<IRoomAllocationDataProvider,  RoomAllocationDataProvider>()
                //.AddTransient<IRoomAssignmentDataProvider,  RoomAssignmentDataProvider>()
                .AddTransient<IDepartmentDataProvider,      DepartmentDataProvider>()
                .AddTransient<IRoomDataProvider,            RoomDataProvider>();

        services.AddTransient<IDeviceInventoryDataProvider,     DeviceInventoryDataProvider>()
                .AddTransient<IDrugDataProvider,                DrugDataProvider>()
                .AddTransient<IDrugInventoryDataProvider,       DrugInventoryDataProvider>()
                .AddTransient<IDrugPrescriptionDataProvider,    DrugPrescriptionDataProvider>()
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

        services.AddTransient<IAnalysisTestDataProvider,        AnalysisTestDataProvider>()
                .AddTransient<IMeasurementUnitDataProvider,     MeasurementUnitDataProvider>()
                .AddTransient<IFormTypeDataProvider,            FormTypeDataProvider>()
                .AddTransient<IServiceEpisodeDataProvider,      ServiceEpisodeDataProvider>()
                .AddTransient<IMedicalDeviceFormDataProvider,   MedicalDeviceFormDataProvider>()
                .AddTransient<IDeviceUnitDataProvider,          DeviceUnitDataProvider>()
                .AddTransient<IMedicalDeviceDataProvider,       MedicalDeviceDataProvider>()
                .AddTransient<IMedicalServiceDataProvider,      MedicalServiceDataProvider>();

        services.AddTransient<IBillDataProvider, BillDataProvider>();
    }
    #endregion
}
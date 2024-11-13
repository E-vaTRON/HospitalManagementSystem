namespace HospitalManagementSystem.DataProvider;

public class SeedServiceProvider : ISeedProvider
{
    #region [ Fields ]
    private readonly DataContext DataContexts;
    private readonly HospitalManagementSystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public SeedServiceProvider( DataContext dataContexts,
                         IDbContextFactory<HospitalManagementSystemDbContext> dbContextFactory)
    {
        DataContexts = dataContexts;
        DbContext = dbContextFactory.CreateDbContext();
    }
    #endregion

    #region [ Methods ]
    public async Task EnsureDatabaseAsync(Action action = null!)
    {
        if (action != null)
        {
            action.Invoke();
        }
        await DbContext.Database.EnsureCreatedAsync();
    }

    public async Task DropDatabaseAsync(Action action = null!)
    {
        if (action != null)
        {
            action.Invoke();
        }

        await DbContext.Database.EnsureDeletedAsync();
    }

    public async Task ClearDatabaseAsync()
    {
        DbContext.RemoveRange(await this.DataContexts.Bills.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.DrugPrescriptions.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.AnalysisTests.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.ServiceEpisodes.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.Diagnoses.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.AssignmentHistories.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.MedicalExamEpisodes.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.MedicalExams.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.BookingAppointments.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.Rooms.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.Departments.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.DrugInventories.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.DeviceInventories.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.Storages.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.Importations.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.Drugs.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.DeviceUnits.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.MeasurementUnits.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.MedicalDeviceForms.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.MedicalDevices.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.MedicalServices.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.FormTypes.FindAllAsync());

        DbContext.RemoveRange(await this.DataContexts.Treatments.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.ICDCodeVersions.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.ICDVersions.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.ICDCodes.FindAllAsync());
        DbContext.RemoveRange(await this.DataContexts.Diseases.FindAllAsync());
    }

    public async Task SeedDatabaseAsync()
    {
        await DataContexts.Diseases.SeedAsync(SeedProvider.Seed.Diseases);
        await DataContexts.ICDVersions.SeedAsync(SeedProvider.Seed.ICDVersions);
        await DataContexts.ICDCodes.SeedAsync(SeedProvider.Seed.ICDCodes);
        await DataContexts.ICDCodeVersions.SeedAsync(SeedProvider.Seed.ICDCodeVersions);
        await DataContexts.Treatments.SeedAsync(SeedProvider.Seed.Treatments);

        await DataContexts.FormTypes.SeedAsync(SeedProvider.Seed.FormTypes);
        await DataContexts.MedicalServices.SeedAsync(SeedProvider.Seed.MedicalServices);
        await DataContexts.MedicalDevices.SeedAsync(SeedProvider.Seed.MedicalDevices);
        await DataContexts.MedicalDeviceForms.SeedAsync(SeedProvider.Seed.MedicalDeviceForms);
        await DataContexts.MeasurementUnits.SeedAsync(SeedProvider.Seed.MeasurementUnits);
        await DataContexts.DeviceUnits.SeedAsync(SeedProvider.Seed.DeviceUnits);

        await DataContexts.Drugs.SeedAsync(SeedProvider.Seed.Drugs);
        await DataContexts.Importations.SeedAsync(SeedProvider.Seed.Importations);

        await DataContexts.Storages.SeedAsync(SeedProvider.Seed.Storages);
        await DataContexts.DeviceInventories.SeedAsync(SeedProvider.Seed.DeviceInventories);
        await DataContexts.DrugInventories.SeedAsync(SeedProvider.Seed.DrugInventories);

        await DataContexts.Departments.SeedAsync(SeedProvider.Seed.Departments);
        await DataContexts.Rooms.SeedAsync(SeedProvider.Seed.Rooms);

        await DataContexts.BookingAppointments.SeedAsync(SeedProvider.Seed.BookingAppointments);
        await DataContexts.MedicalExams.SeedAsync(SeedProvider.Seed.MedicalExams);
        await DataContexts.MedicalExamEpisodes.SeedAsync(SeedProvider.Seed.MedicalExamEpisodes);
        await DataContexts.AssignmentHistories.SeedAsync(SeedProvider.Seed.AssignmentHistories);
        await DataContexts.Diagnoses.SeedAsync(SeedProvider.Seed.Diagnoses);
        await DataContexts.ServiceEpisodes.SeedAsync(SeedProvider.Seed.ServiceEpisodes);
        await DataContexts.AnalysisTests.SeedAsync(SeedProvider.Seed.AnalysisTests);
        await DataContexts.DrugPrescriptions.SeedAsync(SeedProvider.Seed.DrugPrescriptions);

        await DataContexts.Bills.SeedAsync(SeedProvider.Seed.Bills);
    }
    #endregion
}

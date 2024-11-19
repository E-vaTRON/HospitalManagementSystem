using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HospitalManagementSystem.DataProvider;

public class SeedServiceProvider : ISeedProvider
{
    #region [ Fields ]
    private readonly DataContext DataContexts;
    private readonly HospitalManagementSystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public SeedServiceProvider(DataContext dataContexts,
                               HospitalManagementSystemDbContext dbContextFactory)
    {
        DataContexts = dataContexts;
        DbContext = dbContextFactory;
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
        var strategy = DbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await DbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await DataContexts.Diseases.SeedAsync(SeedProvider.Seed.Diseases, false);
                    await DataContexts.ICDVersions.SeedAsync(SeedProvider.Seed.ICDVersions, false);
                    await DataContexts.ICDCodes.SeedAsync(SeedProvider.Seed.ICDCodes, false);
                    await DataContexts.ICDCodeVersions.SeedAsync(SeedProvider.Seed.ICDCodeVersions, false);
                    await DataContexts.Treatments.SeedAsync(SeedProvider.Seed.Treatments, false);

                    await DataContexts.FormTypes.SeedAsync(SeedProvider.Seed.FormTypes, false);
                    await DataContexts.MedicalServices.SeedAsync(SeedProvider.Seed.MedicalServices, false);
                    await DataContexts.MedicalDevices.SeedAsync(SeedProvider.Seed.MedicalDevices, false);
                    await DataContexts.MedicalDeviceForms.SeedAsync(SeedProvider.Seed.MedicalDeviceForms, false);
                    await DataContexts.MeasurementUnits.SeedAsync(SeedProvider.Seed.MeasurementUnits, false);
                    await DataContexts.DeviceUnits.SeedAsync(SeedProvider.Seed.DeviceUnits, false);

                    await DataContexts.Drugs.SeedAsync(SeedProvider.Seed.Drugs, false);
                    await DataContexts.Importations.SeedAsync(SeedProvider.Seed.Importations, false);

                    await DataContexts.Storages.SeedAsync(SeedProvider.Seed.Storages, false);
                    await DataContexts.DeviceInventories.SeedAsync(SeedProvider.Seed.DeviceInventories, false);
                    await DataContexts.DrugInventories.SeedAsync(SeedProvider.Seed.DrugInventories, false);

                    await DataContexts.Departments.SeedAsync(SeedProvider.Seed.Departments, false);
                    await DataContexts.Rooms.SeedAsync(SeedProvider.Seed.Rooms, false);

                    await DataContexts.BookingAppointments.SeedAsync(SeedProvider.Seed.BookingAppointments, false);
                    await DataContexts.MedicalExams.SeedAsync(SeedProvider.Seed.MedicalExams, false);
                    await DataContexts.MedicalExamEpisodes.SeedAsync(SeedProvider.Seed.MedicalExamEpisodes, false);
                    await DataContexts.AssignmentHistories.SeedAsync(SeedProvider.Seed.AssignmentHistories, false);
                    await DataContexts.Diagnoses.SeedAsync(SeedProvider.Seed.Diagnoses, false);
                    await DataContexts.ServiceEpisodes.SeedAsync(SeedProvider.Seed.ServiceEpisodes, false);
                    await DataContexts.AnalysisTests.SeedAsync(SeedProvider.Seed.AnalysisTests, false);
                    await DataContexts.DrugPrescriptions.SeedAsync(SeedProvider.Seed.DrugPrescriptions, false);

                    await DataContexts.Bills.SeedAsync(SeedProvider.Seed.Bills, false);

                    await DbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Output the exception details to the debug window
                    Debug.WriteLine($"An error occurred during database seeding: {ex.Message}");
                    Debug.WriteLine(ex.StackTrace);

                    // Rollback transaction on error
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        });
    }
    #endregion
}

namespace HospitalManagementSystem.DataProvider;

public class SeedDataProvider : ISeedDataProvider
{
    #region [ Fields ]
    private readonly IMapper Mapper;
    private readonly HospitalManagementSystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public SeedDataProvider(IMapper mapper,
                            HospitalManagementSystemDbContext dbContextFactory)
    {
        Mapper = mapper;
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
        DbContext.RemoveRange(await this.DbContext.Bills.ToListAsync());

        DbContext.RemoveRange(await DbContext.DrugPrescriptions.ToListAsync());
        DbContext.RemoveRange(await DbContext.AnalysisTests.ToListAsync());
        DbContext.RemoveRange(await DbContext.ServiceEpisodes.ToListAsync());
        DbContext.RemoveRange(await DbContext.Diagnoses.ToListAsync());
        DbContext.RemoveRange(await DbContext.AssignmentHistories.ToListAsync());
        DbContext.RemoveRange(await DbContext.MedicalExamEpisodes.ToListAsync());
        DbContext.RemoveRange(await DbContext.MedicalExams.ToListAsync());
        DbContext.RemoveRange(await DbContext.BookingAppointments.ToListAsync());

        DbContext.RemoveRange(await DbContext.Rooms.ToListAsync());
        DbContext.RemoveRange(await DbContext.Departments.ToListAsync());

        DbContext.RemoveRange(await DbContext.DrugInventories.ToListAsync());
        DbContext.RemoveRange(await DbContext.DeviceInventories.ToListAsync());
        DbContext.RemoveRange(await DbContext.Storages.ToListAsync());

        DbContext.RemoveRange(await DbContext.Importations.ToListAsync());
        DbContext.RemoveRange(await DbContext.Drugs.ToListAsync());

        DbContext.RemoveRange(await DbContext.DeviceUnits.ToListAsync());
        DbContext.RemoveRange(await DbContext.MeasurementUnits.ToListAsync());
        DbContext.RemoveRange(await DbContext.MedicalDeviceForms.ToListAsync());
        DbContext.RemoveRange(await DbContext.MedicalDevices.ToListAsync());
        DbContext.RemoveRange(await DbContext.MedicalServices.ToListAsync());
        DbContext.RemoveRange(await DbContext.FormTypes.ToListAsync());

        DbContext.RemoveRange(await DbContext.Treatments.ToListAsync());
        DbContext.RemoveRange(await DbContext.ICDCodeVersions.ToListAsync());
        DbContext.RemoveRange(await DbContext.ICDVersions.ToListAsync());
        DbContext.RemoveRange(await DbContext.ICDCodes.ToListAsync());
        DbContext.RemoveRange(await DbContext.Diseases.ToListAsync());
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
                    await DbContext.Diseases.SeedAsync(SeedProvider.Seed.Diseases, Mapper);
                    await DbContext.ICDVersions.SeedAsync(SeedProvider.Seed.ICDVersions, Mapper);
                    await DbContext.ICDCodes.SeedAsync(SeedProvider.Seed.ICDCodes, Mapper);
                    await DbContext.ICDCodeVersions.SeedAsync(SeedProvider.Seed.ICDCodeVersions, Mapper);
                    await DbContext.Treatments.SeedAsync(SeedProvider.Seed.Treatments, Mapper);

                    await DbContext.FormTypes.SeedAsync(SeedProvider.Seed.FormTypes, Mapper);
                    await DbContext.MedicalServices.SeedAsync(SeedProvider.Seed.MedicalServices, Mapper);
                    await DbContext.MedicalDevices.SeedAsync(SeedProvider.Seed.MedicalDevices, Mapper);
                    await DbContext.MedicalDeviceForms.SeedAsync(SeedProvider.Seed.MedicalDeviceForms, Mapper);
                    await DbContext.MeasurementUnits.SeedAsync(SeedProvider.Seed.MeasurementUnits, Mapper);
                    await DbContext.DeviceUnits.SeedAsync(SeedProvider.Seed.DeviceUnits, Mapper);

                    await DbContext.Drugs.SeedAsync(SeedProvider.Seed.Drugs, Mapper);
                    await DbContext.Importations.SeedAsync(SeedProvider.Seed.Importations, Mapper);

                    await DbContext.Storages.SeedAsync(SeedProvider.Seed.Storages, Mapper);
                    await DbContext.DeviceInventories.SeedAsync(SeedProvider.Seed.DeviceInventories, Mapper);
                    await DbContext.DrugInventories.SeedAsync(SeedProvider.Seed.DrugInventories, Mapper);

                    await DbContext.Departments.SeedAsync(SeedProvider.Seed.Departments, Mapper);
                    await DbContext.Rooms.SeedAsync(SeedProvider.Seed.Rooms, Mapper);

                    await DbContext.BookingAppointments.SeedAsync(SeedProvider.Seed.BookingAppointments, Mapper);
                    await DbContext.MedicalExams.SeedAsync(SeedProvider.Seed.MedicalExams, Mapper);
                    await DbContext.MedicalExamEpisodes.SeedAsync(SeedProvider.Seed.MedicalExamEpisodes, Mapper);
                    await DbContext.AssignmentHistories.SeedAsync(SeedProvider.Seed.AssignmentHistories, Mapper);
                    await DbContext.Diagnoses.SeedAsync(SeedProvider.Seed.Diagnoses, Mapper);
                    await DbContext.ServiceEpisodes.SeedAsync(SeedProvider.Seed.ServiceEpisodes, Mapper);
                    await DbContext.AnalysisTests.SeedAsync(SeedProvider.Seed.AnalysisTests, Mapper);
                    await DbContext.DrugPrescriptions.SeedAsync(SeedProvider.Seed.DrugPrescriptions, Mapper);

                    await DbContext.Bills.SeedAsync(SeedProvider.Seed.Bills, Mapper);

                    await DbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception exception)
                {
                    // Output the exception details to the debug window
                    Debug.WriteLine($"An error occurred during database seeding: {exception.Message}");
                    Debug.WriteLine(exception.StackTrace);

                    // Rollback transaction on error
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        });
    }
    #endregion
}

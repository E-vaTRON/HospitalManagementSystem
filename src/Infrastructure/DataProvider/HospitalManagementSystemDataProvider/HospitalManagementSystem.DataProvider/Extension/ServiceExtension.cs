namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void HospitalManagementSystemDataProviders<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        //// Core
        //services.AddSingleton<DataContext>();
        //services.AddSingleton<IDatabaseProvider, DatabaseProvider>();

        //// Core Data
        //services.AddTransient<ICertificationDataProvider, CertificationDataProvider<TDbContext>>();
        //services.AddTransient<IResourceDataProvider, ResourceDataProvider<TDbContext>>();
        //services.AddTransient<IExamDataProvider, ExamDataProvider<TDbContext>>();
        //services.AddTransient<IExamTopicDataProvider, ExamTopicDataProvider<TDbContext>>();
        //services.AddTransient<IExamQuestionDataProvider, ExamQuestionDataProvider<TDbContext>>();
        //services.AddTransient<IExamAnswerDataProvider, ExamAnswerDataProvider<TDbContext>>();
        //services.AddTransient<IStudentDataProvider, StudentDataProvider<TDbContext>>();
        //services.AddTransient<IStudentExamDataProvider, StudentExamDataProvider<TDbContext>>();
        //services.AddTransient<IStudentAnswerDataProvider, StudentAnswerDataProvider<TDbContext>>();
    }
    #endregion
}
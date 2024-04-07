namespace HospitalManagementSystem.DataProvider;
public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemDataProviders<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddTransient<IBookingAppointmentDataProvider, BookingAppointmentDataProvider>();
        services.AddTransient<IReExamAppointmentDataProvider, ReExamAppointmentDataProvider>();
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
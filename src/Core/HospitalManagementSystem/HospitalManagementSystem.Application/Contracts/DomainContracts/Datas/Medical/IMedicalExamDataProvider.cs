namespace HospitalManagementSystem.Application;

public interface IMedicalExamDataProvider : IDataProviderBase<MedicalExam, string>
{
    Task<IEnumerable<MedicalExam>> FindByBookingIdAsync(string[] ids, CancellationToken cancellationToken = default!);
}

namespace HospitalManagementSystem.Application;

public interface IMedicalExamServiceProvider : IServiceProviderBase<OutputMedicalExamDTO, InputMedicalExamDTO, string>
{
    Task<IEnumerable<OutputMedicalExamDTO>> FindByBookingIdAsync(string[] ids, CancellationToken cancellationToken = default!);
}

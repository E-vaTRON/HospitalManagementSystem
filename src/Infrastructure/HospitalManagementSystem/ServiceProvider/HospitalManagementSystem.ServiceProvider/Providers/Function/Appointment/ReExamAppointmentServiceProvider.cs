using CoreReExamAppointment = HospitalManagementSystem.Domain.ReExamAppointment;

namespace HospitalManagementSystem.ServiceProvider;

public class ReExamAppointmentServiceProvider : ServiceProviderBase<CoreReExamAppointment>, IReExamAppointmentServiceProvider
{
    public ReExamAppointmentServiceProvider(ReExamAppointmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}

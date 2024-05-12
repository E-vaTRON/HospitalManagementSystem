using CoreReExamAppointment = HospitalManagementSystem.Domain.ReExamAppointment;
using DTOReExamAppointment = HospitalManagementSystem.Application.ReExamAppointmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ReExamAppointmentServiceProvider : ServiceProviderBase<DTOReExamAppointment, CoreReExamAppointment>, IReExamAppointmentServiceProvider
{
    public ReExamAppointmentServiceProvider(IReExamAppointmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}

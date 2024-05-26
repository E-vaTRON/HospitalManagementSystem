using CoreReExamAppointment = HospitalManagementSystem.Domain.ReExamAppointment;
using DTOReExamAppointmentIn = HospitalManagementSystem.Application.InputReExamAppointmentDTO;
using DTOReExamAppointmentOut = HospitalManagementSystem.Application.OutputReExamAppointmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ReExamAppointmentServiceProvider : ServiceProviderBase<DTOReExamAppointmentOut, DTOReExamAppointmentIn, CoreReExamAppointment>, IReExamAppointmentServiceProvider
{
    public ReExamAppointmentServiceProvider(IReExamAppointmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
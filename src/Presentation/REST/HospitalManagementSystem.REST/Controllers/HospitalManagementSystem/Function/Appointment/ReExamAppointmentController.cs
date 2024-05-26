using DTOReExamAppointmentIn = HospitalManagementSystem.Application.InputReExamAppointmentDTO;
using DTOReExamAppointmentOut = HospitalManagementSystem.Application.OutputReExamAppointmentDTO;

namespace HospitalManagementSystem.REST;

public class ReExamAppointmentController : BaseHMSController<DTOReExamAppointmentOut, DTOReExamAppointmentIn>
{
    public ReExamAppointmentController(IReExamAppointmentServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
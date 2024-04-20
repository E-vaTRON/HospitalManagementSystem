using CoreReExamAppointment = HospitalManagementSystem.Domain.ReExamAppointment;
using DataReExamAppointment = HospitalManagementSystem.DataProvider.ReExamAppointment;

namespace HospitalManagementSystem.DataProvider;

public class ReExamAppointmentDataProvider : DataProviderBase<CoreReExamAppointment, DataReExamAppointment>, IReExamAppointmentServiceProvider
{
    public ReExamAppointmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}

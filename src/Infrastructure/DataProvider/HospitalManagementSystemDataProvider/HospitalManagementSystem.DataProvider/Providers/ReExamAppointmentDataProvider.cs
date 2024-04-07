using CoreReExamAppointment = HospitalManagementSystem.Domain.ReExamAppointment;
using DataReExamAppointment = HospitalManagementSystem.DataProvider.ReExamAppointment;

namespace HospitalManagementSystem.DataProvider;

public class ReExamAppointmentDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreReExamAppointment, DataReExamAppointment>, IReExamAppointmentDataProvider
    where TDbContext : DbContext
{
    public ReExamAppointmentDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}

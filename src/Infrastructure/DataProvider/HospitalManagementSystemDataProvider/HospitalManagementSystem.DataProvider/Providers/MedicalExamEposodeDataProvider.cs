using CoreMedicalExamEposode = HospitalManagementSystem.Domain.MedicalExamEposode;
using DataMedicalExamEposode = HospitalManagementSystem.DataProvider.MedicalExamEposode;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEposodeDataProvider : DataProviderBase<CoreMedicalExamEposode, DataMedicalExamEposode>, IMedicalExamEposodeDataProvider
{
    public MedicalExamEposodeDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}

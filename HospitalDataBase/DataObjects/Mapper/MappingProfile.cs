using AutoMapper;
using HospitalDataBase.Core.Entities;

namespace HospitalDataBase.DataObjects.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Analysation, AnalysationDTO>();
            CreateMap<AnalysationDTO, Analysation>()
                .ForMember(a => a.ID, a => a.Ignore())
                .ForMember(a => a.DateOfBirth, a => a.Ignore());
        }
    }
}

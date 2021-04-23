using AutoMapper;
using HospitalDataBase.Core.Entities;
using HospitalDataBase.Core.Entities.UnitType;
using System;

namespace HospitalDataBase.DataObjects.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AnalysationDTO, Analysation>();
            CreateMap<Analysation, AnalysationDTO>()
                .ForMember(d => d.ID, o => o.Ignore());

            CreateMap<DeviceServiceDTO, DeviceService>()
                .ForMember(d => d.Unit, o => o.MapFrom(s => Enum.GetName(typeof(Units), s.Unit)));
            CreateMap<DeviceService, DeviceServiceDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit.ToString()));

            CreateMap<DoctorListDTO, DoctorList>();
            CreateMap<DoctorList, DoctorListDTO>()
                .ForMember(d => d.ID, o => o.Ignore());

            CreateMap<EmployeeListDTO, EmployeeList>();
            CreateMap<EmployeeList, EmployeeListDTO>()
                .ForMember(d => d.ID, o => o.Ignore());

            CreateMap<DrugDTO, Drug>()
                .ForMember(d => d.Unit,o => o.MapFrom(s => Enum.GetName(typeof(Units), s.Unit)));
            CreateMap<Drug, DrugDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit.ToString()));


        }
    }
}

using AutoMapper;
using HospitalDataBase.Core.Entities;
using HospitalDataBase.Core.Entities.UnitType;
using System;
using System.Globalization;

namespace HospitalDataBase.DataObjects.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AnalysationTestDTO, AnalysationTest>();
            CreateMap<AnalysationTest, AnalysationTestDTO>()
                .ForMember(d => d.ID, o => o.Ignore());

            CreateMap<DeviceServiceDTO, DeviceService>()
                .ForMember(d => d.Unit, o => o.MapFrom(s => Enum.GetName(typeof(Units), s.Unit)));
            CreateMap<DeviceService, DeviceServiceDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit.ToString()));

            CreateMap<DoctorListDTO, DoctorList>()
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => DateTime.Parse(s.DateJoin, null, DateTimeStyles.AssumeUniversal)));
            CreateMap<DoctorList, DoctorListDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => s.DateJoin.ToString("yyyy-MM-dd")));

            CreateMap<EmployeeListDTO, EmployeeList>()
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => DateTime.Parse(s.DateJoin, null, DateTimeStyles.AssumeUniversal)));
            CreateMap<EmployeeList, EmployeeListDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => s.DateJoin.ToString("yyyy-MM-dd")));

            CreateMap<DrugDTO, Drug>()
                .ForMember(d => d.Unit,o => o.MapFrom(s => Enum.GetName(typeof(Units), s.Unit)));
            CreateMap<Drug, DrugDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit.ToString()));

            CreateMap<GoodsExportationDTO, GoodsExportation>()
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => DateTime.Parse(s.RecordDay, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => DateTime.Parse(s.ExpiryDate, null, DateTimeStyles.AssumeUniversal)));
            CreateMap<GoodsExportation, GoodsExportationDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => s.RecordDay.ToString("yyyy-MM-dd")))
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => s.ExpiryDate.ToString("yyyy-MM-dd")));

            CreateMap<GoodsImportationDTO, GoodsImportation>()
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => DateTime.Parse(s.RecordDay, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ReceiptDay, o => o.MapFrom(s => DateTime.Parse(s.ReceiptDay, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => DateTime.Parse(s.ExpiryDate, null, DateTimeStyles.AssumeUniversal)));
            CreateMap<GoodsImportation, GoodsImportationDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => s.RecordDay.ToString("yyyy-MM-dd")))
                .ForMember(d => d.ReceiptDay, o => o.MapFrom(s => s.ReceiptDay.ToString("yyyy-MM-dd")))
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => s.ExpiryDate.ToString("yyyy-MM-dd")));

            CreateMap<HistoryMedicalExamDTO, HistoryMedicalExam>()
                .ForMember(d => d.DateTakeExam, o => o.MapFrom(s => DateTime.Parse(s.DateTakeExam, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.DateReExam, o => o.MapFrom(s => DateTime.Parse(s.DateReExam, null, DateTimeStyles.AssumeUniversal)));
            CreateMap<HistoryMedicalExam, HistoryMedicalExamDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.DateTakeExam, o => o.MapFrom(s => s.DateTakeExam.ToString("yyyy-MM-dd")))
                .ForMember(d => d.DateReExam, o => o.MapFrom(s => s.DateReExam.ToString("yyyy-MM-dd")));

            CreateMap<InventoryDTO, Inventory>()
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => DateTime.Parse(s.ExpiryDate, null, DateTimeStyles.AssumeUniversal)));
            CreateMap<Inventory, InventoryDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => s.ExpiryDate.ToString("yyyy-MM-dd")));

            CreateMap<PatientDTO, Patient>()
                .ForMember(d => d.DayOfBirth, o => o.MapFrom(s => DateTime.Parse(s.DayOfBirth, null, DateTimeStyles.AssumeUniversal)));
            CreateMap<Patient, PatientDTO>()
                .ForMember(d => d.ID, o => o.Ignore())
                .ForMember(d => d.DayOfBirth, o => o.MapFrom(s => s.DayOfBirth.ToString("yyyy-MM-dd")));
        }
    }
}

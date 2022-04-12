using AutoMapper;
using Core.Entities.UserIdentifile;
using HospitalDataBase.Core.Entities;
using HospitalDataBase.Core.Entities.UnitType;
using HospitalDataBase.DataObjects.CreateDTO;
using HospitalDataBase.DataObjects.ReceiveDTO;
using System;
using System.Globalization;
using System.Linq;

namespace HospitalDataBase.DataObjects.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AnalysationTestDTO, AnalysationTest>()
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<AnalysationTest, AnalysationTestDTO>();
            CreateMap<CreateAnalysationTestDTO, AnalysationTest>()
                .ForMember(d => d.DeviceID, o => o.Ignore())
                .ForMember(d => d.ExamID, o => o.Ignore());
            CreateMap<AnalysationTest, ReceiveAnalysationTestDTO>()
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.HistoryMedicalExam!.Patient!.LastName))
                .ForMember(d => d.Service, o => o.MapFrom(s => s.DeviceService!.Service));

            CreateMap<DeviceServiceDTO, DeviceService>()
                .ForMember(d => d.Unit, o => o.MapFrom(s => Enum.GetName(typeof(Units), s.Unit)))
                .ForMember(d => d.ResultFromType, o => o.MapFrom(s => Enum.GetName(typeof(FormTypes), s.ResultFromType)))
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<DeviceService, DeviceServiceDTO>()
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit.ToString()))
                .ForMember(d => d.ResultFromType, o => o.MapFrom(s => s.ResultFromType.ToString()));

            CreateMap<DoctorListDTO, Doctor>()
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => DateTime.Parse(s.DateJoin, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.DoctorID, o => o.Ignore());
            CreateMap<Doctor, DoctorListDTO>()
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => s.DateJoin.ToString("yyyy-MM-dd")));

            CreateMap<EmployeeListDTO, Employee>()
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => DateTime.Parse(s.DateJoin, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.EmployeeID, o => o.Ignore());
            CreateMap<Employee, EmployeeListDTO>()
                .ForMember(d => d.DateJoin, o => o.MapFrom(s => s.DateJoin.ToString("yyyy-MM-dd")));

            CreateMap<DrugDTO, Drug>()
                .ForMember(d => d.Unit,o => o.MapFrom(s => Enum.GetName(typeof(Units), s.Unit)))
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<Drug, DrugDTO>()
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Unit.ToString()));

            CreateMap<PatientTransactionHistoryDTO, PatientTransactionHistory>()
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => DateTime.Parse(s.RecordDay, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<PatientTransactionHistory, PatientTransactionHistoryDTO>()
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => s.RecordDay.ToString("yyyy-MM-dd")));

            CreateMap<GoodsImportationDTO, GoodsImportation>()
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => DateTime.Parse(s.RecordDay, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ReceiptDay, o => o.MapFrom(s => DateTime.Parse(s.ReceiptDay, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => DateTime.Parse(s.ExpiryDate, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<GoodsImportation, GoodsImportationDTO>()
                .ForMember(d => d.RecordDay, o => o.MapFrom(s => s.RecordDay.ToString("yyyy-MM-dd")))
                .ForMember(d => d.ReceiptDay, o => o.MapFrom(s => s.ReceiptDay.ToString("yyyy-MM-dd")))
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => s.ExpiryDate.ToString("yyyy-MM-dd")));

            CreateMap<HistoryMedicalExamDTO, HistoryMedicalExam>()
                .ForMember(d => d.DateTakeExam, o => o.MapFrom(s => DateTime.Parse(s.DateTakeExam, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.DateReExam, o => o.MapFrom(s => DateTime.Parse(s.DateReExam, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<HistoryMedicalExam, HistoryMedicalExamDTO>()
                .ForMember(d => d.DateTakeExam, o => o.MapFrom(s => s.DateTakeExam.ToString("yyyy-MM-dd")))
                .ForMember(d => d.DateReExam, o => o.MapFrom(s => s.DateReExam.ToString("yyyy-MM-dd")));

            CreateMap<InventoryDTO, Inventory>()
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => DateTime.Parse(s.ExpiryDate, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<Inventory, InventoryDTO>()
                .ForMember(d => d.ExpiryDate, o => o.MapFrom(s => s.ExpiryDate.ToString("yyyy-MM-dd")));

            CreateMap<PatientDTO, Patient>()
                .ForMember(d => d.DayOfBirth, o => o.MapFrom(s => DateTime.Parse(s.DayOfBirth, null, DateTimeStyles.AssumeUniversal)))
                .ForMember(d => d.ID, o => o.Ignore());
            CreateMap<Patient, PatientDTO>()
                .ForMember(d => d.DayOfBirth, o => o.MapFrom(s => s.DayOfBirth.ToString("yyyy-MM-dd")));

            CreateMap<User, UserDTO>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(ur => ur.Role!.Name)));
            CreateMap<UserDTO, User>()
                .ForMember(d => d.Guid, opt => opt.Ignore());
            //CreateMap<CreateUserDTO, User>();
        }
    }
}

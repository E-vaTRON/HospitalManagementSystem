using HospitalDataBase.Core.Entities.UnitType;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<AnalysationTestDTO>))]
    public class AnalysationTestDTO : BaseDTO
    {
        public string PatientID { get; set; } = string.Empty;
        public string DeviceID { get; set; } = string.Empty;
        public string ExamID { get; set; } = string.Empty;
        public string DSymptom { get; set; } = string.Empty;           //triệu chứng lâm sàng
        public string DoctorComment { get; set; } = string.Empty;      // chỉ định
    }
}

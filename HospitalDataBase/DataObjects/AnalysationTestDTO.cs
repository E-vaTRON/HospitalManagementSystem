using HospitalDataBase.Core.Entities.UnitType;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<AnalysationTestDTO>))]
    public class AnalysationTestDTO : BaseDTO
    {
        public string PatientID { get; set; }
        public string DeviceID { get; set; }
        public string ExamID { get; set; }
        public string DSymptom { get; set; }            //triệu chứng lâm sàng
        public string DoctorComment { get; set; }       // chỉ định
        public string ResultFromType { get; set; }    //form kết quả chuẩn đoán 
    }
}

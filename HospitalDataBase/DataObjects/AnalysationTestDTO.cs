using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<AnalysationTestDTO>))]
    public class AnalysationTestDTO : BaseDTO
    {
        public string PatientID { get; set; }       //mã số bệnh nhân
        public string DeviceID { get; set; }
        public string DSymptom { get; set; }        //triệu chứng lâm sàng
        public string DoctorComment { get; set; }   //chỉ định

    }
}

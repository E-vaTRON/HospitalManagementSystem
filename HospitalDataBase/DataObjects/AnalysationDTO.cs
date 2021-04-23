using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<AnalysationDTO>))]
    public class AnalysationDTO : BaseDTO
    {
        public string PatientID { get; set; }       //mã số bệnh nhân
        public string FirstName { get; set; }       //họ
        public string LastName { get; set; }        //tên
        public DateTime DateOfBirth { get; set; }   //năm sinh
        public bool Sex { get; set; }               //giới tính
        public string DSymptom { get; set; }        //triệu chứng lâm sàng
    }
}

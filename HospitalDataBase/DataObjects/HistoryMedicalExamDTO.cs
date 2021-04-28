using System;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;


namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<HistoryMedicalExamDTO>))]
    public class HistoryMedicalExamDTO : BaseDTO
    {
        public string PatientID { get; set; }           //mã số bệnh nhân
        public string DateTakeExam { get; set; }      //ngày khám bệnh
        public string DateReExam { get; set; }        //ngày tái khám
        public string PatientRecipient { get; set; }    //người nhận bệnh
        public string DoctorName { get; set; }          //tên bác sĩ
        public string Diagnose { get; set; }            //chuẩn đoán
        public int ExamID { get; set; }                 //mã số khám bệnh (bốc số)
    }
}

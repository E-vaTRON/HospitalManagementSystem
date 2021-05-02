using System;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;


namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<HistoryMedicalExamDTO>))]
    public class HistoryMedicalExamDTO
    {
        [FromRoute]
        public string ExamID { get; set; }              //mã số khám bệnh
        public string PatientID { get; set; }           //mã số bệnh nhân
        public string DateTakeExam { get; set; }      //ngày khám bệnh
        public string DateReExam { get; set; }        //ngày tái khám
        public string EmployeeID { get; set; }
        public string DoctorID { get; set; }
        public string Diagnose { get; set; }            //chuẩn đoán
        public int LineID { get; set; }                 //bốc số
    }
}

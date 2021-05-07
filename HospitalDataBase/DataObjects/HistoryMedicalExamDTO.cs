using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;


namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<HistoryMedicalExamDTO>))]
    public class HistoryMedicalExamDTO
    {
        [FromRoute]
        public string ExamID { get; set; } = string.Empty;          //mã số khám bệnh
        public string PatientID { get; set; } = string.Empty;       //mã số bệnh nhân
        public string DateTakeExam { get; set; } = string.Empty;    //ngày khám bệnh
        public string DateReExam { get; set; } = string.Empty;      //ngày tái khám
        public string EmployeeID { get; set; } = string.Empty;
        public string DoctorID { get; set; } = string.Empty;
        public string Diagnose { get; set; } = string.Empty;        //chuẩn đoán
        public int LineID { get; set; }                             //bốc số
    }
}

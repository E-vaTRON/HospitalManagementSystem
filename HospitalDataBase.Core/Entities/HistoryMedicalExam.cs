using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class HistoryMedicalExam
    {
        [Key]
        public string ExamID { get; set; }              //mã số khám bệnh
        public string PatientID { get; set; }           //mã số bệnh nhân
        public DateTime DateTakeExam { get; set; }      //ngày khám bệnh
        public DateTime DateReExam { get; set; }        //ngày tái khám
        public string PatientRecipient { get; set; }    //người nhận bệnh
        public string DoctorName { get; set; }          //tên bác sĩ
        public string Diagnose { get; set; }            //chuẩn đoán
        public int LineID { get; set; }                 //bốc số

        public Patient Patient { get; set; }
        public virtual ICollection<AnalysationTest> AnalysationTests { get; set; }
        public virtual ICollection<GoodsExportation> GoodsExportations { get; set; }
    }
}

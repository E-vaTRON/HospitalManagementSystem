using HospitalDataBase.Core.Entities.UnitType;
using System;

namespace HospitalDataBase.Core.Entities
{
    public class AnalysationTest : BaseEntity
    {
        public string PatientID { get; set; }
        public string DeviceID { get; set; }
        public string ExamID { get; set; }
        public string DSymptom { get; set; }            //triệu chứng lâm sàng
        public string DoctorComment { get; set; }       // chỉ định
        public FormType ResultFromType { get; set; }    //form kết quả chuẩn đoán 

        public HistoryMedicalExam HistoryMedicalExam { get; set; }
        public DeviceService DeviceService { get; set; }
    }
}

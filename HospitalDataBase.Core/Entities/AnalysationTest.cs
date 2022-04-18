using HospitalDataBase.Core.Entities.UnitType;
using System;

namespace HospitalDataBase.Core.Entities
{
    public class AnalysationTest : BaseEntity
    {
        public int      DeviceID        { get; set; }
        public int      ExamID          { get; set; }
        public string   DSymptom        { get; set; } = string.Empty;           //triệu chứng lâm sàng
        public string   DoctorComment   { get; set; } = string.Empty;           // chỉ định 

        public HistoryMedicalExam?  HistoryMedicalExam  { get; set; }
        public DeviceService?       DeviceService       { get; set; }
    }
}

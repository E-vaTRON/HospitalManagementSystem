using HospitalDataBase.Core.Entities.UnitType;
using System;

namespace HospitalDataBase.Core.Entities
{
    public class AnalysationTest : BaseEntity
    {
        public string PatientID { get; set; }
        public string DeviceID { get; set; }
        public string DSymptom { get; set; }        //triệu chứng lâm sàng

        public Patient Patient { get; set; }
        public DeviceService DeviceService { get; set; }
    }
}

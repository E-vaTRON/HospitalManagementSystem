using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDataBase.DataObjects.CreateDTO
{
    public class CreateAnalysationTestDTO : BaseDTO
    {
        public string PatientID { get; set; }
        public string DeviceID { get; set; }
        public string DSymptom { get; set; }        //triệu chứng lâm sàng
        public string DoctorComment { get; set; }   //chỉ định

        public PatientDTO PatientDTO { get; set; }
    }
}

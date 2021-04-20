using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class HistoryMedicalExam
    {
        public Guid ID { get; set; }
        public string patientID { get; set; }           //mã số bệnh nhân
        public DateTime dateTakeExam { get; set; }      //ngày khám bệnh
        public DateTime dateReExam { get; set; }        //ngày tái khám
        public string patientRecipient { get; set; }    //người nhận bệnh
        public string doctorName { get; set; }          //tên bác sĩ
        public string diagnose { get; set; }            //chuẩn đoán
        public int examID { get; set; }                 //mã số khám bệnh (bốc số)
    }
}

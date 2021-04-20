using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class Analysation
    {
        public Guid ID { get; set; }    
        public string patientID { get; set; }       //mã số bệnh nhân
        public string firstName { get; set; }       //họ
        public string lastName { get; set; }        //tên
        public DateTime dateOfBirth { get; set; }   //năm sinh
        public bool sex { get; set; }               //giới tính
        public bool AnalysationType { get; set; }   //loại chuẩn đoán
        public string doctorGuide { get; set; }     //bác sĩ chỉ định
        public string symptom { get; set; }         //triệu chứng lâm sàng
    }
}

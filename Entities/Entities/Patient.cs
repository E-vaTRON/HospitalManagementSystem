using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class Patient
    {
        public Guid ID { get; set; }
        public string patientID { get; set; }      //mã số bệnh nhân
        public string firstName { get; set; }      //họ
        public string lastName { get; set; }       //tên
        public DateTime dayOfBirth { get; set; }   //ngày sinh
        public int age { get; set; }               //tuổi
        public bool sex { get; set; }              //giới tính
        public string address { get; set; }        //địa chỉ
        public string cardID { get; set; }         //mã thẻ
        public string pnoneNumber { get; set; }    //số điện thoại
    }
}

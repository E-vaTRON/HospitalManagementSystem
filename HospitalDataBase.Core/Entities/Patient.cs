using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalDataBase.Core.Entities
{
    public class Patient
    {
        [Key]
        public string PatientID { get; set; }
        public string FirstName { get; set; }      //họ
        public string LastName { get; set; }       //tên
        public DateTime DayOfBirth { get; set; }   //ngày sinh
        public int Age { get; set; }               //tuổi
        public bool Sex { get; set; }              //giới tính
        public string Address { get; set; }        //địa chỉ
        public string CardID { get; set; }         //mã thẻ
        public string PnoneNumber { get; set; }    //số điện thoại

        public virtual ICollection<HistoryMedicalExam> Exams { get; set; } = new HashSet<HistoryMedicalExam>();
        public virtual ICollection<Analysation> Analysations { get; set; } = new HashSet<Analysation>();
        public virtual ICollection<Test> Tests { get; set; } = new HashSet<Test>();
    }
}

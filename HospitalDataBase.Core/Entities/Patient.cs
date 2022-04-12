using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalDataBase.Core.Entities
{
    public class Patient : BaseEntity
    {
        public string       FirstName { get; set; } = string.Empty;     //họ
        public string       LastName { get; set; } = string.Empty;      //tên
        public DateTime     DayOfBirth { get; set; }                    //ngày sinh
        public int          Age { get; set; }                           //tuổi
        public bool         Gender { get; set; }                        //giới tính
        public string       Address { get; set; } = string.Empty;       //địa chỉ
        public string       CardID { get; set; } = string.Empty;        //mã thẻ
        public string       PnoneNumber { get; set; } = string.Empty;   //số điện thoại

        public virtual ICollection<HistoryMedicalExam>  Exams   { get; set; } = new HashSet<HistoryMedicalExam>();
    }
}

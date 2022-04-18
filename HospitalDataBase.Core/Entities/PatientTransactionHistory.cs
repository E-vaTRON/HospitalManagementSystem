using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class PatientTransactionHistory : BaseEntity
    {
        public int          ExamID          { get; set; }
        public DateTime     RecordDay       { get; set; }                       //ngày ghi sổ
        public int          TotalPrice      { get; set; }                       //thành tiền

        public HistoryMedicalExam? Exam { get; set; }

        public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();

    }
}

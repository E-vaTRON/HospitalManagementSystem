using Core.Entities.UserIdentifile;
using System.Collections.Generic;

namespace HospitalDataBase.Core.Entities
{
    public class EmployeeList : User
    {
        public bool Verified { get; set; }
        public string EmployeeID { get; set; } = null!;

        public virtual ICollection<HistoryMedicalExam> Exams { get; set; } = new HashSet<HistoryMedicalExam>();
    }
}

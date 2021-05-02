using Core.Entities.UserIdentifile;
using System.Collections.Generic;

namespace HospitalDataBase.Core.Entities
{
    public class DoctorList : User
    {
        public bool Verified { get; set; }
        public string DoctorID { get; set; }

        public virtual ICollection<HistoryMedicalExam> Exams { get; set; }
    }
}

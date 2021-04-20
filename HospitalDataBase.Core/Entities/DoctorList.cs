using Core.Entities.UserIdentifile;
using System;

namespace HospitalDataBase.Core.Entities
{
    public class DoctorList : User
    {
        public bool Verified { get; set; }
    }
}

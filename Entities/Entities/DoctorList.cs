using Entities.Models.UserIdentifile;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class DoctorList
    {
        public int? Id { get; set; }
        public bool Verified { get; set; }
        public User UserInfo { get; set; }
    }
}

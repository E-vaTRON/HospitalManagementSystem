using Entities.Models.UserIdentifile;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class EmployeeList
    {
        public int? Id { get; set; }
        public bool Verified { get; set; }
        public User UserInfo { get; set; }
    }
}

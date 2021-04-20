using Core.Entities.UserIdentifile;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Core.Entities
{
    public class EmployeeList : User
    {
        public bool Verified { get; set; }
    }
}

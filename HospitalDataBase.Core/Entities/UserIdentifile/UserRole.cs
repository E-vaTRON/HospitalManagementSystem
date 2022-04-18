using HospitalDataBase.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.UserIdentifile
{
    public class UserRole : BaseEntity
    {
        public virtual User?    User    { get; set; }
        public virtual Role?    Role    { get; set; }
    }
}

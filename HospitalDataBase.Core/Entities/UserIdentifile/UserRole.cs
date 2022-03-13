using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.UserIdentifile
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual User?    User    { get; set; }
        public virtual Role?    Role    { get; set; }
    }
}

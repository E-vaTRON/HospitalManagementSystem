using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace Core.Entities.UserIdentifile
{
    public class User : IdentityUser
    {
        public string Guid { get; protected set; } = null!;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Job { get; set; }                        //Công việc
        public string Function { get; set; }                   //chức năng
        public string Department { get; set; }                 //Bộ phận
        public string RoomID { get; set; }                     //Phòng
        public DateTime DateJoin { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsExpired { get; set; } = false;
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}

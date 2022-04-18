using HospitalDataBase.Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Entities.UserIdentifile
{
    public class User : BaseEntity
    {
        public string       Guid        { get; protected set; } = null!;
        public string       FirstName   { get; set; } = string.Empty;
        public string       LastName    { get; set; } = string.Empty;
        public int          Age         { get; set; }
        public string       Job         { get; set; } = string.Empty;           //Công việc
        public string       Function    { get; set; } = string.Empty;           //chức năng
        public string       Department  { get; set; } = string.Empty;           //Bộ phận
        public string       RoomID      { get; set; } = null!;                  //Phòng
        public DateTime     DateJoin    { get; set; }
        public bool         IsDeleted   { get; set; } = false;
        public bool         IsExpired   { get; set; } = false;

        public virtual ICollection<UserRole>    UserRoles   { get; set; } = new HashSet<UserRole>();
    }
}

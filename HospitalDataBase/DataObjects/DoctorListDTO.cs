using System;

namespace HospitalDataBase.DataObjects
{
    public class DoctorListDTO : BaseDTO
    {
        public string Guid { get; protected set; } = null!;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Job { get; set; }
        public string Function { get; set; }
        public string Department { get; set; }
        public string RoomID { get; set; }
        public DateTime DateJoin { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsExpired { get; set; } = false;
        public bool Verified { get; set; }
    }
}

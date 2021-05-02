using System;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<DoctorListDTO>))]
    public class DoctorListDTO
    {
        [FromRoute]
        public string DoctorID { get; set; }
        public string Guid { get; protected set; } = null!;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Job { get; set; }
        public string Function { get; set; }
        public string Department { get; set; }
        public string RoomID { get; set; }
        public string DateJoin { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsExpired { get; set; } = false;
        public bool Verified { get; set; }
    }
}

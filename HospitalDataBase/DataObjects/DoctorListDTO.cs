﻿
using System.ComponentModel.DataAnnotations;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<DoctorListDTO>))]
    public class DoctorListDTO
    {
        [FromRoute]
        public string DoctorID { get; set; } = string.Empty;
        public string Guid { get; protected set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Job { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string RoomID { get; set; } = string.Empty;
        public string DateJoin { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public bool IsExpired { get; set; } = false;
        public bool Verified { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.DataObjects
{
    public class UserDTO
    {
        [FromRoute]
        public string   Guid            { get; protected set; } = null!;

        [Required]
        public string   FirstName       { get; set; } = string.Empty;

        [Required]
        public string   LastName        { get; set; } = string.Empty;

        [Required]
        public int      Age             { get; set; }

        [Required]
        [EmailAddress]
        public string   Email           { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string   PhoneNumber     { get; set; } = string.Empty;

        public ICollection<string>  Roles   { get; set; } = Array.Empty<string>();
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.DataObjects.CreateDTO
{
    public class CreateEmloyeeDTO
    {
        [Required]
        public string   FirstName   { get; set; } = String.Empty;

        [Required]
        public string   LastName    { get; set; } = String.Empty;

        [Required]
        public int      Age         { get; set; }

        [Required]
        public string   Job         { get; set; } = string.Empty;

        public string   Function    { get; set; } = string.Empty;

        public string   Department  { get; set; } = string.Empty;

        public string   RoomID      { get; set; } = string.Empty;

        [Required]
        public string   DateJoin    { get; set; } = string.Empty;

        public bool     IsDeleted   { get; set; } = false;

        public bool     IsExpired   { get; set; } = false;

        [Required]
        public bool     Verified    { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;


namespace HospitalDataBase.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}

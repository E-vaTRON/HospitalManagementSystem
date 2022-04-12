using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.DataObjects.CreateDTO
{
    public class CreateAnalysationTestDTO
    {
        public string   DeviceService   { get; set; } = string.Empty;

        public string   ExamID          { get; set; } = string.Empty;

        [Required]
        public string   DSymptom        { get; set; } = string.Empty;       //triệu chứng lâm sàng

        public string   DoctorComment   { get; set; } = string.Empty;       //chỉ định
    }
}

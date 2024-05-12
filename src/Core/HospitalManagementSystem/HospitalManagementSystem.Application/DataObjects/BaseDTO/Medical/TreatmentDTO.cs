namespace HospitalManagementSystem.Application;

public class TreatmentDTO : DTOBase
{
    public string   Name        { get; set; } = string.Empty;
    public string   Details     { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<DiagnosisTreatmentDTO> DiagnosisTreatmentDTOs { get; set; } = new HashSet<DiagnosisTreatmentDTO>();
}

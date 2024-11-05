namespace HospitalManagementSystem.Domain;

public class ServiceEpisode : EntityBase
{
    //public string?          DeviceInventoryId   { get; set; }
    //public DeviceInventory  DeviceInventory     { get; set; } = default!;
    public string?              MedicalServiceId        { get; set; }
    public MedicalService       MedicalService          { get; set; } = default!;
    public string?              MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;

    //public virtual ICollection<AnalysisTest> AnalysisTests { get; set; } = new HashSet<AnalysisTest>();
}
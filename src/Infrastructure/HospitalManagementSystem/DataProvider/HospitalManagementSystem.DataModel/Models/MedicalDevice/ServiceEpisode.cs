namespace HospitalManagementSystem.DataProvider;

public class ServiceEpisode : ModelBase
{
    //public Guid?            DeviceInventoryId   { get; set; }
    //public DeviceInventory  DeviceInventory     { get; set; } = default!;
    public Guid?                MedicalServiceId        { get; set; }
    public MedicalService       MedicalService          { get; set; } = default!;
    public Guid?                MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;

    //public virtual ICollection<AnalysisTest> AnalysisTests { get; set; } = new HashSet<AnalysisTest>();
}
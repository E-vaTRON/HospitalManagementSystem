namespace HospitalManagementSystem.DataProvider;

public class Treatment : ModelBase
{
    public string   Name        { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<TreatmentExamEpisode>    TreatmentExamEpisodes   { get; set; } = new HashSet<TreatmentExamEpisode>();
}

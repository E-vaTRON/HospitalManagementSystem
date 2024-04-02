namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEposode : ModelBase
{
    public DateTime     DateTakeExam    { get; set; }       //ngày khám bệnh ?????
    public DateTime     DateReExam      { get; set; }       //ngày tái khám
    public int          LineNumber      { get; set; }       //bốc số ?????
    public DateTime     RecordDay       { get; set; }       //ngày ghi sổ ?????
    public long         TotalPrice      { get; set; }       //thành tiền

    public string?              MedicalExamId       { get; set; }
    public MedicalExam          MedicalExam         { get; set; } = default!;
    public string?              ReExamAppointmentId { get; set; }
    public ReExamAppointment    ReExamAppointment   { get; set; } = default!;

    public virtual ICollection<AssignmentHistory>       AssignmentHistories     { get; set; } = new HashSet<AssignmentHistory>();
    public virtual ICollection<TreatmentExamEpisode>    TreatmentExamEpisodes   { get; set; } = new HashSet<TreatmentExamEpisode>();
    public virtual ICollection<RoomAllocation>          RoomAllocations         { get; set; } = new HashSet<RoomAllocation>();
    public virtual ICollection<DrugDetail>              DrugDetails             { get; set; } = new HashSet<DrugDetail>();
    public virtual ICollection<AnalysisTest>            AnalysisTests           { get; set; } = new HashSet<AnalysisTest>();
}
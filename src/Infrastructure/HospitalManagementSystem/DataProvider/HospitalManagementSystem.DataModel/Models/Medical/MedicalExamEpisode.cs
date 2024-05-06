namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEpisode : ModelBase
{
    public DateTime     DateTakeExam    { get; set; }       //ngày khám bệnh ?????
    public DateTime     DateReExam      { get; set; }       //ngày tái khám
    public int          LineNumber      { get; set; }       //bốc số ?????
    public DateTime     RecordDay       { get; set; }       //ngày ghi sổ ?????
    public int          TotalPrice      { get; set; }       //thành tiền

    public Guid?                MedicalExamId       { get; set; }
    public MedicalExam          MedicalExam         { get; set; } = default!;

    public ReExamAppointment?   ReExamAppointment   { get; set; } // This is Principal Table

    public virtual ICollection<AssignmentHistory>       AssignmentHistories     { get; set; } = new HashSet<AssignmentHistory>();
    public virtual ICollection<Diagnosis>               Diagnoses               { get; set; } = new HashSet<Diagnosis>();
    public virtual ICollection<RoomAllocation>          RoomAllocations         { get; set; } = new HashSet<RoomAllocation>();
    public virtual ICollection<DrugPrescription>        DrugPrescriptions       { get; set; } = new HashSet<DrugPrescription>();
    public virtual ICollection<AnalysisTest>            AnalysisTests           { get; set; } = new HashSet<AnalysisTest>();
}
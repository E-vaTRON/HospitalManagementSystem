namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEposode : ModelBase
{
    public DateTime     DateTakeExam    { get; set; }       //ngày khám bệnh
    public DateTime     DateReExam      { get; set; }       //ngày tái khám
    public int          LineNumber      { get; set; }       //bốc số ?????

    public string?              MedicalExamId       { get; set; }
    public MedicalExam          MedicalExam         { get; set; } = default!;
    public string?              ReExamAppointmentId { get; set; }
    public ReExamAppointment?   ReExamAppointment   { get; set; }

    public virtual ICollection<AssignmentHistory>   AssignmentHistories { get; set; } = new HashSet<AssignmentHistory>();
    public virtual ICollection<Transaction>         Transactions        { get; set; } = new HashSet<Transaction>();
    public virtual ICollection<Treatment>           Treatments          { get; set; } = new HashSet<Treatment>();
    public virtual ICollection<Diagnosis>           Diagnosis           { get; set; } = new HashSet<Diagnosis>();
    public virtual ICollection<RoomAllocation>      RoomAllocations     { get; set; } = new HashSet<RoomAllocation>();
}
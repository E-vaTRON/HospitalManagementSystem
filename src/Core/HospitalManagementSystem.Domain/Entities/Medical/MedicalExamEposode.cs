namespace HospitalManagementSystem.Domain;

public class MedicalExamEposode : EntityBase
{
    public DateTime     DateTakeExam    { get; set; }       //ngày khám bệnh
    public DateTime     DateReExam      { get; set; }       //ngày tái khám
    public string?      Diagnose        { get; set; }       //chuẩn đoán ( làm bản riêng ) 
    public int          LineNumber      { get; set; }       //bốc số ?????

    public string?      MedicalExamId   { get; set; }
    public MedicalExam  MedicalExam     { get; set; } = default!;

    public virtual ICollection<Doctor>          Doctors         { get; set; } = new HashSet<Doctor>();
    public virtual ICollection<Transaction>     Transactions    { get; set; } = new HashSet<Transaction>();
    public virtual ICollection<Treatment>       Treatments      { get; set; } = new HashSet<Treatment>();
    public virtual ICollection<Diagnosis>       Diagnosis       { get; set; } = new HashSet<Diagnosis>();
}

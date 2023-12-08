namespace HospitalManagementSystem.Domain;

public class Transaction : EntityBase
{
    public DateTime     RecordDay       { get; set; }   //ngày ghi sổ
    public long         TotalPrice      { get; set; }   //thành tiền

    public string?              ExamID      { get; set; }
    public MedicalExamEposode   MedicalExam { get; set; } = default!;

    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();

}

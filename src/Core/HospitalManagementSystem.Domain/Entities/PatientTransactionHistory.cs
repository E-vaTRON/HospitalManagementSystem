namespace HospitalManagementSystem.Domain;

public class PatientTransactionHistory : EntityBase
{
    public int          ExamID          { get; set; }
    public DateTime     RecordDay       { get; set; }   //ngày ghi sổ
    public long         TotalPrice      { get; set; }   //thành tiền

    public HistoryMedicalExam? Exam { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();

}

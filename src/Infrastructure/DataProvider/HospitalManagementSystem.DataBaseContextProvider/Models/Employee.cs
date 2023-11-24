namespace HospitalManagementSystem.DataBaseContextProvider;

public class Employee 
    //: User
{
    public bool     Verified    { get; set; }
    public bool     IsEmployee  { get; set; }

    public virtual ICollection<HistoryMedicalExam>  Exams   { get; set; } = new HashSet<HistoryMedicalExam>();
}

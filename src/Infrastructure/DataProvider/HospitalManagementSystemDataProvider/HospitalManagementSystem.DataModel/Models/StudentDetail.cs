namespace HospitalManagementSystem.DataModel;

public class StudentDetail
{
    public int StudentDetailsId { get; set; }
    public string Address { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}

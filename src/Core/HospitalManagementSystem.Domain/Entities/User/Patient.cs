namespace HospitalManagementSystem.Domain;

public class Patient : User
{
    public virtual ICollection<MedicalExam>         Exams               { get; set; } = new HashSet<MedicalExam>();
    public virtual ICollection<ReExamAppointment>   ReExamAppointments  { get; set; } = new HashSet<ReExamAppointment>();
    public virtual ICollection<BookingAppointment>  BookingAppointments { get; set; } = new HashSet<BookingAppointment>();
    public virtual ICollection<RoomAllocation>      RoomAllocations     { get; set; } = new HashSet<RoomAllocation>();
}
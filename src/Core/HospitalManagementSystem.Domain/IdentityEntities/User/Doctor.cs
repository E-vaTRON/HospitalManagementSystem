namespace HospitalManagementSystem.Domain;

public class Doctor
{
    public int? SpecialistLevel { get; set; }

    public virtual ICollection<AssignmentHistory> AssignmentHistories { get; set; } = new HashSet<AssignmentHistory>();
    public virtual ICollection<ReferralDoctor> ReferralDoctors { get; set; } = new HashSet<ReferralDoctor>();
}
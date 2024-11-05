namespace HospitalManagementSystem.Domain;

public static class AssignmentHistoryFactory
{
    public static AssignmentHistory Create()
    {
        return new AssignmentHistory();
    }

    public static AssignmentHistory Create(string assignmentStatus, string doctorId, string referralDoctorId)
    {
        return new AssignmentHistory()
        {
            AssignmentStatus = assignmentStatus,
            DoctorId = doctorId,
            ReferralDoctorId = referralDoctorId
        };
    }

    public static AssignmentHistory Create(string assignmentStatus, string doctorId)
    {
        return new AssignmentHistory()
        {
            AssignmentStatus = assignmentStatus,
            DoctorId = doctorId,
            ReferralDoctorId = string.Empty
        };
    }
}

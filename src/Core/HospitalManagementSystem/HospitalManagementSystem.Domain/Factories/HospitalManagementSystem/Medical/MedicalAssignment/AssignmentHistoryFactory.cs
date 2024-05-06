namespace HospitalManagementSystem.Domain;

public static class AssignmentHistoryFactory
{
    public static AssignmentHistory Create()
    {
        return new AssignmentHistory();
    }

    public static AssignmentHistory Create(string assignmentStatus, string doctorId, string medicalExamEpisodeId, string referralDoctorId)
    {
        return new AssignmentHistory()
        {
            AssignmentStatus = assignmentStatus,
            DoctorId = doctorId,
            MedicalExamEpisodeId = medicalExamEpisodeId,
            ReferralDoctorId = referralDoctorId
        };
    }

    public static AssignmentHistory Create(string assignmentStatus, string doctorId, string medicalExamEpisodeId)
    {
        return new AssignmentHistory()
        {
            AssignmentStatus = assignmentStatus,
            DoctorId = doctorId,
            MedicalExamEpisodeId = medicalExamEpisodeId,
            ReferralDoctorId = string.Empty
        };
    }
}

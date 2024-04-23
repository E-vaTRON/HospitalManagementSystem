namespace HospitalManagementSystem.Domain;

public static class AssignmentHistoryFactory
{
    public static AssignmentHistory Create()
    {
        return new AssignmentHistory();
    }

    public static AssignmentHistory Create(string assignmentStatus, string doctorId, string medicalExamEposodeId, string referralDoctorId)
    {
        return new AssignmentHistory()
        {
            AssignmentStatus = assignmentStatus,
            DoctorId = doctorId,
            MedicalExamEposodeId = medicalExamEposodeId,
            ReferralDoctorId = referralDoctorId
        };
    }

    public static AssignmentHistory Create(string assignmentStatus, string doctorId, string medicalExamEposodeId)
    {
        return new AssignmentHistory()
        {
            AssignmentStatus = assignmentStatus,
            DoctorId = doctorId,
            MedicalExamEposodeId = medicalExamEposodeId,
            ReferralDoctorId = string.Empty
        };
    }
}

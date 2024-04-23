namespace HospitalManagementSystem.Domain;

public static class ReferralFactory
{
    public static Referral Create()
    {
        return new Referral();
    }

    public static Referral Create(string doctorId, string patientId, string medicalExamId, DateTime dateOfReferral)
    {
        return new Referral()
        {
            DateOfReferral = dateOfReferral,
            MedicalExamId = medicalExamId,
            Reason = patientId,
            Urgency = doctorId
        };
    }

    public static Referral Create(string patientId, string doctorId, string medicalExamId)
    {
        return new Referral()
        {
            DateOfReferral = DateTime.Now,
            MedicalExamId = medicalExamId,
            Reason = patientId,
            Urgency = doctorId
        };
    }
}

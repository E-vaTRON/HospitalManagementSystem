namespace HospitalManagementSystem.Domain;

public static class ReferralDoctorFactory
{
    public static ReferralDoctor Create()
    {
        return new ReferralDoctor();
    }

    public static ReferralDoctor Create(string referralStatus, string referredDoctorId, string referralId, string assignmentHistoryId)
    {
        return new ReferralDoctor()
        {
            ReferralStatus = referralStatus,
            ReferredDoctorId = referredDoctorId,
            ReferralId = referralId,
            AssignmentHistoryId = assignmentHistoryId
        };
    }

    public static ReferralDoctor Create(string referralStatus, string referredDoctorId, string referralId)
    {
        return new ReferralDoctor()
        {
            ReferralStatus = referralStatus,
            ReferredDoctorId = referredDoctorId,
            ReferralId = referralId
        };
    }
}

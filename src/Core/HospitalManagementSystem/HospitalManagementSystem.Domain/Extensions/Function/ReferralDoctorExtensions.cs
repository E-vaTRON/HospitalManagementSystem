namespace HospitalManagementSystem.Domain;

public static class ReferralDoctorExtensions
{
    #region [ Private Methods ]
    private static ReferralDoctor AddAssignmentHistory(this ReferralDoctor referralDoctor, AssignmentHistory assignmentHistory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(assignmentHistory));

        if (referralDoctor.AssignmentHistory == assignmentHistory)
        {
            return referralDoctor;
        }

        assignmentHistory.ReferralDoctorId = referralDoctor.Id;
        assignmentHistory.ReferralDoctor = referralDoctor;
        referralDoctor.AssignmentHistory = assignmentHistory;
        return referralDoctor;
    }
    #endregion

    #region [ Public Methods ]
    public static ReferralDoctor AddAssignmentHistory(this ReferralDoctor referralDoctor)
    {
        return referralDoctor.AddAssignmentHistory(AssignmentHistoryFactory.Create());
    }

    public static ReferralDoctor AddAssignmentHistory(this ReferralDoctor referralDoctor, string assignmentStatus, string doctorId, string referralDoctorId)
    {
        return referralDoctor.AddAssignmentHistory(AssignmentHistoryFactory.Create(assignmentStatus, doctorId, referralDoctorId));
    }

    public static ReferralDoctor AddAssignmentHistory(this ReferralDoctor referralDoctor, string assignmentStatus, string doctorId)
    {
        return referralDoctor.AddAssignmentHistory(AssignmentHistoryFactory.Create(assignmentStatus, doctorId));
    }

    public static ReferralDoctor RemoveRelated(this ReferralDoctor referralDoctor)
    {
        referralDoctor.Referral = null!;
        referralDoctor.AssignmentHistory = null!;
        return referralDoctor;
    }
    #endregion
}

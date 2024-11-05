namespace HospitalManagementSystem.Domain;

public static class ReferralExtensions
{
    #region [ Private Methods ]
    private static Referral AddReferralDoctor(this Referral referral, ReferralDoctor referralDoctor)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(referralDoctor));

        if (referral.ReferralDoctors.Any(x => x.Id == referralDoctor.Id))
        {
            return referral;
        }

        referralDoctor.ReferralId = referral.Id;
        referralDoctor.Referral = referral;
        referral.ReferralDoctors.Add(referralDoctor);
        return referral;
    }
    #endregion

    #region [ Public Methods ]
    public static Referral AddReferralDoctor(this Referral referral)
    {
        return referral.AddReferralDoctor(ReferralDoctorFactory.Create());
    }

    public static Referral AddReferralDoctor(this Referral referral, string assignmentStatus, string doctorId, string medicalExamEpisodeId)
    {
        return referral.AddReferralDoctor(ReferralDoctorFactory.Create(assignmentStatus, doctorId, medicalExamEpisodeId));
    }

    public static Referral RemoveRelated(this Referral referral)
    {
        referral.MedicalExam = null!;
        referral.ReferralDoctors.Clear();
        return referral;
    }
    #endregion
}

namespace HospitalManagementSystem.Domain;

public static class MedicalExamExtensions
{
    #region [ Private Methods ]
    private static MedicalExam AddMedicalExamEpisode(this MedicalExam medicalExam, MedicalExamEpisode medicalExamEpisode)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(medicalExamEpisode));

        if (medicalExam.MedicalExamEpisodes.Any(x => x.Id == medicalExamEpisode.Id))
        {
            return medicalExam;
        }

        medicalExamEpisode.MedicalExamId = medicalExam.Id;
        medicalExamEpisode.MedicalExam = medicalExam;
        medicalExam.MedicalExamEpisodes.Add(medicalExamEpisode);
        return medicalExam;
    }

    private static MedicalExam AddReferral(this MedicalExam medicalExam, Referral referral)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(referral));

        if (medicalExam.Referrals.Any(x => x.Id == referral.Id))
        {
            return medicalExam;
        }

        referral.MedicalExamId = medicalExam.Id;
        referral.MedicalExam = medicalExam;
        medicalExam.Referrals.Add(referral);
        return medicalExam;
    }
    #endregion

    #region [ Public Methods ]
    public static MedicalExam AddMedicalExamEpisode(this MedicalExam medicalExam)
    {
        return medicalExam.AddMedicalExamEpisode(MedicalExamEpisodeFactory.Create());
    }

    public static MedicalExam AddMedicalExamEpisode(this MedicalExam medicalExam, DateTime dateTakeExam, DateTime dateReExam, int lineNumber, DateTime recordDay, int totalPrice, string medicalExamId)
    {
        return medicalExam.AddMedicalExamEpisode(MedicalExamEpisodeFactory.Create(dateTakeExam, dateReExam, lineNumber, recordDay, totalPrice, medicalExamId));
    }

    public static MedicalExam AddMedicalExamEpisode(this MedicalExam medicalExam, DateTime dateReExam, int lineNumber, DateTime recordDay, int totalPrice, string medicalExamId)
    {
        return medicalExam.AddMedicalExamEpisode(MedicalExamEpisodeFactory.Create(dateReExam, lineNumber, recordDay, totalPrice, medicalExamId));
    }

    // Overloads for AddReferral
    public static MedicalExam AddReferral(this MedicalExam medicalExam)
    {
        return medicalExam.AddReferral(ReferralFactory.Create());
    }

    public static MedicalExam AddReferral(this MedicalExam medicalExam, string doctorId, string patientId, string medicalExamId, DateTime dateOfReferral)
    {
        return medicalExam.AddReferral(ReferralFactory.Create(doctorId, patientId, medicalExamId, dateOfReferral));
    }

    public static MedicalExam AddReferral(this MedicalExam medicalExam, string patientId, string doctorId, string medicalExamId)
    {
        return medicalExam.AddReferral(ReferralFactory.Create(patientId, doctorId, medicalExamId));
    }
    #endregion
}

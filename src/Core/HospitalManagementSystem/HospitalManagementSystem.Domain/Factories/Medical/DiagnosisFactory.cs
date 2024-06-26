﻿namespace HospitalManagementSystem.Domain;

public static class DiagnosisFactory
{
    public static Diagnosis Create()
    {
        return new Diagnosis();
    }

    public static Diagnosis Create(string diagnosisCode, string description, string icdId, string medicalExamEpisodeId)
    {
        return new Diagnosis()
        {
            DiagnosisCode = diagnosisCode,
            Description = description,
            DiseasesId = icdId,
            MedicalExamEpisodeId = medicalExamEpisodeId
        };
    }

    public static Diagnosis Create(string diagnosisCode, string icdId, string medicalExamEpisodeId)
    {
        return new Diagnosis()
        {
            DiagnosisCode = diagnosisCode,
            Description = string.Empty,
            DiseasesId = icdId,
            MedicalExamEpisodeId = medicalExamEpisodeId
        };
    }
}
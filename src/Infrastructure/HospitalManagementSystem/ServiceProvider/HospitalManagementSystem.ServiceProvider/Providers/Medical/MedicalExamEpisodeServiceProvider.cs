﻿using CoreMedicalExamEpisode = HospitalManagementSystem.Domain.MedicalExamEpisode;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamEpisodeServiceProvider : ServiceProviderBase<CoreMedicalExamEpisode>, IMedicalExamEpisodeServiceProvider
{
    public MedicalExamEpisodeServiceProvider(MedicalExamEpisodeDataProvider dataProvider) : base(dataProvider)
    {
    }
}
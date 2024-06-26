﻿namespace HospitalManagementSystem.Domain;

public class Referral : EntityBase
{
    public DateTime DateOfReferral  { get; set; }
    public string?  Reason          { get; set; }
    public string?  Urgency         { get; set; } // ???

    public string?      MedicalExamId   { get; set; }
    public MedicalExam  MedicalExam     { get; set; } = default!;

    public virtual ICollection<ReferralDoctor> ReferralDoctors { get; set; } = new HashSet<ReferralDoctor>();
}

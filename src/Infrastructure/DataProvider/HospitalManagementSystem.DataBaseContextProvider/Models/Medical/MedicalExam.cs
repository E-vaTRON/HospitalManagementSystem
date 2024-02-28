﻿namespace HospitalManagementSystem.DataProvider;

public class MedicalExam : ModelBase
{
    public string?      AppointmentId { get; set; }
    public AppointmentBase?  Appointment { get; set; } = default!;

    public virtual ICollection<MedicalExamEposode> MedicalExamEposodes { get; set; } = new HashSet<MedicalExamEposode>();
}
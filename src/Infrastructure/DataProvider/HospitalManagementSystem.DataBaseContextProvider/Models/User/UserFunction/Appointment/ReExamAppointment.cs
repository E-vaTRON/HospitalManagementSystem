﻿namespace HospitalManagementSystem.DataProvider;

public class ReExamAppointment : AppointmentBase
{
    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode?  MedicalExamEposode      { get; set; }
}

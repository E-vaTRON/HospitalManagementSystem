namespace HospitalManagementSystem.DataProvider;

public class Referral : ModelBase
{
    public DateTime DateOfReferral      { get; set; }
    public string?  Reason              { get; set; }

    public string?  ReferringDoctorId   { get; set; }
    public Doctor   ReferringDoctor     { get; set; } = default!;
    public string?  ReferredDoctorId    { get; set; }
    public Doctor   ReferredDoctor      { get; set; } = default!;
    public string?  PatientId           { get; set; }
    public Patient  Patient             { get; set; } = default!;
}

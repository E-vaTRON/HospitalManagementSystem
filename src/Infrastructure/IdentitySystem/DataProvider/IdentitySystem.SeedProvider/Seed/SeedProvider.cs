namespace IdentitySystem.DataProvider;

public class SeedProvider
{
    #region [ Singleton ]
    private static readonly Lazy<SeedProvider> seed = new Lazy<SeedProvider>(() => new SeedProvider(), LazyThreadSafetyMode.PublicationOnly);
    public static SeedProvider Seed
    {
        get { return seed.Value; }
    }
    #endregion

    #region [ CTor ]
    public SeedProvider()
    {
        // init
        Notifications = new();

        ScheduleDays = new();
        ScheduleSlots = new();

        Users = new();        //
        Roles = new();        //
        UserRoles = new();    //
        UserClaims = new();   //
        UserLogins = new();   //
        UserTokens = new();
        RoleClaims = new();   //

        Specializations = new();
        UserSpecializations = new();

        Clear();
        Load();
        Clean();
    }
    #endregion

    #region [ Properties ]
    public List<Domain.Notification> Notifications { get; private set; }

    public List<Domain.ScheduleDay>     ScheduleDays    { get; private set; }
    public List<Domain.ScheduleSlot>    ScheduleSlots   { get; private set; }

    public List<Domain.User>        Users       { get; private set; }
    public List<Domain.Role>        Roles       { get; private set; }
    public List<Domain.UserRole>    UserRoles   { get; private set; }
    public List<Domain.UserClaim>   UserClaims  { get; private set; }
    public List<Domain.UserLogin>   UserLogins  { get; private set; }
    public List<Domain.UserToken>   UserTokens  { get; private set; }
    public List<Domain.RoleClaim>   RoleClaims  { get; private set; }

    public List<Domain.Specialization>      Specializations     { get; private set; }
    public List<Domain.UserSpecialization>  UserSpecializations { get; private set; }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
        LoadUsers();
        LoadRoles();
        LoadUserRoles();
        LoadUserClaims();
        LoadRoleClaims();
        LoadUserLogins();
        LoadSpecializations();
        LoadUserSpecializations();
    }

    private void Clear()
    {
        Notifications.Clear();

        ScheduleDays.Clear();
        ScheduleSlots.Clear();

        Users.Clear();
        Roles.Clear();
        UserRoles.Clear();
        RoleClaims.Clear();
        UserClaims.Clear();
        UserTokens.Clear();
        UserLogins.Clear();

        Specializations.Clear();
        UserSpecializations.Clear();
    }

    private void Clean()
    {
        Notifications.ForEach(x => x.RemoveRelated());

        ScheduleDays.ForEach(x => x.RemoveRelated());
        ScheduleSlots.ForEach(x => x.RemoveRelated());

        Users.ForEach(x => x.RemoveRelated());
        Roles.ForEach(x => x.RemoveRelated());
        UserRoles.ForEach(x => x.RemoveRelated());
        RoleClaims.ForEach(x => x.RemoveRelated());
        UserClaims.ForEach(x => x.RemoveRelated());
        UserTokens.ForEach(x => x.RemoveRelated());
        UserLogins.ForEach(x => x.RemoveRelated());

        Specializations.ForEach(x => x.RemoveRelated());
        UserSpecializations.ForEach(x => x.RemoveRelated());
    }
    #endregion

    #region [ Seed Create ]
    private void LoadUsers()
    {
        // Patients
        this.Users.Add(UserFactory.Create("f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "patient1", "PATIENT1", 
                                          "patient1@hospital.com", "PATIENT1@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567891", true, false, true, 0, 
                                          "Patient", "1", 30, true, "123 Street", 
                                          "ID1", null, true));

        this.Users.Add(UserFactory.Create("60b1647e-1474-4fae-95cf-43213dd070ae", "patient2", "PATIENT2", 
                                          "patient2@hospital.com", "PATIENT2@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567892", true, false, true, 0, 
                                          "Patient", "2", 30, true, "123 Street", 
                                          "ID2", null, true));

        this.Users.Add(UserFactory.Create("1c1217f4-4375-4a8d-a67e-8dd89bf99f41", "patient3", "PATIENT3", 
                                          "patient3@hospital.com", "PATIENT3@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567893", true, false, true, 0, 
                                          "Patient", "3", 30, true, "123 Street", 
                                          "ID3", null, true));

        this.Users.Add(UserFactory.Create("c2ecb78c-4bd2-40f6-a966-8eb1472382ce", "patient4", "PATIENT4", 
                                          "patient4@hospital.com", "PATIENT4@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567894", true, false, true, 0, 
                                          "Patient", "4", 30, true, "123 Street", 
                                          "ID4", null, true));

        this.Users.Add(UserFactory.Create("7baac533-bca9-40a8-9e69-c7df24170efa", "patient5", "PATIENT5", 
                                          "patient5@hospital.com", "PATIENT5@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567895", true, false, true, 0, 
                                          "Patient", "5", 30, true, "123 Street", 
                                          "ID5", null, true));

        this.Users.Add(UserFactory.Create("77204cd1-fba2-4faf-9fb6-ee258fddaa8d", "patient6", "PATIENT6", 
                                          "patient6@hospital.com", "PATIENT6@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567896", true, false, true, 0, 
                                          "Patient", "6", 30, true, "123 Street", 
                                          "ID6", null, true));

        this.Users.Add(UserFactory.Create("17e9c247-4bc1-492a-9f33-219e288ae5a9", "patient7", "PATIENT7", 
                                          "patient7@hospital.com", "PATIENT7@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567897", true, false, true, 0, 
                                          "Patient", "7", 30, true, "123 Street", 
                                          "ID7", null, true));

        this.Users.Add(UserFactory.Create("7f2287a6-011c-4f51-8ea0-9bb1857c05f9", "patient8", "PATIENT8", 
                                          "patient8@hospital.com", "PATIENT8@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567898", true, false, true, 0, 
                                          "Patient", "8", 30, true, "123 Street", 
                                          "ID8", null, true));

        this.Users.Add(UserFactory.Create("b28a4b05-8609-4f90-a484-73f69b1bc1c9", "patient9", "PATIENT9", 
                                          "patient9@hospital.com", "PATIENT9@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567899", true, false, true, 0, 
                                          "Patient", "9", 30, true, "123 Street", 
                                          "ID9", null, true));

        this.Users.Add(UserFactory.Create("c364faa0-652d-4aad-a5d4-9978989629dd", "patient0", "PATIENT0", 
                                          "patient0@hospital.com", "PATIENT0@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567890", true, false, true, 0, 
                                          "Patient", "0", 30, true, "123 Street", 
                                          "ID0", null, true));

        // Doctors
        this.Users.Add(UserFactory.Create("b1af80b4-cb25-4b15-858b-27c992d647a9", "doctor1", "DOCTOR1", 
                                          "doctor1@hospital.com", "DOCTOR1@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "2234567891", true, false, true, 0, 
                                          "Doctor", "1", 40, true, "456 Street", 
                                          "ID11", 5, true));

        this.Users.Add(UserFactory.Create("65410c16-c252-4c9d-accd-c4917fa87bd0", "doctor2", "DOCTOR2", 
                                          "doctor2@hospital.com", "DOCTOR2@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "2234567892", true, false, true, 0, 
                                          "Doctor", "2", 40, true, "456 Street", 
                                          "ID12", 5, true));

        // Nurses
        this.Users.Add(UserFactory.Create("f80ed8ad-e328-4800-bcf9-14a0c6a6ae67", "nurse1", "NURSE1", 
                                          "nurse1@hospital.com", "NURSE1@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567891", true, false, true, 0, 
                                          "Nurse", "1", 35, false, "789 Street", 
                                          "ID13", 3, true));

        this.Users.Add(UserFactory.Create("54535da4-6466-483f-97b9-faa703dca8ed", "nurse2", "NURSE2",
                                          "nurse2@hospital.com", "NURSE2@HOSPITAL.COM", true,
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP",
                                          "3234567892", true, false, true, 0,
                                          "Nurse", "2", 35, false, "789 Street",
                                          "ID14", 3, true));

        this.Users.Add(UserFactory.Create("d0138810-469d-4a63-90f4-78ed9106415d", "nurse3", "NURSE3", 
                                          "nurse3@hospital.com", "NURSE3@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567893", true, false, true, 0, 
                                          "Nurse", "3", 35, false, "789 Street", 
                                          "ID15", 3, true));

        this.Users.Add(UserFactory.Create("5ef4024e-f5b0-4b5b-bb1b-a6c4d5db744c", "nurse4", "NURSE4", 
                                          "nurse4@hospital.com", "NURSE4@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567894", true, false, true, 0, 
                                          "Nurse", "4", 35, false, "789 Street", 
                                          "ID16", 3, true));

        this.Users.Add(UserFactory.Create("69e5f376-3a13-495a-bb35-bf5d715e21e1", "nurse5", "NURSE5", 
                                          "nurse5@hospital.com", "NURSE5@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567895", true, false, true, 0, 
                                          "Nurse", "5", 35, false, "789 Street", 
                                          "ID17", 3, true));

        this.Users.Add(UserFactory.Create("af7781d2-c68a-4bc2-beb1-e78e5f4764a8", "nurse6", "NURSE6", 
                                          "nurse6@hospital.com", "NURSE6@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567896", true, false, true, 0, 
                                          "Nurse", "6", 35, false, "789 Street", 
                                          "ID18", 3, true));

        // Admin
        this.Users.Add(UserFactory.Create("2fc9533e-ea4b-4090-9eda-14ce6bbb0d0e", "admin", "ADMIN", 
                                          "admin@hospital.com", "ADMIN@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "4234567890", true, false, true, 0, 
                                          "Admin", "User", 30, true, "Admin Street", 
                                          "ID19", null, true));
    }

    private void LoadRoles()
    {
        // Admin
        this.Roles.Add(RoleFactory.Create("Admin", "ADMIN", "CONCURRENCY_STAMP"));

        // Patient
        this.Roles.Add(RoleFactory.Create("Patient", "PATIENT", "CONCURRENCY_STAMP"));

        // Medical roles
        this.Roles.Add(RoleFactory.Create("Doctor", "DOCTOR", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("Pharmacist", "PHARMACIST", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("Nurse", "NURSE", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("Radiologist", "RADIOLOGIST", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("Pathologist", "PATHOLOGIST", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("Anesthesiologist", "ANESTHESIOLOGIST", "CONCURRENCY_STAMP"));

        // Specialized nursing roles
        //this.Roles.Add(RoleFactory.Create("Pediatric Nurse"));
        //this.Roles.Add(RoleFactory.Create("Neonatal Nurse"));
        //this.Roles.Add(RoleFactory.Create("ICU Nurse"));
        //this.Roles.Add(RoleFactory.Create("Emergency Nurse"));
        //this.Roles.Add(RoleFactory.Create("Oncology Nurse"));
        //this.Roles.Add(RoleFactory.Create("Orthopedic Nurse"));
        //this.Roles.Add(RoleFactory.Create("Cardiac Nurse"));
        //this.Roles.Add(RoleFactory.Create("Surgical Nurse"));

        // Non-medical roles
        this.Roles.Add(RoleFactory.Create("Receptionist", "RECEPTIONIST", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("Accountant", "ACCOUNTANT", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("HR", "HR", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("Biomedical Engineer", "BIOMEDICAL ENGINEER", "CONCURRENCY_STAMP")); 
        this.Roles.Add(RoleFactory.Create("IT", "IT", "CONCURRENCY_STAMP"));
    }

    private void LoadUserRoles()
    {
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient1"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient2"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient3"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient4"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient5"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient6"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient7"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient8"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient9"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient0"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Patient"))!);

        // Assign roles to doctors
        this.Users.FirstOrDefault(x => x.UserName!.Equals("doctor1"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Doctor"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("doctor2"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Doctor"))!);

        // Assign roles to nurses
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse1"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse2"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse3"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse4"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse5"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse6"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Nurse"))!);


        // Assign role to admin
        this.Users.FirstOrDefault(x => x.UserName!.Equals("admin"))!.AddUserRole(this.Roles.FirstOrDefault(x => x.Name!.Equals("Admin"))!);

        foreach (var item in this.Users)
        {
            this.UserRoles.AddRange(item.UserRoles);
        }
    }

    private void LoadUserClaims()
    {
        this.Users.FirstOrDefault(x => x.UserName!.Equals("admin"))!.AddUserClaim(1, "Permission", "ManageUsers");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("doctor1"))!.AddUserClaim(2, "Permission", "ViewPatients");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse1"))!.AddUserClaim(3, "Permission", "ViewPatients");

        foreach (var item in this.Users)
        {
            this.UserClaims.AddRange(item.UserClaims);
        }
    }

    private void LoadRoleClaims()
    {
        this.Roles.FirstOrDefault(x => x.Name!.Equals("Admin"))!.AddRoleClaim(1, "Permission", "ManageUsers");
        this.Roles.FirstOrDefault(x => x.Name!.Equals("Doctor"))!.AddRoleClaim(2, "Permission", "ViewPatients");
        this.Roles.FirstOrDefault(x => x.Name!.Equals("Nurse"))!.AddRoleClaim(3, "Permission", "ViewPatients");

        foreach (var item in this.Roles)
        {
            this.RoleClaims.AddRange(item.RoleClaims);
        }
    }

    private void LoadUserLogins()
    {
        // Admin
        this.Users.FirstOrDefault(x => x.UserName!.Equals("admin"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");

        // Doctors
        this.Users.FirstOrDefault(x => x.UserName!.Equals("doctor1"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("doctor2"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");

        // Nurses
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse1"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse2"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse3"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse4"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login"); 
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse5"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse6"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");

        // Patients
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient1"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient2"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient3"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient4"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient5"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient6"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient7"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient8"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient9"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");
        this.Users.FirstOrDefault(x => x.UserName!.Equals("patient0"))!.AddUserLogin("ApplicationLoginProvier", "Internal Login");

        foreach (var item in this.Users)
        {
            this.UserLogins.AddRange(item.UserLogins);
        }
    }

    private void LoadSpecializations()
    {
        // Medical specializations
        this.Specializations.Add(SpecializationFactory.Create("Cardiology", "A branch of medicine that deals with the disorders of the heart as well as some parts of the circulatory system."));
        this.Specializations.Add(SpecializationFactory.Create("Dermatology", "A branch of medicine dealing with the skin, nails, hair and its diseases."));
        this.Specializations.Add(SpecializationFactory.Create("Endocrinology", "A branch of biology and medicine dealing with the endocrine system, its diseases, and its specific secretions known as hormones."));
        this.Specializations.Add(SpecializationFactory.Create("Gastroenterology", "A branch of medicine focused on the digestive system and its disorders."));
        this.Specializations.Add(SpecializationFactory.Create("Hematology", "A branch of medicine concerning the study of blood, the blood-forming organs, and blood diseases."));
        this.Specializations.Add(SpecializationFactory.Create("Neurology", "A branch of medicine dealing with disorders of the nervous system."));
        this.Specializations.Add(SpecializationFactory.Create("Oncology", "A branch of medicine that deals with the prevention, diagnosis, and treatment of cancer."));
        this.Specializations.Add(SpecializationFactory.Create("Pediatrics", "A branch of medicine dealing with the health and medical care of infants, children, and adolescents from birth up to the age of 18."));
        this.Specializations.Add(SpecializationFactory.Create("Radiology", "A branch of medicine that uses imaging technology to diagnose and treat disease."));
        this.Specializations.Add(SpecializationFactory.Create("Surgery", "A branch of medicine that uses operative manual and instrumental techniques on a person to investigate or treat a pathological condition such as a disease or injury."));

        // Nursing specializations
        this.Specializations.Add(SpecializationFactory.Create("Pediatric Nurse", "Pediatric nurses work in a team with pediatricians to provide health care to children."));
        this.Specializations.Add(SpecializationFactory.Create("Neonatal Nurse", "Neonatal nurses care for newborn babies who are delivered prematurely or are suffering from health problems such as birth defects, infections, or heart deformities."));
        this.Specializations.Add(SpecializationFactory.Create("ICU Nurse", "ICU nurses work in intensive care units and provide care for patients with life-threatening health conditions."));
        this.Specializations.Add(SpecializationFactory.Create("Emergency Nurse", "Emergency nurses work in emergency rooms and provide care for patients with severe injuries and illnesses."));
        this.Specializations.Add(SpecializationFactory.Create("Oncology Nurse", "Oncology nurses care for patients and families who are dealing with cancer."));
        this.Specializations.Add(SpecializationFactory.Create("Orthopedic Nurse", "Orthopedic nurses care for patients with musculoskeletal diseases and disorders, such as arthritis, broken bones, joint replacements, fractures, diabetes, genetic malformations and osteoporosis."));
        this.Specializations.Add(SpecializationFactory.Create("Cardiac Nurse", "Cardiac nurses care for patients with heart diseases or conditions in the cardio vascular system."));
        this.Specializations.Add(SpecializationFactory.Create("Surgical Nurse", "Surgical nurses care for patients before, during and after surgery. They work alongside surgical teams to make sure that patients are receiving the best possible care."));
    }

    private void LoadUserSpecializations()
    {
        // Assign roles to doctors
        this.Users.FirstOrDefault(x => x.UserName!.Equals("doctor1"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("Cardiology"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("doctor2"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("Neurology"))!);

        // Assign roles to nurses
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse1"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("Pediatric Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse2"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("Neonatal Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse3"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("ICU Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse4"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("Emergency Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse5"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("Oncology Nurse"))!);
        this.Users.FirstOrDefault(x => x.UserName!.Equals("nurse6"))!.AddUserSpecialization(this.Specializations.FirstOrDefault(x => x.Name!.Equals("Orthopedic Nurse"))!);

        foreach (var item in this.Users)
        {
            this.UserSpecializations.AddRange(item.UserSpecializations);
        }
    }

    private void LoadScheduleDays()
    { }

    private void LoadScheduleSlots()
    { }
    #endregion
}

using HospitalManagementSystem.Domain;
using System.Linq;

namespace HospitalManagementSystem.DataProvider;

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
        BookingAppointments = new();
        ReExamAppointments = new();
        Referrals = new();
        ReferralDoctors = new();

        Departments = new();
        Rooms = new();
        RoomAllocations = new();
        //RoomAssignments = new();

        Drugs = new();
        DrugInventorys = new();
        DrugPrescriptions = new();
        Storages = new();
        GoodSupplings = new();
        Importations = new();
        DeviceInventorys = new();

        AssignmentHistories = new();
        Diagnoses = new();
        Diseases = new();
        MedicalExams = new();
        MedicalExamEposodes = new();
        Treatments = new();
        TreatmentExamEpisodes = new();

        DeviceServices = new();
        MedicalDevices = new();
        Services = new();
        AnalysisTests = new();

        this.Clear();
        this.Load();
    }
    #endregion

    #region [ Properties ]
    //public virtual DbSet<AppointmentBase>       AppointmentBases    { get; set; } = null!;
    public List<Domain.BookingAppointment>    BookingAppointments { get; private set; }
    public List<Domain.ReExamAppointment>     ReExamAppointments  { get; private set; }
    public List<Domain.Referral>              Referrals           { get; private set; }
    public List<Domain.ReferralDoctor>        ReferralDoctors     { get; private set; }

    public List<Domain.Department>        Departments     { get; private set; }
    public List<Domain.Room>              Rooms           { get; private set; }
    public List<Domain.RoomAllocation>    RoomAllocations { get; private set; }
    //public List<Domain.RoomAssignment>    RoomAssignments { get; private set; }

    public List<Domain.Drug>              Drugs               { get; private set; }
    public List<Domain.DrugInventory>     DrugInventorys      { get; private set; }
    public List<Domain.DrugPrescription>  DrugPrescriptions   { get; private set; }
    public List<Domain.Storage>           Storages            { get; private set; }
    public List<Domain.GoodSuppling>      GoodSupplings       { get; private set; }
    public List<Domain.Importation>       Importations        { get; private set; }
    public List<Domain.DeviceInventory>   DeviceInventorys    { get; private set; }

    public List<Domain.AssignmentHistory>       AssignmentHistories     { get; private set; }
    public List<Domain.Diagnosis>               Diagnoses               { get; private set; }
    //public virtual DbSet<DiagnosisSuggestion>   DiagnosisSuggestions    { get; set; }
    public List<Domain.Diseases>                Diseases                { get; private set; }
    public List<Domain.ICDCode>                 ICDCodes                { get; private set; }
    public List<Domain.ICDCodeVersion>          ICDCodeVersions         { get; private set; }
    public List<Domain.ICDVersion>              ICDVersions             { get; private set; }
    public List<Domain.MedicalExam>             MedicalExams            { get; private set; }
    public List<Domain.MedicalExamEpisode>      MedicalExamEposodes     { get; private set; }
    public List<Domain.Treatment>               Treatments              { get; private set; }
    public List<Domain.TreatmentExamEpisode>    TreatmentExamEpisodes   { get; private set; }

    public List<Domain.DeviceService>   DeviceServices  { get; private set; }
    public List<Domain.MedicalDevice>   MedicalDevices  { get; private set; }
    public List<Domain.Service>         Services        { get; private set; }
    public List<Domain.AnalysisTest>    AnalysisTests   { get; private set; }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
        LoadDiseases();
    }

    private void Clear()
    {
        BookingAppointments.Clear();
        ReExamAppointments.Clear();
        Referrals.Clear();
        ReferralDoctors.Clear();

        Departments.Clear();
        Rooms.Clear();
        RoomAllocations.Clear();
        //RoomAssignments.Clear();

        Drugs.Clear();
        DrugInventorys.Clear();
        DrugPrescriptions.Clear();
        Storages.Clear();
        GoodSupplings.Clear();
        Importations.Clear();
        DeviceInventorys.Clear();

        AssignmentHistories.Clear();
        Diagnoses.Clear();
        Diseases.Clear();
        ICDCodes.Clear();
        ICDCodeVersions.Clear();
        ICDVersions.Clear();
        MedicalExams.Clear();
        MedicalExamEposodes.Clear();
        Treatments.Clear();

        DeviceServices.Clear();
        MedicalDevices.Clear();
        Services.Clear();
        AnalysisTests.Clear();
    }
    #endregion

    #region [ Seed Create ]
    private void LoadDiseases()
    {
        var diseases = new List<(string Name, string Description, Domain.CodeStatus Status)>
        {
            ("Syphilis of liver and other viscera", "A bacterial infection affecting the liver and other organs", Domain.CodeStatus.Active),
            ("Chronic viral hepatitis C", "A long-term infection caused by the hepatitis C virus", Domain.CodeStatus.Active),
            ("Malignant neoplasm of liver, not specified as primary or secondary", "A type of liver cancer not specified as primary or secondary", Domain.CodeStatus.Active),
            ("Malignant neoplasm of unspecified ovary", "Cancer in an unspecified ovary", Domain.CodeStatus.Active),
            ("Mixed hyperlipidemia", "A disorder characterized by high levels of cholesterol and triglycerides", Domain.CodeStatus.Active),
            ("Other disorders of iron metabolism", "Disorders related to the processing of iron in the body", Domain.CodeStatus.Active),
            ("Cystic fibrosis, unspecified", "A genetic disorder affecting the lungs and digestive system", Domain.CodeStatus.Active),
            ("Other sideroblastic anemias", "A group of blood disorders characterized by anemia with ringed sideroblasts in the bone marrow", Domain.CodeStatus.Active),
            ("Alcoholic cirrhosis of liver without ascites", "Liver scarring due to alcohol abuse, without fluid accumulation in the abdomen", Domain.CodeStatus.Active),
            ("Chronic hepatitis, unspecified", "Long-term inflammation of the liver, unspecified type", Domain.CodeStatus.Active),
            ("Unspecified cirrhosis of liver", "Liver scarring with an unspecified cause", Domain.CodeStatus.Active),
            ("Other abnormal tumor markers", "Presence of tumor markers in the blood that are not normally found", Domain.CodeStatus.Active),
            ("Malignant neoplasm of colon, unspecified", "Cancer in an unspecified part of the colon", Domain.CodeStatus.Active),
            ("Malignant neoplasm of rectum", "Cancer in the rectum", Domain.CodeStatus.Active),
            ("Malignant neoplasm of intestinal tract, part unspecified", "Cancer in an unspecified part of the intestinal tract", Domain.CodeStatus.Active),
            ("Malignant neoplasm of unspecified part of unspecified bronchus or lung", "Cancer in an unspecified part of the bronchus or lung", Domain.CodeStatus.Active),
            ("Malignant neoplasm of unspecified site of unspecified female breast", "Cancer in an unspecified site of the female breast", Domain.CodeStatus.Active),
            ("Malignant neoplasm of unspecified ovary", "Cancer in an unspecified ovary", Domain.CodeStatus.Active),
            ("Finding of unspecified substance, not normally found in blood", "Presence of an unspecified substance in the blood that is not normally found", Domain.CodeStatus.Active),
            ("Other specified abnormal findings of blood chemistry", "Other specified abnormalities found in blood chemistry tests", Domain.CodeStatus.Active),
            ("Elevated carcinoembryonic antigen [CEA]", "Elevated levels of carcinoembryonic antigen, which may indicate cancer", Domain.CodeStatus.Active),
            ("Other abnormal tumor markers", "Presence of tumor markers in the blood that are not normally found", Domain.CodeStatus.Active),
            ("Personal history of malignant neoplasm of breast", "A personal history of breast cancer", Domain.CodeStatus.Inactive), // Assuming Inactive status due to 'history'
            ("Personal history of malignant neoplasm of ovary", "A personal history of ovarian cancer", Domain.CodeStatus.Inactive), // Assuming Inactive status due to 'history'
            ("Malignant neoplasm of endocervix", "Cancer in the endocervix", Domain.CodeStatus.Active),
            ("Malignant neoplasm of corpus uteri, unspecified", "Cancer in an unspecified part of the corpus uteri", Domain.CodeStatus.Active),
            ("Malignant neoplasm of unspecified fallopian tube", "Cancer in an unspecified fallopian tube", Domain.CodeStatus.Active),
            ("Malignant neoplasm of uterine adnexa, unspecified", "Cancer in an unspecified uterine adnexa", Domain.CodeStatus.Active),
            ("Secondary malignant neoplasm of unspecified ovary", "Secondary cancer in an unspecified ovary", Domain.CodeStatus.Active)
        };

        foreach (var (Name, Description, Status) in diseases)
        {
            this.Diseases.Add(DiseasesFactory.Create(Name, Description, Status));
        }

    }

    private void LoadICDVersions()
    {
        this.ICDVersions.Add(ICDVersionFactory.Create("ICD-10"));
        this.ICDVersions.Add(ICDVersionFactory.Create("ICD-11"));
    }

    private void LoadICDCodes()
    {
        var icdCodes = new Dictionary<string, (string ICD10, string ICD11)>
        {
            {"Syphilis of liver and other viscera", ("A52.7", "")},
            {"Chronic viral hepatitis C", ("B18.2", "1E51.1")},
            {"Malignant neoplasm of liver, not specified as primary or secondary", ("C22.9", "")},
            {"Malignant neoplasm of unspecified ovary", ("C56", "2C73")},
            {"Mixed hyperlipidemia", ("E78.2", "5C81")},
            {"Other disorders of iron metabolism", ("E83.1", "5C64.1Y")},
            {"Cystic fibrosis, unspecified", ("E84.9", "CA25.Z")},
            {"Other sideroblastic anemias", ("D64.3", "3A72.0Y")},
            {"Alcoholic cirrhosis of liver without ascites", ("K70.30", "")},
            {"Chronic hepatitis, unspecified", ("K73.9", "DB97.2")},
            {"Unspecified cirrhosis of liver", ("K74.60", "CA25.Z")},
            {"Other abnormal tumor markers", ("R97.8", "")},
            {"Malignant neoplasm of colon, unspecified", ("C18.9", "2B90.Z")},
            {"Malignant neoplasm of rectum", ("C20", "2B92")},
            {"Malignant neoplasm of intestinal tract, part unspecified", ("C26.9", "2C11.2")},
            {"Malignant neoplasm of unspecified part of unspecified bronchus or lung", ("C34.9", "")},
            {"Malignant neoplasm of unspecified site of unspecified female breast", ("C50.9", "")},
            {"Finding of unspecified substance, not normally found in blood", ("R78.9", "")},
            {"Other specified abnormal findings of blood chemistry", ("R79.8", "MA18.Y")},
            {"Elevated carcinoembryonic antigen [CEA]", ("R97.0", "")},
            {"Personal history of malignant neoplasm of breast", ("Z85.3", "QC40.3")},
            {"Personal history of malignant neoplasm of ovary", ("Z85.43", "")},
            {"Malignant neoplasm of endocervix", ("C53.0", "2C77.Z")},
            {"Malignant neoplasm of corpus uteri, unspecified", ("C54.9", "2C76.Z")},
            {"Malignant neoplasm of unspecified fallopian tube", ("C57.0", "2E05.Y")},
            {"Malignant neoplasm of uterine adnexa, unspecified", ("C57.7", "2C72.Z")},
            {"Secondary malignant neoplasm of unspecified ovary", ("C79.6", "2E05.0")}
        };

        var icd10Version = this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!;
        var icd11Version = this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!;

        foreach (var disease in this.Diseases)
        {
            if (icdCodes.TryGetValue(disease.Name, out var codes))
            {
                disease.AddICDCode(codes.ICD10);
                disease.AddICDCode(codes.ICD11);

                var icd10Code = disease.ICDCodes.FirstOrDefault(x => x.Code == codes.ICD10)!;
                icd10Code.AddICDCodeVersion(icd10Version, icd10Code.Id, icd10Version.Id);

                var icd11Code = disease.ICDCodes.FirstOrDefault(x => x.Code == codes.ICD11)!;
                icd11Code.AddICDCodeVersion(icd11Version, icd11Code.Id, icd11Version.Id);

            }
            this.ICDCodes.AddRange(disease.ICDCodes);
        }
    }

    private void LoadICDCodeVersions()
    {
        var icdCodes = new List<(string ICD10, string ICD11)>
        {
            ("A52.7", ""),
            ("B18.2", "1E51.1"),
            ("C22.9", ""),
            ("C56", "2C73"),
            ("E78.2", "5C81"),
            ("E83.1", "5C64.1Y"),
            ("E84.9", "CA25.Z"),
            ("D64.3", "3A72.0Y"),
            ("K70.30", ""),
            ("K73.9", "DB97.2"),
            ("K74.60", "CA25.Z"),
            ("R97.8", ""),
            ("C18.9", "2B90.Z"),
            ("C20", "2B92"),
            ("C26.9", "2C11.2"),
            ("C34.9", ""),
            ("C50.9", ""),
            ("R78.9", ""),
            ("R79.8", "MA18.Y"),
            ("R97.0", ""),
            ("Z85.3", "QC40.3"),
            ("Z85.43", ""),
            ("C53.0", "2C77.Z"),
            ("C54.9", "2C76.Z"),
            ("C57.0", "2E05.Y"),
            ("C57.7", "2C72.Z"),
            ("C79.6", "2E05.0")
        };

        var icd10Version = this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!;
        var icd11Version = this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!;

        foreach (var (ICD10, ICD11) in icdCodes)
        {
            var icd10Code = this.ICDCodes.FirstOrDefault(x => x.Code == ICD10)!;
            icd10Code.AddICDCodeVersion(icd10Version, icd10Code.Id, icd10Version.Id);

            var icd11Code = this.ICDCodes.FirstOrDefault(x => x.Code == ICD11)!;
            icd11Code.AddICDCodeVersion(icd11Version, icd11Code.Id, icd11Version.Id);
        }
    }

    private void LoadDiagnoses()
    {
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Syphilis of liver and other viscera"))!
                     .AddDiagnosis("", "Patient has severe symptoms and liver damage", "")
                     .AddDiagnosis("", "Patient has mild symptoms but liver damage is progressing", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic viral hepatitis C"))!
                     .AddDiagnosis("", "Patient has mild symptoms and is responding well to treatment", "")
                     .AddDiagnosis("", "Patient has severe symptoms and is not responding well to treatment", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant neoplasm of liver, not specified as primary or secondary"))!
                     .AddDiagnosis("", "Patient has a malignant neoplasm of the liver, but it's not clear if it's primary or secondary", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant neoplasm of unspecified ovary"))!
                     .AddDiagnosis("", "Patient has a malignant neoplasm in an unspecified ovary", "");
    }

    private void LoadTreatments()
    {
        //this.Treatments.Add(TreatmentFactory.Create("Stopping causative substances", "If the anemia is caused by exposure to certain substances, such as toxins or certain medications, stopping exposure to these substances can help treat the condition."));
        this.Treatments.Add(TreatmentFactory.Create("Antibiotic Therapy", "Treatment involves antibiotics such as penicillin to kill the bacteria causing syphilis."));
        this.Treatments.Add(TreatmentFactory.Create("Stopping causative substances", "If the syphilis is caused by exposure to certain substances, such as toxins or certain medications, stopping exposure to these substances can help treat the condition."));
        this.Treatments.Add(TreatmentFactory.Create("Follow-up blood tests and exams", "After treatment, regular blood tests and exams are needed to make sure the treatment is working."));

        this.Treatments.Add(TreatmentFactory.Create("Antiviral Medication", "Treatment involves antiviral medications to cure most cases of hepatitis C."));

        this.Treatments.Add(TreatmentFactory.Create("Liver Transplantation", "In severe cases, liver transplantation may be considered."));
        this.Treatments.Add(TreatmentFactory.Create("Chemotherapy", "Chemotherapy can be used to kill cancer cells."));

        this.Treatments.Add(TreatmentFactory.Create("Surgery and Chemotherapy", "Treatment usually involves a combination of surgery and chemotherapy."));

        this.Treatments.Add(TreatmentFactory.Create("Statins", "Medications like statins can help lower cholesterol levels."));

        this.Treatments.Add(TreatmentFactory.Create("Dietary Advice", "Treatment can include dietary advice to manage iron levels."));
        this.Treatments.Add(TreatmentFactory.Create("Medication", "Treatment can include medication to reduce the iron levels in your blood."));

        this.Treatments.Add(TreatmentFactory.Create("Medications and Therapies", "Treatment focuses on medicines and therapies to clear the airway and improve the function of the faulty CFTR protein."));


        // Treatments for "Other sideroblastic anemias"
        this.Treatments.Add(TreatmentFactory.Create("Blood Transfusions", "In some cases, blood transfusions may be needed to treat anemia."));
        this.Treatments.Add(TreatmentFactory.Create("Chelation Therapy", "If iron overload occurs due to the anemia, chelation therapy may be used to remove excess iron from the body."));

        // Treatments for "Alcoholic cirrhosis of liver without ascites"
        this.Treatments.Add(TreatmentFactory.Create("Lifestyle Changes", "The primary treatment for alcoholic cirrhosis is to stop drinking alcohol. A healthy diet and regular exercise can also help improve liver health."));
        this.Treatments.Add(TreatmentFactory.Create("Medications", "Medications may be used to manage symptoms or complications of cirrhosis."));
        this.Treatments.Add(TreatmentFactory.Create("Liver Transplant", "In severe cases, a liver transplant may be considered."));
 
        // Treatments for "Unspecified cirrhosis of liver"
        this.Treatments.Add(TreatmentFactory.Create("Lifestyle Changes", "Lifestyle changes such as reducing salt intake, stopping alcohol consumption, and maintaining a healthy diet can help manage cirrhosis."));

        // Treatments for "Other abnormal tumor markers"
        this.Treatments.Add(TreatmentFactory.Create("Further Testing", "Abnormal tumor markers can indicate the presence of cancer, but further testing is usually needed to confirm the diagnosis."));
        this.Treatments.Add(TreatmentFactory.Create("Targeted Therapy", "If cancer is confirmed, targeted therapies may be used to treat cancers that have specific tumor markers."));

        // Treatments for "Malignant neoplasm of colon, unspecified"
        this.Treatments.Add(TreatmentFactory.Create("Surgery", "Surgery is often the main treatment for colon cancer, and may range from minimally invasive techniques to more extensive surgery."));
        this.Treatments.Add(TreatmentFactory.Create("Chemotherapy", "Chemotherapy may be used to kill cancer cells, especially in more advanced stages of colon cancer."));
        this.Treatments.Add(TreatmentFactory.Create("Radiation Therapy", "Radiation therapy may be used to kill cancer cells and shrink tumors, often in combination with surgery and chemotherapy."));
    }
    #endregion
}

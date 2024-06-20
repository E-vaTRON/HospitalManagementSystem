using HospitalManagementSystem.Domain;
using Microsoft.Identity.Client.Extensions.Msal;
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

        Drugs = new();
        DrugPrescriptions = new();
        Storages = new();
        Importations = new();
        DeviceInventories = new();

        AssignmentHistories = new();
        Diagnoses = new();
        Diseases = new();
        ICDCodes = new();
        ICDCodeVersions = new();
        ICDVersions = new();
        MedicalExams = new();
        MedicalExamEposodes = new();
        Treatments = new();

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
    public List<Domain.BookingAppointment>  BookingAppointments { get; private set; }
    public List<Domain.ReExamAppointment>   ReExamAppointments  { get; private set; }
    public List<Domain.Referral>            Referrals           { get; private set; }
    public List<Domain.ReferralDoctor>      ReferralDoctors     { get; private set; }

    public List<Domain.Department>      Departments     { get; private set; }
    public List<Domain.Room>            Rooms           { get; private set; }
    public List<Domain.RoomAllocation>  RoomAllocations { get; private set; }
    //public List<Domain.RoomAssignment>    RoomAssignments { get; private set; }

    public List<Domain.Drug>                Drugs               { get; private set; }
    public List<Domain.DrugInventory>       DrugInventories     { get; private set; }
    public List<Domain.DrugPrescription>    DrugPrescriptions   { get; private set; }
    public List<Domain.Storage>             Storages            { get; private set; }
    //public List<Domain.GoodSuppling> GoodSupplings { get; private set; }
    public List<Domain.Importation>         Importations        { get; private set; }
    public List<Domain.DeviceInventory>     DeviceInventories   { get; private set; }

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

    public List<Domain.DeviceService> DeviceServices    { get; private set; }
    public List<Domain.MedicalDevice> MedicalDevices    { get; private set; }
    public List<Domain.Service> Services                { get; private set; }
    public List<Domain.AnalysisTest> AnalysisTests      { get; private set; }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
        LoadDiseases();
        LoadICDVersions();
        LoadICDCodes();
        LoadICDCodeVersions();
        LoadDiagnoses();  // ??
        LoadTreatments();
        LoadMedicalDevice();
        LoadService();
        LoadStorage();
        LoadDeviceInventories();
        LoadDeviceServices();
        LoadDrugs();
        LoadImportations();
        LoadDrugInventories();
        LoadDepartments();
        LoadRoom();
    }

    private void Clear()
    {
        BookingAppointments.Clear();
        ReExamAppointments.Clear();
        Referrals.Clear();
        ReferralDoctors.Clear();

        Departments.Clear();            //
        Rooms.Clear();                  //
        RoomAllocations.Clear();

        Drugs.Clear();                  //
        DrugInventories.Clear();        //
        DrugPrescriptions.Clear();
        Storages.Clear();               //
        Importations.Clear();           //
        DeviceInventories.Clear();      //

        AssignmentHistories.Clear();
        Diagnoses.Clear();              // ??
        Diseases.Clear();               //
        ICDCodes.Clear();               //
        ICDCodeVersions.Clear();        //
        ICDVersions.Clear();            //
        MedicalExams.Clear();
        MedicalExamEposodes.Clear();
        Treatments.Clear();             //

        DeviceServices.Clear();         //
        MedicalDevices.Clear();         //
        Services.Clear();               //
        AnalysisTests.Clear();
    }
    #endregion

    #region [ Seed Create ]
    private void LoadDiseases()
    {
        this.Diseases.Add(DiseasesFactory.Create("Syphilis of liver and other viscera", 
                                                 "A bacterial infection affecting the liver and other organs", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Chronic viral hepatitis C", 
                                                 "A long-term infection caused by the hepatitis C virus",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of liver, not specified as primary or secondary", 
                                                 "A type of liver cancer not specified as primary or secondary",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of unspecified ovary",
                                                 "Cancer in an unspecified ovary", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Mixed hyperlipidemia",
                                                 "A disorder characterized by high levels of cholesterol and triglycerides", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other disorders of iron metabolism", 
                                                 "Disorders related to the processing of iron in the body", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Cystic fibrosis, unspecified", 
                                                 "A genetic disorder affecting the lungs and digestive system", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other sideroblastic anemias", 
                                                 "A group of blood disorders characterized by anemia with ringed sideroblasts in the bone marrow", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Alcoholic cirrhosis of liver without ascites",
                                                 "Liver scarring due to alcohol abuse, without fluid accumulation in the abdomen", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Chronic hepatitis, unspecified", 
                                                 "Long-term inflammation of the liver, unspecified type", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Unspecified cirrhosis of liver", 
                                                 "Liver scarring with an unspecified cause", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other abnormal tumor markers", 
                                                 "Presence of tumor markers in the blood that are not normally found",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of colon, unspecified", 
                                                 "Cancer in an unspecified part of the colon", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of rectum", 
                                                 "Cancer in the rectum", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of intestinal tract, part unspecified", 
                                                 "Cancer in an unspecified part of the intestinal tract", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of unspecified part of unspecified bronchus or lung",
                                                 "Cancer in an unspecified part of the bronchus or lung", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of unspecified site of unspecified female breast", 
                                                 "Cancer in an unspecified site of the female breast", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of unspecified ovary",
                                                 "Cancer in an unspecified ovary", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Finding of unspecified substance, not normally found in blood", 
                                                 "Presence of an unspecified substance in the blood that is not normally found",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other specified abnormal findings of blood chemistry",
                                                 "Other specified abnormalities found in blood chemistry tests", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Elevated carcinoembryonic antigen [CEA]", 
                                                 "Elevated levels of carcinoembryonic antigen, which may indicate cancer", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other abnormal tumor markers", 
                                                 "Presence of tumor markers in the blood that are not normally found", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Personal history of malignant neoplasm of breast", 
                                                 "A personal history of breast cancer",
                                                 Domain.CodeStatus.Inactive));
        this.Diseases.Add(DiseasesFactory.Create("Personal history of malignant neoplasm of ovary", 
                                                 "A personal history of ovarian cancer",
                                                 Domain.CodeStatus.Inactive));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of endocervix", 
                                                 "Cancer in the endocervix", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of corpus uteri, unspecified", 
                                                 "Cancer in an unspecified part of the corpus uteri", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of unspecified fallopian tube", 
                                                 "Cancer in an unspecified fallopian tube",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant neoplasm of uterine adnexa, unspecified", 
                                                 "Cancer in an unspecified uterine adnexa", 
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Secondary malignant neoplasm of unspecified ovary", 
                                                 "Secondary cancer in an unspecified ovary", 
                                                 Domain.CodeStatus.Active));
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
        this.Treatments.Add(TreatmentFactory.Create("Antibiotic Therapy", "This treatment involves the use of antibiotics to kill bacteria causing various infections."));
        this.Treatments.Add(TreatmentFactory.Create("Antiviral Medication", "This treatment involves the use of antiviral medications to treat viral infections."));
        this.Treatments.Add(TreatmentFactory.Create("Chemotherapy", "This treatment involves the use of drugs to kill cancer cells."));
        this.Treatments.Add(TreatmentFactory.Create("Radiation Therapy", "This treatment uses high-energy radiation to shrink tumors and kill cancer cells."));
        this.Treatments.Add(TreatmentFactory.Create("Surgery", "This treatment involves surgical procedures to remove tumors or repair damage."));
        this.Treatments.Add(TreatmentFactory.Create("Lifestyle Changes", "This treatment involves changes in diet, exercise, and other lifestyle factors to manage various conditions."));
        this.Treatments.Add(TreatmentFactory.Create("Regular Check-ups", "This involves regular medical check-ups to monitor for any signs of disease recurrence or complications."));
        this.Treatments.Add(TreatmentFactory.Create("Further Testing", "This involves additional testing to confirm a diagnosis and determine the cause of abnormal findings."));
        this.Treatments.Add(TreatmentFactory.Create("Targeted Therapy", "This treatment involves the use of drugs or other substances to identify and attack specific types of cancer cells."));
        this.Treatments.Add(TreatmentFactory.Create("Blood Transfusions", "This treatment involves receiving blood or parts of blood through an IV line."));
        this.Treatments.Add(TreatmentFactory.Create("Chelation Therapy", "This treatment involves the administration of chelating agents to remove heavy metals from the body."));
        this.Treatments.Add(TreatmentFactory.Create("Liver Transplant", "This treatment involves transplanting a healthy liver from a donor to replace a diseased liver."));
        this.Treatments.Add(TreatmentFactory.Create("Medication", "This treatment involves the use of medication to manage symptoms or treat the underlying cause of a condition."));
    }

    private void LoadMedicalDevice()
    {
        // Ultrasound Machines
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE Voluson E10 Ultrasound Machine", "USA", "", "", 10, 100));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips EPIQ Elite Ultrasound Machine", "USA", "", "", 10, 100));

        // Electrocardiogram (ECG) Machines
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE MAC 5500 HD ECG Machine", "Germany", "", "", 20, 200));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips PageWriter TC70 ECG Machine", "Germany", "", "", 20, 200));

        // X-ray Machines
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE Optima XR220amx X-ray Machine", "Japan", "", "", 30, 300));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips DigitalDiagnost C90 X-ray Machine", "Japan", "", "", 30, 300));


        // Magnetic Resonance Imaging (MRI) Machines
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE SIGNA Premier MRI Machine", "USA", "", "", 40, 400));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips Ingenia Elition MRI Machine", "USA", "", "", 40, 400));

        // Computed Tomography (CT) Scanners
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE Revolution CT Scanner", "Germany", "", "", 50, 500));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips Incisive CT Scanner", "Germany", "", "", 50, 500));

        // Positron Emission Tomography (PET) Scanners
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE Discovery MI PET Scanner", "Japan", "", "", 60, 600));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips Vereos PET Scanner", "Japan", "", "", 60, 600));

        // Defibrillators
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE Responder 2000 Defibrillator", "USA", "", "", 70, 700));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips HeartStart XL Defibrillator", "USA", "", "", 70, 700));

        // Ventilators
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("GE CARESCAPE R860 Ventilator", "Germany", "", "", 80, 800));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Philips V680 Ventilator", "Germany", "", "", 80, 800));

        // Dialysis Machines
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Fresenius 2008K Dialysis Machine", "Japan", "", "", 90, 900));
        this.MedicalDevices.Add(MedicalDeviceFactory.Create("Baxter HomeChoice Pro Dialysis Machine", "Japan", "", "", 90, 900));
    }

    private void LoadService()
    {
        // Common services
        this.Services.Add(ServiceFactory.Create("Routine Check-up", Domain.ServiceType.Visit, 50, 100, 80, Domain.FormTypes.TestForm));
        this.Services.Add(ServiceFactory.Create("Blood Test", Domain.ServiceType.Test, 20, 40, 30, Domain.FormTypes.TestForm));
        this.Services.Add(ServiceFactory.Create("X-ray", Domain.ServiceType.Scan, 100, 200, 150, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("MRI Scan", Domain.ServiceType.Scan, 500, 1000, 750, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Ultrasound", Domain.ServiceType.Scan, 200, 400, 300, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Physical Therapy Session", Domain.ServiceType.Session, 75, 150, 100, Domain.FormTypes.TestForm));
        this.Services.Add(ServiceFactory.Create("Vaccination", Domain.ServiceType.Dose, 25, 50, 40, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Dental Cleaning", Domain.ServiceType.Visit, 100, 200, 150, Domain.FormTypes.TestForm));
        this.Services.Add(ServiceFactory.Create("Eye Examination", Domain.ServiceType.Visit, 75, 150, 100, Domain.FormTypes.TestForm));
        this.Services.Add(ServiceFactory.Create("Dermatology Consultation", Domain.ServiceType.Visit, 80, 160, 120, Domain.FormTypes.TestForm));
        this.Services.Add(ServiceFactory.Create("Psychiatry Consultation", Domain.ServiceType.Visit, 120, 240, 180, Domain.FormTypes.TestForm));

        // Rare services
        this.Services.Add(ServiceFactory.Create("Cardiac Catheterization", Domain.ServiceType.Procedure, 2000, 4000, 3000, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Colonoscopy", Domain.ServiceType.Procedure, 800, 1600, 1200, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Endoscopy", Domain.ServiceType.Procedure, 800, 1600, 1200, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Joint Replacement Surgery", Domain.ServiceType.Surgery, 20000, 40000, 30000, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Cataract Surgery", Domain.ServiceType.Surgery, 3500, 7000, 5000, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Chemotherapy Session", Domain.ServiceType.Session, 2000, 4000, 3000, Domain.FormTypes.AnalysisForm));

        // Really rare services
        this.Services.Add(ServiceFactory.Create("Organ Transplant", Domain.ServiceType.Surgery, 100000, 200000, 150000, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Gamma Knife Surgery", Domain.ServiceType.Surgery, 20000, 40000, 30000, Domain.FormTypes.AnalysisForm));
        this.Services.Add(ServiceFactory.Create("Bone Marrow Transplant", Domain.ServiceType.Surgery, 50000, 100000, 75000, Domain.FormTypes.AnalysisForm));
    }

    private void LoadStorage()
    {
        this.Storages.Add(StorageFactory.Create("Location 1"));
        this.Storages.Add(StorageFactory.Create("Location 2"));
    }

    private void LoadDeviceInventories()
    {
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Voluson E10 Ultrasound Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips EPIQ Elite Ultrasound Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE MAC 5500 HD ECG Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips PageWriter TC70 ECG Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Optima XR220amx X-ray Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips DigitalDiagnost C90 X-ray Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location  1"))!);

        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE SIGNA Premier MRI Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 2"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips Ingenia Elition MRI Machine"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 2"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Revolution CT Scanner"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 2"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips Incisive CT Scanner"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 2"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Discovery MI PET Scanner"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 2"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips Vereos PET Scanner"))!
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 2"))!);

        foreach (var item in MedicalDevices)
        {
            this.DeviceInventories.AddRange(item.DeviceInventories);
        }
    }

    private void LoadDeviceServices()
    {
        this.Services.FirstOrDefault(s => s.Name.Equals("Ultrasound"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("GE Voluson E10 Ultrasound Machine"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("Ultrasound"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("Philips EPIQ Elite Ultrasound Machine"))!.ToList());

        this.Services.FirstOrDefault(s => s.Name.Equals("Routine Check-up"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("GE MAC 5500 HD ECG Machine"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("Routine Check-up"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("Philips PageWriter TC70 ECG Machine"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("Routine Check-up"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("GE Revolution CT Scanner"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("Routine Check-up"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("Philips Incisive CT Scanner"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("Routine Check-up"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("GE Discovery MI PET Scanner"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("Routine Check-up"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("Philips Vereos PET Scanner"))!.ToList());

        this.Services.FirstOrDefault(s => s.Name.Equals("X-ray"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("GE Optima XR220amx X-ray Machine"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("X-ray"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("Philips DigitalDiagnost C90 X-ray Machine"))!.ToList());

        this.Services.FirstOrDefault(s => s.Name.Equals("MRI Scan"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("GE SIGNA Premier MRI Machine"))!.ToList());
        this.Services.FirstOrDefault(s => s.Name.Equals("MRI Scan"))!
                     .AddToDeviceInventories(this.DeviceInventories.Where(x => x.MedicalDevice!.Name.Equals("Philips Ingenia Elition MRI Machine"))!.ToList());

        foreach (var item in Services)
        {
            this.DeviceServices.AddRange(item.DeviceServices);
        }
    }

    private void LoadDrugs()
    {
        this.Drugs.Add(DrugFactory.Create("Lipitor", "Atorvastatin",
                                          "This drug can interact with grapefruit juice, which can lead to potentially dangerous effects.", 
                                          " Common side effects include headache, stomach pain, and mild muscle pain.", 
                                          Domain.Units.Tablets, "Statins", 10, 5, "USA", "A01"));

        this.Drugs.Add(DrugFactory.Create("Nexium", "Esomeprazole",
                                          "This drug can interact with certain other stomach acid drugs like sucralfate.", 
                                          "Common side effects include headache, diarrhea, nausea, gas, stomach pain, constipation, and dry mouth.", 
                                          Domain.Units.Tablets, "Proton Pump Inhibitors", 15, 7, "USA", "A02"));

        this.Drugs.Add(DrugFactory.Create("Plavix", "Clopidogrel",
                                          "This drug can interact with omeprazole or esomeprazole, reducing its effectiveness.", 
                                          " Common side effects include bleeding, nausea, and diarrhea.", 
                                          Domain.Units.Tablets, "Antiplatelet", 20, 10, "USA", "A03"));

        this.Drugs.Add(DrugFactory.Create("Advair Diskus", "Fluticasone/Salmeterol",
                                          "This drug can interact with certain other drugs like ritonavir, atazanavir, clarithromycin, indinavir, itraconazole, nefazodone, nelfinavir, ketoconazole, telithromycin, conivaptan, lopinavir, nefazodone, voriconazole, and others.", 
                                          "Common side effects include throat irritation, hoarseness, voice changes, nausea, vomiting.", 
                                          Domain.Units.Inhaler, "Bronchodilator", 30, 15, "USA", "A04"));

        this.Drugs.Add(DrugFactory.Create("Abilify", "Aripiprazole",
                                          "This drug can interact with certain other drugs like carbamazepine, phenytoin, rifampin, and others.", 
                                          "Common side effects include weight gain, headache, agitation, anxiety, insomnia, and nausea.", 
                                          Domain.Units.Tablets, "Antipsychotic", 40, 20, "USA", "A05"));

        this.Drugs.Add(DrugFactory.Create("Seroquel", "Quetiapine",
                                          "This drug can interact with certain other drugs like phenytoin, thioridazine, and others.", 
                                          "SCommon side effects include drowsiness, dizziness, and constipation.", 
                                          Domain.Units.Tablets, "Antipsychotic", 50, 25, "USA", "A06"));

        this.Drugs.Add(DrugFactory.Create("Singulair", "Montelukast",
                                          "This drug can interact with certain other drugs like phenobarbital and rifampin.", 
                                          "Common side effects include headache, stomach pain, heartburn, upset stomach, nausea, diarrhea, tooth pain, tiredness, fever, stuffy nose, sore throat, cough, hoarseness, and flu-like symptoms.", 
                                          Domain.Units.Tablets, "Leukotriene Receptor Antagonist", 60, 30, "USA", "A07"));

        this.Drugs.Add(DrugFactory.Create("Crestor", "Rosuvastatin",
                                          "This drug can interact with certain other drugs like cyclosporine, gemfibrozil.", 
                                          "Common side effects include muscle pain, constipation, nausea, stomach pain, and weakness.", 
                                          Domain.Units.Tablets, "Statins", 70, 35, "USA", "A08"));

        this.Drugs.Add(DrugFactory.Create("Actos", "Pioglitazone",
                                          "This drug can interact with gemfibrozil, rifampin.", 
                                          "Common side effects include sore throat, weight gain, and sinusitis.", 
                                          Domain.Units.Tablets, "Antidiabetic", 80, 40, "USA", "A09"));

        this.Drugs.Add(DrugFactory.Create("Epogen", "Epoetin Alfa",
                                          "This drug can interact with certain other drugs like lenalidomide, pomalidomide, thalidomide.", 
                                          "Common side effects include joint, muscle, or bone pain.", 
                                           Domain.Units.Injection, "Erythropoiesis-Stimulating Agent", 90, 45, "USA", "A10"));

        this.Drugs.Add(DrugFactory.Create("Diovan", "Valsartan",
                                          "This drug can interact with aliskiren, lithium.", 
                                          "Common side effects include headache, dizziness, viral infection, fatigue, abdominal pain, cough, diarrhea, and nausea.", 
                                          Domain.Units.Tablets, "Angiotensin II Receptor Blocker", 100, 50, "USA", "A11"));

        this.Drugs.Add(DrugFactory.Create("Lantus", "Insulin Glargine",
                                          "Can interact with rosiglitazone",
                                          "Common side effects include hypoglycemia, allergic reactions, injection site reactions, lipodystrophy, pruritus, rash, edema",
                                          Domain.Units.Injection, "Long-Acting Insulin", 110, 55, "USA", "A12"));

        this.Drugs.Add(DrugFactory.Create("Cymbalta", "Duloxetine",
                                          "Can interact with MAO inhibitors, thioridazine, procarbazine",
                                          "Common side effects include nausea, dry mouth, sleepiness, fatigue, constipation, loss of appetite, and sweating",
                                          Domain.Units.Capsules, "Serotonin-Norepinephrine Reuptake Inhibitor", 120, 60, "USA", "A13"));

        this.Drugs.Add(DrugFactory.Create("Vyvanse", "Lisdexamfetamine",
                                          "Can interact with MAO inhibitors",
                                          "Common side effects include anxiety, decreased appetite, weight loss, irritability, nausea, vomiting, and dizziness",
                                          Domain.Units.Capsules, "Stimulant", 130, 65, "USA", "A14"));

        this.Drugs.Add(DrugFactory.Create("Lyrica", "Pregabalin",
                                          "Can interact with alcohol, opioids",
                                          "Common side effects include dizziness, sleepiness, weight gain, swelling of hands and feet, trouble concentrating, and dry mouth",
                                          Domain.Units.Capsules, "Anticonvulsant", 140, 70, "USA", "A15"));

        this.Drugs.Add(DrugFactory.Create("Spiriva", "Tiotropium",
                                          "Can interact with atropine, belladonna, cimetidine, clidinium, dicyclomine, glycopyrrolate, hyoscyamine, mepenzolate, methantheline, methscopolamine, propantheline, scopolamine",
                                          "Common side effects include dry mouth, sinusitis, pharyngitis, non-specific chest pain, urinary tract infection, indigestion",
                                          Domain.Units.Inhaler, "Bronchodilator", 150, 75, "USA", "A16"));

        this.Drugs.Add(DrugFactory.Create("Januvia", "Sitagliptin",
                                          "Can interact with insulin or a sulfonylurea",
                                          "Common side effects include upper respiratory tract infection, stuffy or runny nose and sore throat, and headache",
                                          Domain.Units.Tablets, "Dipeptidyl Peptidase-4 Inhibitor", 160, 80, "USA", "A17"));

        this.Drugs.Add(DrugFactory.Create("Bystolic", "Nebivolol",
                                          "Can interact with reserpine, monoamine oxidase (MAO) inhibitors",
                                          "Common side effects include headache, fatigue, dizziness, diarrhea, nausea, insomnia, chest pain, bradycardia, dyspnea, rash",
                                          Domain.Units.Tablets, "Beta Blocker", 170, 85, "USA", "A18"));

        this.Drugs.Add(DrugFactory.Create("Suboxone", "Buprenorphine/Naloxone",
                                          "Can interact with other CNS depressants",
                                          "Common side effects include headache, drug withdrawal syndrome, insomnia, pain, sweating, nausea, and constipation",
                                          Domain.Units.Film, "Opioid Partial Agonist and Antagonist", 180, 90, "USA", "A19"));

        this.Drugs.Add(DrugFactory.Create("Tamiflu", "Oseltamivir",
                                          "Can interact with live attenuated influenza vaccine",
                                          "Common side effects include nausea and vomiting",
                                          Domain.Units.Capsules, "Neuraminidase Inhibitor", 190, 95, "USA", "A20"));

        this.Drugs.Add(DrugFactory.Create("Zestril", "Lisinopril", 
                                          "Can interact with potassium supplements or diuretics", 
                                          "Common side effects include cough, dizziness, and lightheadedness", 
                                          Domain.Units.Tablets, "ACE inhibitors", 200, 100, "USA", "A21"));

        this.Drugs.Add(DrugFactory.Create("Norvasc", "Amlodipine", 
                                          "Can interact with dantrolene and simvastatin", 
                                          "Common side effects include swelling of the ankles/feet, dizziness, and flushing", 
                                          Domain.Units.Tablets, "Calcium channel blockers", 210, 105, "USA", "A22"));

        this.Drugs.Add(DrugFactory.Create("Prinivil", "Lisinopril", 
                                          "Can interact with aliskiren, lithium, gold injections, and drugs that weaken the immune system", 
                                          "Common side effects include dizziness, lightheadedness, and tiredness", 
                                          Domain.Units.Tablets, "ACE inhibitors", 220, 110, "USA", "A23"));

        this.Drugs.Add(DrugFactory.Create("Glucophage", "Metformin", 
                                          "Can interact with cephalexin", 
                                          "Common side effects include stomach upset, nausea, and diarrhea", 
                                          Domain.Units.Tablets, "Biguanides", 230, 115, "USA", "A24"));

        this.Drugs.Add(DrugFactory.Create("Zocor", "Simvastatin", 
                                          "Can interact with red yeast rice", 
                                          "Common side effects include muscle pain, tenderness, and weakness", 
                                          Domain.Units.Tablets, "Statins", 240, 120, "USA", "A25"));

        this.Drugs.Add(DrugFactory.Create("Microzide", "Hydrochlorothiazide", 
                                          "Can interact with dofetilide", 
                                          "Common side effects include dizziness, lightheadedness, and blurred vision", 
                                          Domain.Units.Tablets, "Thiazides", 250, 125, "USA", "A26"));

        this.Drugs.Add(DrugFactory.Create("Synthroid", 
                                          "Levothyroxine", "Can interact with estrogens", 
                                          "Common side effects include hair loss, sweating, and heat intolerance", 
                                          Domain.Units.Tablets, "Thyroid drugs", 260, 130, "USA", "A27"));

        this.Drugs.Add(DrugFactory.Create("Lopressor", "Metoprolol", 
                                          "Can interact with bupropion", 
                                          "Common side effects include drowsiness, dizziness, and tiredness", 
                                          Domain.Units.Tablets, "Beta blockers", 270, 135, "USA", "A28"));

        this.Drugs.Add(DrugFactory.Create("Cozaar", "Losartan", 
                                          "Can interact with lithium", 
                                          "Common side effects include dizziness, lightheadedness, and stuffy nose",
                                          Domain.Units.Tablets, "ARBs", 280, 140, "USA", "A29"));

        this.Drugs.Add(DrugFactory.Create("Zithromax", "Azithromycin", 
                                          "Can interact with aluminum and magnesium antacids", 
                                          "Common side effects include diarrhea, nausea, and stomach pain", 
                                          Domain.Units.Capsules, "Macrolides", 290, 145, "USA", "A30"));

        this.Drugs.Add(DrugFactory.Create("Amoxil", "Amoxicillin", 
                                          "Can interact with methotrexate", 
                                          "Common side effects include nausea, vomiting, and diarrhea", 
                                          Domain.Units.Capsules, "Penicillins", 300, 150, "USA", "A31"));

        this.Drugs.Add(DrugFactory.Create("Vicodin", "Hydrocodone/Acetaminophen", 
                                          "Can interact with azelastine", 
                                          "Common side effects include lightheadedness, dizziness, and nausea", 
                                          Domain.Units.Film, "Narcotic analgesics", 310, 155, "USA", "A32"));

        this.Drugs.Add(DrugFactory.Create("Deltasone", "Prednisone", 
                                          "Can interact with aldesleukin", 
                                          "Common side effects include nausea, loss of appetite, and heartburn", 
                                          Domain.Units.Tablets, "Corticosteroids", 320, 160, "USA", "A33"));

        this.Drugs.Add(DrugFactory.Create("Neurontin", "Gabapentin", 
                                          "Can interact with antacids containing aluminum or magnesium", 
                                          "Common side effects include drowsiness, dizziness, and loss of coordination", 
                                          Domain.Units.Capsules, "Anti-convulsants", 330, 165, "USA", "A34"));

        this.Drugs.Add(DrugFactory.Create("Prilosec", "Omeprazole", 
                                          "Can interact with clopidogrel", 
                                          "Common side effects include headache, abdominal pain, and nausea", 
                                          Domain.Units.Capsules, "Proton pump inhibitors", 340, 170, "USA", "A35"));

        this.Drugs.Add(DrugFactory.Create("Norvasc", "Amlodipine", 
                                          "Can interact with dantrolene and simvastatin", 
                                          "Common side effects include swelling of the ankles/feet, dizziness, and flushing", 
                                          Domain.Units.Tablets, "Calcium channel blockers", 350, 175, "USA", "A36"));

        this.Drugs.Add(DrugFactory.Create("Glucophage", "Metformin", 
                                          "Can interact with cephalexin", 
                                          "Common side effects include stomach upset, nausea, and diarrhea", 
                                          Domain.Units.Tablets, "Biguanides", 360, 180, "USA", "A37"));

        this.Drugs.Add(DrugFactory.Create("Zocor", "Simvastatin", 
                                          "Can interact with red yeast rice", 
                                          "Common side effects include muscle pain, tenderness, and weakness", 
                                          Domain.Units.Tablets, "Statins", 370, 185, "USA", "A38"));

        this.Drugs.Add(DrugFactory.Create("Microzide", "Hydrochlorothiazide", 
                                          "Can interact with dofetilide", 
                                          "Common side effects include dizziness, lightheadedness, and blurred vision", 
                                          Domain.Units.Tablets, "Thiazides", 380, 190, "USA", "A39"));

        this.Drugs.Add(DrugFactory.Create("Synthroid", "Levothyroxine", 
                                          "Can interact with estrogens", 
                                          "Common side effects include hair loss, sweating, and heat intolerance", 
                                          Domain.Units.Tablets, "Thyroid drugs", 390, 195, "USA", "A40"));



        this.Drugs.Add(DrugFactory.Create("Gleevec", "Imatinib",
                                          "Can interact with grapefruit juice, St. John’s wort, and others",
                                          "Common side effects include edema, nausea, vomiting, muscle cramps, bone pain, diarrhea, rash, fatigue, and abdominal pain",
                                          Domain.Units.Tablets, "Tyrosine-Kinase Inhibitor", 1000, 500, "USA", "B01"));

        this.Drugs.Add(DrugFactory.Create("Herceptin", "Trastuzumab",
                                          "Can interact with anthracycline-based chemotherapy drugs",
                                          "Common side effects include fever, nausea, vomiting, infusion reactions, diarrhea, infections, increased cough, headache, fatigue, shortness of breath, rash, neutropenia, anemia, and myalgia",
                                          Domain.Units.Injection, "Monoclonal Antibody", 2000, 1000, "USA", "B02"));

        this.Drugs.Add(DrugFactory.Create("Revlimid", "Lenalidomide",
                                          "Can interact with digoxin and warfarin",
                                          "Common side effects include fatigue, constipation, diarrhea, muscle cramp, nausea, and rash",
                                          Domain.Units.Capsules, "Immunomodulatory Agents", 2000, 1000, "USA", "B03"));

        this.Drugs.Add(DrugFactory.Create("Opdivo", "Nivolumab",
                                          "Can interact with corticosteroids and hormone replacement therapy",
                                          "Common side effects include fatigue, rash, musculoskeletal pain, pruritus, diarrhea, nausea, and asthenia",
                                          Domain.Units.Injection, "Monoclonal Antibody", 2100, 1050, "USA", "B04"));

        this.Drugs.Add(DrugFactory.Create("Keytruda", "Pembrolizumab",
                                          "Can interact with corticosteroids and hormone replacement therapy",
                                          "Common side effects include fatigue, musculoskeletal pain, decreased appetite, pruritus, diarrhea, nausea, rash, pyrexia, cough, dyspnea, constipation, pain, and abdominal pain",
                                          Domain.Units.Injection, "Monoclonal Antibody", 2200, 1100, "USA", "B05"));

        this.Drugs.Add(DrugFactory.Create("Herceptin", "Trastuzumab",
                                          "Can interact with anthracycline-based chemotherapy drugs",
                                          "Common side effects include fever, nausea, vomiting, infusion reactions, diarrhea, infections, increased cough, headache, fatigue, shortness of breath, rash, neutropenia, anemia, and myalgia",
                                          Domain.Units.Injection, "Monoclonal Antibody", 2300, 1150, "USA", "B06"));

        this.Drugs.Add(DrugFactory.Create("Rituxan", "Rituximab",
                                          "Can interact with cisplatin",
                                          "Common side effects include infusion reactions, fever, lymphopenia, chills, infection, and asthenia",
                                          Domain.Units.Injection, "Monoclonal Antibody", 2400, 1200, "USA", "B07"));

    }

    private void LoadImportations()
    {
        this.Importations.Add(ImportationFactory.Create("Receipt 1", "Bill 1", DateTime.Now, DateTime.Now.AddDays(1), 10, 1000, "Company 1"));
        this.Importations.Add(ImportationFactory.Create("Receipt 2", "Bill 2", DateTime.Now, DateTime.Now.AddDays(2), 20, 2000, "Company 2"));
    }

    private void LoadDrugInventories()
    {
        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Lipitor"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 1"))!, 
                                "Atorvastatin", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Nexium"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 1"))!, 
                                "Esomeprazole", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Plavix"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 2"))!, 
                                "Clopidogrel", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Advair Diskus"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 2"))!, 
                                "Fluticasone/Salmeterol", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Abilify"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 1"))!, 
                                "Aripiprazole", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Seroquel"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 2"))!,
                                "Quetiapine", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Singulair"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 1"))!, 
                                "Montelukast", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Crestor"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!, 
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 2"))!, 
                                "Rosuvastatin", DateTime.Now.AddYears(2), 100);

        // Rare case drugs
        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Gleevec"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!,
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 1"))!, 
                                "Imatinib", DateTime.Now.AddYears(2), 100);

        this.Drugs.FirstOrDefault(x => x.GoodName.Equals("Herceptin"))!
                  .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!,
                                this.Importations.FirstOrDefault(x => x.ReceiptNumber.Equals("Receipt 2"))!, 
                                "Trastuzumab", DateTime.Now.AddYears(2), 100);

        foreach (var item in this.Drugs)
        {
            this.DrugInventories.AddRange(item.DrugInventories);
        }
    }

    private void LoadDepartments()
    {
        this.Departments.Add(DepartmentFactory.Create("Anesthesiology"));
        this.Departments.Add(DepartmentFactory.Create("Dermatology"));
        this.Departments.Add(DepartmentFactory.Create("Emergency Medicine"));
        this.Departments.Add(DepartmentFactory.Create("Endocrinology"));
        this.Departments.Add(DepartmentFactory.Create("Gastroenterology"));
        this.Departments.Add(DepartmentFactory.Create("Geriatrics"));
        this.Departments.Add(DepartmentFactory.Create("Hematology"));
        this.Departments.Add(DepartmentFactory.Create("Infectious Disease"));
        this.Departments.Add(DepartmentFactory.Create("Nephrology"));
        this.Departments.Add(DepartmentFactory.Create("Obstetrics and Gynecology"));
        this.Departments.Add(DepartmentFactory.Create("Oncology"));
        this.Departments.Add(DepartmentFactory.Create("Ophthalmology"));
        this.Departments.Add(DepartmentFactory.Create("Otolaryngology"));
        this.Departments.Add(DepartmentFactory.Create("Pathology"));
        this.Departments.Add(DepartmentFactory.Create("Psychiatry"));
        this.Departments.Add(DepartmentFactory.Create("Pulmonology"));
        this.Departments.Add(DepartmentFactory.Create("Rheumatology"));
        this.Departments.Add(DepartmentFactory.Create("Surgery"));
        this.Departments.Add(DepartmentFactory.Create("Urology"));
    }

    private void LoadRoom()
    {
        // For Anesthesiology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("F1R1", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("F1R2", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("F2R3", Domain.RoomType.Recovery, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("F2R4", Domain.RoomType.Recovery, 2);

        // For Dermatology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("F2R1", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("F2R2", Domain.RoomType.Inpatient, 2);

        // For Emergency Medicine Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("F1R1", Domain.RoomType.Triage, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("F1R2", Domain.RoomType.TreatmentBay, 4);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("F2R1", Domain.RoomType.Resuscitation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("F2R2", Domain.RoomType.ShortStay, 4);

        // For Endocrinology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Endocrinology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Endocrinology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Endocrinology"))!.AddRoom("F2R1", Domain.RoomType.Inpatient, 2);

        // For Gastroenterology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("F2R1", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("F2R2", Domain.RoomType.Inpatient, 2);

        // For Geriatrics Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Geriatrics"))!.AddRoom("F1R1", Domain.RoomType.General, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Geriatrics"))!.AddRoom("F1R2", Domain.RoomType.General, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Geriatrics"))!.AddRoom("F2R1", Domain.RoomType.General, 2);

        // For Hematology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("F2R1", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("F2R2", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("F2R3", Domain.RoomType.Isolation, 1);

        // For Infectious Disease Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Infectious Disease"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Infectious Disease"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Infectious Disease"))!.AddRoom("F2R1", Domain.RoomType.Isolation, 2);

        // For Nephrology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("F2R1", Domain.RoomType.DialysisStation, 4);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("F2R2", Domain.RoomType.Inpatient, 2);

        // For Obstetrics and Gynecology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("F1R1", Domain.RoomType.LaborAndDelivery, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("F1R2", Domain.RoomType.GynecologicalConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("F2R1", Domain.RoomType.Postpartum, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("F2R2", Domain.RoomType.Operating, 1);

        // For Oncology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("F1R2", Domain.RoomType.Chemotherapy, 4);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("F2R1", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("F2R2", Domain.RoomType.Isolation, 2);

        // For Ophthalmology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Ophthalmology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Ophthalmology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Ophthalmology"))!.AddRoom("F2R1", Domain.RoomType.Procedure, 1);

        // For Pathology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pathology"))!.AddRoom("F1R1", Domain.RoomType.Laboratory, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pathology"))!.AddRoom("F1R2", Domain.RoomType.Laboratory, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pathology"))!.AddRoom("F2R1", Domain.RoomType.Laboratory, 1);

        // For Psychiatry Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("F1R2", Domain.RoomType.Therapy, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("F2R1", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("F2R2", Domain.RoomType.Inpatient, 2);

        // For Pulmonology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("F2R1", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("F2R2", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("F2R3", Domain.RoomType.ICU, 2);

        // For Rheumatology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Rheumatology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Rheumatology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);

        // For Surgery Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Surgery"))!.AddRoom("F1R1", Domain.RoomType.Operating, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Surgery"))!.AddRoom("F1R2", Domain.RoomType.Operating, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Surgery"))!.AddRoom("F2R1", Domain.RoomType.Recovery, 4);

        // For Urology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("F1R2", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("F2R1", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("F2R2", Domain.RoomType.Inpatient, 2);
    }
    #endregion
}

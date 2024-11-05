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
        DrugInventories = new();
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
        MedicalExamEpisodes = new();
        Treatments = new();

        ServiceEpisodes = new();
        MedicalDevices = new();
        MedicalServices = new();
        AnalysisTests = new();

        Bills = new();

        this.Clear();
        this.Load();
        this.Clean();
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
    public List<Domain.MedicalExamEpisode>      MedicalExamEpisodes     { get; private set; }
    public List<Domain.Treatment>               Treatments              { get; private set; }
    //public List<Domain.TreatmentExamEpisode>    TreatmentExamEpisodes   { get; private set; }

    public List<Domain.ServiceEpisode>      ServiceEpisodes     { get; private set; }
    public List<Domain.FormType>            FormTypes           { get; private set; }
    public List<Domain.MedicalDevice>       MedicalDevices      { get; private set; }
    public List<Domain.MedicalDeviceForm>   MedicalDeviceForms  { get; private set; }
    public List<Domain.MedicalService>      MedicalServices     { get; private set; }
    public List<Domain.AnalysisTest>        AnalysisTests       { get; private set; }

    public List<Domain.Bill> Bills { get; private set; }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
        LoadDiseases();
        LoadICDVersions();
        LoadICDCodes();
        LoadICDCodeVersions();
        LoadTreatments();
        LoadFormType();
        LoadMedicalDevice();
        LoadMedicalDeviceForm();
        LoadMedicalService();
        LoadStorage();
        LoadDeviceInventories();
        LoadDrugs();
        LoadImportations();
        LoadDrugInventories();
        LoadDepartments();
        LoadRoom();
        LoadBookingAppointment();
        LoadMedicalExam();
        LoadMedicalExamEpisode();
        //LoadMedicalExamEpisodeRelated();
        LoadAssignmentHistory();
        LoadDiagnosis();
        LoadAnalysisTest();
        LoadServiceEpisode();
    }

    private void Clear()
    {
        BookingAppointments.Clear();    //
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
        Diagnoses.Clear();              
        Diseases.Clear();               //
        ICDCodes.Clear();               //
        ICDCodeVersions.Clear();        //
        ICDVersions.Clear();            //
        MedicalExams.Clear();           //
        MedicalExamEpisodes.Clear();    //
        Treatments.Clear();             //

        ServiceEpisodes.Clear();        //
        FormTypes.Clear();
        MedicalDevices.Clear();         //
        MedicalDeviceForms.Clear();
        MedicalServices.Clear();        //
        AnalysisTests.Clear();
    }

    private void Clean()
    {
        BookingAppointments.ForEach(x => x.RemoveRelated());
        ReExamAppointments.ForEach(x => x.RemoveRelated());
        Referrals.ForEach(x => x.RemoveRelated());
        ReferralDoctors.ForEach(x => x.RemoveRelated());

        Departments.ForEach(x => x.RemoveRelated());
        Rooms.ForEach(x => x.RemoveRelated());
        RoomAllocations.ForEach(x => x.RemoveRelated());

        Drugs.ForEach(x => x.RemoveRelated());
        DrugInventories.ForEach(x => x.RemoveRelated());
        DrugPrescriptions.ForEach(x => x.RemoveRelated());
        Storages.ForEach(x => x.RemoveRelated());
        Importations.ForEach(x => x.RemoveRelated());
        DeviceInventories.ForEach(x => x.RemoveRelated());

        AssignmentHistories.ForEach(x => x.RemoveRelated());
        Diagnoses.ForEach(x => x.RemoveRelated());
        Diseases.ForEach(x => x.RemoveRelated());
        ICDCodes.ForEach(x => x.RemoveRelated());
        ICDCodeVersions.ForEach(x => x.RemoveRelated());
        ICDVersions.ForEach(x => x.RemoveRelated());
        MedicalExams.ForEach(x => x.RemoveRelated());
        MedicalExamEpisodes.ForEach(x => x.RemoveRelated());
        Treatments.ForEach(x => x.RemoveRelated());

        ServiceEpisodes.ForEach(x => x.RemoveRelated());
        MedicalDevices.ForEach(x => x.RemoveRelated());
        MedicalServices.ForEach(x => x.RemoveRelated());
        AnalysisTests.ForEach(x => x.RemoveRelated());
    }
    #endregion

    #region [ Seed Create ]
    private void LoadDiseases()
    {
        #region [ Infectious Disease Department ]
        this.Diseases.Add(DiseasesFactory.Create("Late Syphilis",
                                                 "A late stage of syphilis infection where the disease has progressed to affect internal organs such as the heart, brain, nerves, eyes, blood vessels, liver, bones, and joints. Symptoms may include severe damage to these organs, potentially leading to serious health complications and even death if left untreated.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Cardiology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Lipoprotein Metabolism and Other Lipidaemias",
                                                 "Conditions involving abnormal levels or function of lipoproteins and other lipids in the blood. This can include hyperlipidemia, hypolipidemia, and disorders affecting the metabolism of cholesterol and triglycerides.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Hyperlipoproteinaemia",
                                                 "A condition characterized by elevated levels of lipoproteins in the blood, which can increase the risk of cardiovascular diseases. It can be genetic (primary) or due to other health conditions (secondary).",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Hematology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Other Anaemias",
                                                 "Various types of anaemia not specified elsewhere, involving a reduction in red blood cells or hemoglobin.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Sideroblastic Anaemia",
                                                 "A rare disorder where the body cannot incorporate iron into hemoglobin, leading to ineffective red blood cell production.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Pathology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Findings of Drugs and Other Substances, Not Normally Found in Blood",
                                                 "Detection of drugs or other substances in the blood that are not typically present, often indicating exposure or ingestion.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Specified Abnormal Findings of Blood Chemistry",
                                                 "Abnormal results in blood chemistry tests that do not fall under other specified categories, indicating potential underlying health issues.",
                                                  Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Certain Clinical Findings of Blood Chemistry",
                                                 "Clinical findings in blood chemistry tests that indicate potential abnormalities or underlying health conditions.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Oncology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Breast",
                                                 "A cancerous growth originating in the breast tissue, often presenting as a lump or mass and requiring medical intervention for treatment.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Breast, Unspecified",
                                                 "A condition where cancerous cells form in the tissues of the breast. The unspecified type indicates that the exact subtype or location of the cancer within the breast has not been determined.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Liver and Intrahepatic Bile Ducts",
                                                 "A type of cancer that originates in the liver or the intrahepatic bile ducts. This condition is characterized by the uncontrolled growth of abnormal cells in these areas, leading to potential liver dysfunction, jaundice, and other serious health issues.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Liver or Intrahepatic Bile Ducts",
                                                 "A type of cancer that originates in the liver or the intrahepatic bile ducts. This condition is characterized by the abnormal and uncontrolled growth of cells in these areas, potentially causing significant liver dysfunction and other related complications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Ovary",
                                                 "A cancerous tumor that originates in the ovaries. It can be primary, originating in the ovaries themselves, or metastatic, spreading from other parts of the body. Common types include serous, mucinous, and endometrioid adenocarcinomas, as well as malignant germ cell tumors.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Nonspecific Abnormal Histological and Immunological Findings",
                                                 "The presence of abnormal cells or immune responses in tissue samples that do not point to a specific disease or condition. These findings require further investigation to determine their clinical significance.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Abnormal Tumor Markers",
                                                 "Diagnostic category for abnormal levels of substances often produced by cancer cells or in response to cancer.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Colon",
                                                 "A cancerous growth originating in the colon, often associated with symptoms like changes in bowel habits, blood in stool, and abdominal discomfort.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Rectum",
                                                 "A cancerous growth originating in the rectum, often presenting symptoms such as rectal bleeding, changes in bowel habits, and discomfort or pain in the rectal area.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Other and Ill-Defined Digestive Organs",
                                                 "Cancerous growths in the digestive organs that are not clearly classified under a specific category.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Other or Ill-Defined Digestive Organs",
                                                 "Cancerous growths occurring in the digestive system organs that are either unspecified or do not clearly fit into known categories.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Personal History of Malignant Neoplasm",
                                                 "A medical record indicating a past diagnosis of a cancerous growth, used to track and monitor potential recurrence or related health issues.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Cervix Uteri",
                                                 "A cancerous growth originating in the cervix uteri, often caused by human papillomavirus (HPV) infection, characterized by abnormal vaginal bleeding, pelvic pain, and other symptoms.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Cervix Uteri",
                                                 "Cancerous growths originating in the cervix uteri, leading to symptoms like abnormal vaginal bleeding and pelvic pain.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Body of Uterus",
                                                 "A cancerous tumor found in the main part of the uterus, characterized by symptoms such as abnormal uterine bleeding and pelvic discomfort.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Corpus Uteri",
                                                 "A cancerous growth originating in the body of the uterus, often presenting with abnormal vaginal bleeding, pelvic pain, and other related symptoms.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Corpus Uteri",
                                                 "Cancerous growths originating in the body of the uterus, encompassing various types and stages of malignancy, often presenting with abnormal vaginal bleeding and pelvic pain.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Ovary and Other Uterine Adnexa",
                                                 "Cancerous growths originating in the ovary and other related structures in the female reproductive system, which may include the fallopian tubes and other uterine adnexa.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Other and Unspecified Female Genital Organs",
                                                 "Cancerous growths occurring in the female genital organs, including the fallopian tube, ovary, and others, when not otherwise specified.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Uterine Ligament, Parametrium, or Uterine Adnexa",
                                                 "Cancerous growths that develop in the uterine ligaments, parametrium, or uterine adnexa. These malignancies can lead to symptoms such as pelvic pain, abnormal bleeding, and potential spread to surrounding tissues.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Secondary Malignant Neoplasm of Other Specified Sites",
                                                 "Cancerous tumors that have spread from the primary site to other specified locations in the body, causing secondary malignancies. The symptoms and impact depend on the specific sites affected.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Secondary Malignant Neoplasm of Other and Unspecified Sites",
                                                 "Cancerous growths that have spread from their original (primary) site to other parts of the body. These secondary neoplasms can affect various organs and tissues, and their symptoms depend on the affected areas.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm Metastasis in Female Reproductive System",
                                                 "Cancerous tumors that have spread from other parts of the body to the female reproductive organs, including the ovaries, causing secondary malignancies.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Dermatology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Atopic Dermatitis and Related Conditions",
                                                 "A group of chronic skin conditions characterized by inflammation, itching, and redness, often associated with a personal or family history of allergies.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Atopic Dermatitis",
                                                 "A chronic skin condition causing inflammation, itching, and redness, often associated with a personal or family history of allergies.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Atopic Eczema",
                                                 "A chronic skin condition causing inflammation, itching, and redness, often associated with a personal or family history of allergies.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Diseases of Hair and Hair Follicles",
                                                 "A variety of conditions affecting hair growth, health, and appearance, including Alopecia Areata, Androgenetic Alopecia, Telogen Effluvium, Trichotillomania, Folliculitis, Seborrheic Dermatitis, and Tinea Capitis.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Alopecia Areata",
                                                 "An autoimmune condition where the immune system attacks hair follicles, leading to hair loss. It typically causes round, smooth patches of baldness on the scalp, but can affect any hair-bearing area of the body.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Endocrinology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Diabetes Mellitus",
                                                 "A group of metabolic disorders characterized by high blood sugar levels over a prolonged period. It results from defects in insulin production, insulin action, or both. Common types include Type 1 Diabetes, where the body fails to produce insulin, and Type 2 Diabetes, where the body does not use insulin properly or becomes insulin resistant.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Type 1 Diabetes Mellitus",
                                                 "An autoimmune condition where the body's immune system attacks and destroys the insulin-producing cells in the pancreas. This leads to little or no insulin production, requiring lifelong insulin therapy. Symptoms often include excessive thirst, frequent urination, and unexplained weight loss.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Type 2 Diabetes Mellitus",
                                                 "A chronic condition characterized by insulin resistance and impaired insulin production. This leads to high blood sugar levels over time, which can result in complications like heart disease, kidney failure, and vision loss. Symptoms often include excessive thirst, frequent urination, and fatigue.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acquired Hypothyroidism",
                                                 "A condition where the thyroid gland fails to produce sufficient hormones due to factors such as autoimmune disorders, surgical removal, radiation treatment, or certain medications. Symptoms include fatigue, weight gain, and sensitivity to cold.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Hypothyroidism",
                                                 "A category encompassing various forms of hypothyroidism that do not fit specific classifications. It includes hypothyroidism due to iodine deficiency, drug-induced hypothyroidism, and other less common causes.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Hypothyroidism",
                                                 "A condition where the thyroid gland does not produce enough thyroid hormones, leading to symptoms like fatigue, weight gain, and cold intolerance. It can affect metabolism, energy levels, and overall health.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Thyrotoxicosis with or without Goiter",
                                                 "A condition resulting from excessive thyroid hormones, with or without the presence of an enlarged thyroid gland (goiter). Symptoms include rapid heart rate, weight loss, sweating, and nervousness.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Thyrotoxicosis [Hyperthyroidism]",
                                                 "A condition characterized by an overactive thyroid gland, producing excessive thyroid hormones and causing symptoms like rapid heart rate, weight loss, and nervousness.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Thyrotoxicosis",
                                                 "A condition resulting from excessive thyroid hormones in the body, leading to symptoms such as rapid heart rate, weight loss, sweating, and nervousness. It can be caused by hyperthyroidism, thyroid nodules, or certain medications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Adrenal Glands",
                                                 "A broad term encompassing all conditions and diseases affecting the adrenal glands, including both functional and structural problems. These disorders can impact hormone levels and lead to symptoms affecting multiple body systems, often requiring specific medical treatments.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Adrenal Gland",
                                                 "This category includes a variety of conditions affecting the adrenal glands that are not covered by specific diagnoses. These disorders can range from structural abnormalities to functional issues, potentially affecting hormone production and overall health.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Adrenocortical Insufficiency",
                                                 "A condition where the adrenal cortex doesn't produce enough steroid hormones, particularly cortisol and aldosterone. Symptoms include fatigue, muscle weakness, weight loss, low blood pressure, and skin darkening. It can be life-threatening if not treated with hormone replacement therapy.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Rheumatology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Bone and Cartilage",
                                                 "This category includes various conditions that affect bones and cartilage but are not classified under specific diagnoses. It covers a range of disorders including metabolic, structural, and congenital abnormalities. Symptoms can vary widely depending on the specific disorder and may include pain, deformities, or functional impairments.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Osteoporosis Without Pathological Fracture",
                                                 "A condition characterized by decreased bone density and strength without an associated fracture. This type of osteoporosis often remains undiagnosed until a bone mineral density test is performed. It increases the risk of fractures but does not present any immediate symptoms.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Low Bone Mass Disorders",
                                                 "Conditions that result in lower than normal bone density, increasing the risk of fractures. This category includes osteopenia and other conditions that may precede osteoporosis. Patients with low bone mass are typically monitored and managed to prevent progression to osteoporosis.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Rheumatoid Arthritis and Other Inflammatory Polyarthropathies",
                                                 "A group of autoimmune disorders characterized by chronic inflammation of multiple joints. This includes rheumatoid arthritis and other similar conditions that cause joint pain, swelling, and damage.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Rheumatoid Arthritis",
                                                 "Variants of rheumatoid arthritis that do not fall under the typical classification. These may include atypical presentations or less common forms of the disease, all characterized by chronic joint inflammation and pain.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Rheumatoid Arthritis",
                                                 "A chronic autoimmune disorder that primarily affects the joints, causing inflammation, pain, and eventual joint damage. It can also affect other organs and systems, leading to a wide range of symptoms.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Osteoarthrosis and Allied Disorders",
                                                 "A collection of conditions involving the degeneration of joint cartilage and underlying bone, leading to joint pain, stiffness, and impaired movement. These disorders encompass osteoarthritis and related degenerative joint diseases.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Arthrosis",
                                                 "A group of joint disorders characterized by the degradation of cartilage and other joint tissues, resulting in pain, swelling, and decreased joint function. This category includes various forms of arthrosis that do not fall under specific classifications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Osteoarthritis of Knee",
                                                 "A degenerative joint disease affecting the knee, characterized by the breakdown of cartilage, leading to pain, stiffness, and reduced mobility. It commonly occurs due to aging, injury, or repetitive stress on the knee joint.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Psoriasis and Similar Disorders",
                                                 "A group of chronic skin conditions characterized by red, scaly patches. These disorders, including psoriasis, often involve an immune response that accelerates skin cell turnover, resulting in inflammation and discomfort.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Psoriasis",
                                                 "A chronic autoimmune condition that causes rapid skin cell turnover, leading to red, scaly patches on the skin. It can affect various parts of the body and is often accompanied by itching and discomfort.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Psoriatic Arthritis",
                                                 "An inflammatory arthritis associated with psoriasis. It causes joint pain, stiffness, and swelling, and can lead to joint damage if not managed properly. The condition combines symptoms of both arthritis and psoriasis.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Diffuse Diseases of Connective Tissue",
                                                 "A group of disorders characterized by widespread inflammation and damage to connective tissues in the body. These conditions often involve the immune system attacking the body's own tissues, leading to symptoms that can affect multiple organs.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Systemic Lupus Erythematosus",
                                                 "A chronic autoimmune disease where the immune system attacks various tissues and organs, causing inflammation and damage. It can affect the skin, joints, kidneys, brain, and other organs, leading to a wide range of symptoms.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Lupus Erythematosus",
                                                 "An autoimmune disease that primarily affects the skin and other organs. It encompasses various forms, including systemic lupus erythematosus (SLE) and cutaneous lupus erythematosus, causing symptoms ranging from skin rashes to organ inflammation.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Ankylosing Spondylitis and Other Inflammatory Spondylopathies",
                                                 "A group of inflammatory diseases that primarily affect the spine, causing pain, stiffness, and potential fusion of the vertebrae. This category includes ankylosing spondylitis and other related conditions that lead to chronic inflammation in the spine and sacroiliac joints.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Ankylosing Spondylitis",
                                                 "A chronic inflammatory disease that affects the spine and sacroiliac joints, causing pain and stiffness. Over time, it can lead to the fusion of the vertebrae, resulting in a loss of spinal flexibility and mobility.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Inflammatory Spondyloarthritis",
                                                 "A group of inflammatory conditions that primarily affect the spine and peripheral joints. These disorders, including ankylosing spondylitis, are characterized by chronic inflammation, pain, and stiffness in the affected areas.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Gout",
                                                 "A type of arthritis characterized by sudden, severe attacks of pain, swelling, redness, and tenderness in the joints, often affecting the big toe. It occurs due to the accumulation of urate crystals in the joint, resulting from high levels of uric acid in the blood.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Soft Tissues",
                                                 "A category of conditions affecting the body's soft tissues, such as muscles, tendons, ligaments, and connective tissues. These disorders can cause pain, swelling, and impaired function, and are not classified under specific, well-known categories.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Soft Tissue Disorders, Not Elsewhere Classified",
                                                 "A group of soft tissue conditions that do not fit into established classifications. These disorders may involve pain, inflammation, or degeneration of muscles, tendons, ligaments, and other soft tissues.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Chronic Pain",
                                                 "A long-standing pain that persists beyond the usual course of an acute illness or injury, or more than 3 to 6 months. It can be constant or intermittent, significantly affecting an individual's quality of life and daily function.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Systemic Involvement of Connective Tissue",
                                                 "Various conditions where the immune system causes inflammation and damage to connective tissues, affecting multiple organs and systems. These disorders are not specifically classified under more commonly known connective tissue diseases.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Overlap or Undifferentiated Non-Organ Specific Systemic Autoimmune Disease",
                                                 "A condition where an individual exhibits features of multiple autoimmune diseases without fitting the criteria for a specific diagnosis. Symptoms can affect various organs and systems due to widespread inflammation and immune system dysfunction.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Systemic Sclerosis",
                                                 "An autoimmune disorder characterized by the overproduction of collagen, leading to hardening and tightening of the skin and connective tissues. It can also affect internal organs, causing complications in the heart, lungs, kidneys, and digestive system.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Polymyalgia Rheumatica",
                                                "An inflammatory disorder causing muscle pain and stiffness, primarily in the shoulders, neck, and hips. It typically affects older adults and can lead to significant discomfort and mobility issues. Symptoms often improve with corticosteroid treatment.",
                                                Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Arteries and Arterioles",
                                                 "A group of conditions affecting the arteries and arterioles, which are small branches of arteries. These disorders can include various forms of arteritis, arterial blockages, and abnormalities in the structure or function of these blood vessels, leading to impaired blood flow and other complications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Necrotizing Vasculopathies",
                                                 "A group of inflammatory diseases characterized by the necrosis (death) of blood vessel walls, leading to tissue damage and organ dysfunction. These conditions involve severe inflammation of blood vessels, often resulting in significant clinical symptoms and requiring urgent medical treatment.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Vasculitis",
                                                 "An inflammation of the blood vessels that can affect any part of the body. This condition can cause changes in the blood vessel walls, including thickening, weakening, narrowing, or scarring, which can restrict blood flow and result in organ and tissue damage. It encompasses a range of diseases that differ in severity and affected areas.",
                                                 Domain.CodeStatus.Active));



        #endregion

        #region [ Gastroenterology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Chronic Viral Hepatitis",
                                                 "A long-term inflammation of the liver caused by viral infection. It can lead to liver damage, cirrhosis, liver cancer, and liver failure if left untreated. Common viruses causing chronic hepatitis include Hepatitis B and Hepatitis C.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Mineral Metabolism",
                                                 "Conditions affecting how the body processes and utilizes minerals, such as calcium, magnesium, and phosphorus. These disorders can impact bone health, muscle function, and nerve signaling, potentially leading to symptoms like muscle weakness, cramps, bone pain, and abnormal heart rhythms.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Mineral Absorption or Transport",
                                                 "Conditions involving issues with the body's ability to absorb minerals from the diet or transport them within the body. These disorders can result in mineral deficiencies and related health problems, such as weakened bones, muscle spasms, and fatigue.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Alcoholic Liver Disease",
                                                 "A condition caused by excessive alcohol consumption, leading to liver inflammation and damage.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Chronic Hepatitis, not elsewhere classified",
                                                 "A chronic inflammatory liver condition, not specified under other categories.",
                                                  Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Certain Specified Inflammatory Liver Diseases",
                                                 "A group of liver conditions characterized by specific inflammatory processes.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Diseases of Esophagus",
                                                 "These are a range of conditions that affect the esophagus, the muscular tube that connects the throat to the stomach. These diseases can include structural abnormalities, inflammatory conditions, motility disorders, and neoplasms. Common symptoms are difficulty swallowing, chest pain, and acid reflux.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Gastro-Oesophageal Reflux Disease",
                                                 "A chronic condition where stomach acid frequently flows back into the esophagus, causing irritation and inflammation. Symptoms include heartburn, regurgitation, and difficulty swallowing. Long-term GERD can lead to complications such as esophagitis, Barrett’s esophagus, and an increased risk of esophageal cancer.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Functional Digestive Disorders, Not Elsewhere Classified",
                                                 "This category includes a range of digestive disorders that do not have a clear organic cause and are not classified under other specific diagnoses. Symptoms can include abdominal pain, bloating, and changes in bowel habits. These disorders often affect the function of the digestive tract without visible signs of disease.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Irritable Bowel Syndrome",
                                                 "A common disorder affecting the large intestine, characterized by symptoms such as cramping, abdominal pain, bloating, gas, and changes in bowel habits, including diarrhea and constipation. The exact cause of IBS is unknown, but it is often managed with diet, lifestyle changes, and medication.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Irritable Bowel Syndrome or Certain Specified Functional Bowel Disorders",
                                                 "This category includes irritable bowel syndrome (IBS) and other specified functional bowel disorders. These conditions typically involve chronic abdominal pain, bloating, and changes in bowel habits without any clear organic cause. Management often includes dietary changes, lifestyle adjustments, and medications to alleviate symptoms.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Regional Enteritis",
                                                 "A chronic inflammatory condition of the gastrointestinal tract, primarily affecting the small intestine and colon. It leads to symptoms such as abdominal pain, diarrhea, weight loss, and fatigue. The exact cause is unknown, but it involves an abnormal immune response to intestinal bacteria.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Crohn Disease [Regional Enteritis]",
                                                 "A type of inflammatory bowel disease that can affect any part of the gastrointestinal tract from mouth to anus. It causes chronic inflammation, leading to abdominal pain, severe diarrhea, fatigue, weight loss, and malnutrition. The disease is characterized by periods of remission and relapse.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Crohn Disease",
                                                 "A chronic inflammatory disease of the intestines, particularly the ileum and colon. It is marked by symptoms including abdominal pain, diarrhea, weight loss, and fatigue. The disease often leads to complications such as strictures, fistulas, and abscesses. The exact cause is unknown but is believed to involve genetic and environmental factors.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Ulcerative Colitis",
                                                 "A chronic inflammatory bowel disease (IBD) that primarily affects the lining of the large intestine (colon) and rectum. It is characterized by ulcers and long-lasting inflammation, leading to symptoms such as abdominal pain, diarrhea, rectal bleeding, and urgent bowel movements. Management typically involves medication to reduce inflammation and maintain remission, and sometimes surgery.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Intestinal Malabsorption",
                                                 "A condition where the small intestine cannot absorb nutrients effectively from the food consumed. This can lead to deficiencies in vitamins, minerals, and other essential nutrients, causing symptoms such as weight loss, diarrhea, bloating, and fatigue. The underlying causes can vary and may include diseases like celiac disease, Crohn's disease, and certain infections. Treatment focuses on addressing the underlying cause and supplementing the deficient nutrients.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Coeliac Disease",
                                                 "An autoimmune disorder where the ingestion of gluten leads to damage in the small intestine. This causes malabsorption of nutrients, leading to symptoms like diarrhea, weight loss, and fatigue. The only effective treatment is a strict, lifelong gluten-free diet.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Cholelithiasis",
                                                 "A condition characterized by the formation of gallstones in the gallbladder. These stones can range in size and may cause symptoms such as abdominal pain, nausea, vomiting, and jaundice if they obstruct the bile ducts. Treatment options include medications to dissolve the stones or surgical removal of the gallbladder.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Diverticula of Intestine",
                                                 "Refers to the formation of small pouches called diverticula in the walls of the intestine. These can be asymptomatic or lead to complications like diverticulitis or diverticular bleeding. Management includes dietary changes and, in some cases, medical or surgical interventions.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Diverticular Disease of Intestine",
                                                 "This includes various conditions related to the presence of diverticula in the intestine. It encompasses both asymptomatic diverticulosis and symptomatic diverticulitis, where the diverticula become inflamed or infected, leading to symptoms such as abdominal pain, fever, and changes in bowel habits.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Diverticulosis of Unspecified Part of Intestine without Haemorrhage",
                                                 "A condition characterized by the formation of small pouches (diverticula) in the walls of an unspecified part of the intestine. These pouches do not cause bleeding or haemorrhage and may be asymptomatic or cause mild symptoms such as abdominal pain or discomfort.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Functional Intestinal Disorders",
                                                 "A group of conditions affecting the intestines that are characterized by chronic symptoms without an identifiable organic cause. These disorders can cause significant discomfort and may include symptoms such as abdominal pain, bloating, and irregular bowel movements.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Change in Bowel Habit",
                                                 "Refers to any alteration in normal bowel movements, including changes in frequency, consistency, or the presence of symptoms like diarrhea or constipation. It can be a sign of various underlying conditions, ranging from benign to more serious issues.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Haemorrhoids",
                                                 "Swollen blood vessels in and around the anus and lower rectum. They can be internal or external and often cause symptoms such as pain, itching, bleeding, and discomfort during bowel movements. Treatment options include dietary changes, medications, and in severe cases, surgical interventions.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Haemorrhoids and Perianal Venous Thrombosis",
                                                 "This condition involves swollen blood vessels in and around the anus and lower rectum (haemorrhoids) and the formation of blood clots (thrombosis) in the veins around the anus. Symptoms can include severe pain, swelling, and bleeding. Treatment may involve medications, lifestyle changes, and sometimes surgical intervention to remove the blood clot.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Benign Neoplasm of Other Parts of Digestive System",
                                                 "A non-cancerous growth in parts of the digestive system other than the stomach. These neoplasms can occur in the small intestine, large intestine, or other ill-defined parts of the digestive tract. They may cause symptoms such as abdominal pain, obstruction, or bleeding, depending on their location and size.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Diseases of Intestine",
                                                 "This category includes various conditions affecting the intestines that do not fall under specific diagnoses. These diseases can involve inflammation, infection, obstruction, or other functional disorders. Symptoms may include abdominal pain, diarrhea, constipation, and changes in bowel habits.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Benign Neoplasm of Large Intestine",
                                                 "A non-cancerous growth in the large intestine. These neoplasms can occur in different parts of the colon and rectum. While they are generally not life-threatening, they can cause symptoms such as abdominal pain, bleeding, and changes in bowel habits. Treatment may involve monitoring, medication, or surgical removal if necessary.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Diseases of Pancreas",
                                                 "A range of conditions affecting the pancreas, an organ involved in digestion and hormone production. These diseases can include inflammation, infections, tumors, and functional disorders. Symptoms may vary depending on the specific condition and can include abdominal pain, digestive issues, and changes in blood sugar levels.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Pancreatitis",
                                                 "A sudden inflammation of the pancreas that can cause severe abdominal pain, nausea, vomiting, and fever. It often results from gallstones or excessive alcohol consumption. Treatment usually involves hospitalization, pain management, and addressing the underlying cause.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Nephrology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Chronic Kidney Disease",
                                                 "A long-term condition characterized by the gradual loss of kidney function over time. It can result from various underlying causes, such as diabetes, high blood pressure, and glomerulonephritis. Symptoms may include fatigue, swelling, and changes in urination patterns. Treatment focuses on slowing disease progression and managing complications through lifestyle changes, medication, and sometimes dialysis or kidney transplant.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Kidney Failure",
                                                 "A sudden and severe reduction in kidney function, leading to the accumulation of waste products in the blood. It can be caused by factors such as severe dehydration, blood loss, or exposure to certain medications or toxins. Symptoms include decreased urine output, swelling, and fatigue. Treatment focuses on addressing the underlying cause and providing supportive care, such as dialysis, if necessary.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Renal Failure",
                                                 "A condition where the kidneys suddenly lose the ability to filter waste from the blood effectively. Causes include severe dehydration, injury, or exposure to toxins. Symptoms may involve reduced urine output, fluid retention, and fatigue. Management typically involves treating the underlying cause and may include interventions like dialysis.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Calculus of Kidney and Ureter",
                                                 "A condition where stones form in the kidneys and may travel down to the ureters, the tubes that connect the kidneys to the bladder. This can cause severe pain, urinary tract infections, and obstruction of urine flow. Treatment options include medication, hydration, and procedures to break up or remove the stones.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Calculus of Upper Urinary Tract",
                                                 "A condition involving the formation of stones in the upper part of the urinary system, including the kidneys and ureters. These stones can cause severe pain, urinary obstruction, and potential kidney damage. Symptoms include flank pain, hematuria, and frequent urination. Treatment options include medication, hydration, and procedures to break up or remove the stones.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Glomerulonephritis",
                                                 "A condition characterized by sudden inflammation of the glomeruli, the tiny filters in the kidneys. This inflammation can lead to symptoms such as blood in the urine, swelling in the body, high blood pressure, and reduced urine output. It is often caused by infections or autoimmune diseases. Treatment focuses on addressing the underlying cause and managing symptoms to prevent kidney damage.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Nephritic Syndrome",
                                                 "A syndrome caused by inflammation of the glomeruli, leading to a sudden onset of symptoms including hematuria (blood in the urine), proteinuria, hypertension, and edema (swelling). It can be caused by various conditions, including infections and autoimmune diseases. Treatment typically involves addressing the underlying cause and managing symptoms to prevent further kidney damage.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Congenital Anomalies of Urinary System",
                                                 "Structural abnormalities of the urinary system that are present at birth. These anomalies can affect the kidneys, ureters, bladder, or urethra and may lead to issues with urinary function, recurrent infections, or kidney damage. Treatment depends on the specific anomaly and its impact on the individual’s health.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Cystic Kidney Disease",
                                                 "A group of disorders where fluid-filled cysts form in the kidneys. These cysts can disrupt kidney function and lead to symptoms like high blood pressure, back pain, and urinary issues. Treatment varies depending on the specific type and severity of the disease, aiming to manage symptoms and prevent complications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Autosomal Dominant Polycystic Kidney Disease",
                                                 "A genetic disorder characterized by the growth of numerous cysts in the kidneys. These cysts can enlarge the kidneys and interfere with their function, potentially leading to kidney failure. Symptoms include hypertension, back or side pain, and blood in the urine. There is no cure, but treatment focuses on managing symptoms and preventing complications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Nephrotic Syndrome",
                                                 "A kidney disorder that causes the body to excrete too much protein in the urine. It is characterized by symptoms such as severe swelling (edema), especially around the eyes and in the ankles and feet, foamy urine, and weight gain due to fluid retention. Treatment focuses on addressing the underlying cause, managing symptoms, and preventing complications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Tubulo-Interstitial Nephritis",
                                                 "A sudden inflammation of the renal tubules and interstitial tissue of the kidneys, often caused by an allergic reaction to medications, infections, or autoimmune disorders. Symptoms may include fever, rash, flank pain, and changes in urine output. Treatment typically involves addressing the underlying cause and managing symptoms to prevent kidney damage.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Infections of Kidney",
                                                 "Conditions caused by bacterial or viral infections affecting the kidneys. These can include acute pyelonephritis, chronic pyelonephritis, and renal abscess. Symptoms may involve fever, flank pain, and changes in urine output. Treatment typically involves antibiotics or antiviral medications and supportive care.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Pyelonephritis",
                                                 "A severe infection of the kidneys, usually caused by bacteria ascending from the bladder. Symptoms include high fever, chills, flank pain, and urinary symptoms such as frequency and urgency. Treatment typically involves antibiotics and supportive care.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Hypertensive Chronic Kidney Disease",
                                                 "This condition refers to chronic kidney disease (CKD) caused by long-term high blood pressure (hypertension). Over time, the persistent high blood pressure damages the blood vessels in the kidneys, reducing their ability to function effectively. This can lead to kidney failure if not managed appropriately. Managing hypertension is crucial to slowing the progression of CKD.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Hypertensive Renal Disease",
                                                 "Hypertensive renal disease is a broader term that encompasses any kidney damage or disease caused by hypertension. It includes both acute and chronic conditions and may involve various forms of renal damage due to high blood pressure. The disease progression depends on how well the hypertension is managed and other individual health factors.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Fluid, Electrolyte and Acid-Base Balance",
                                                 "This category encompasses various disorders that affect fluid, electrolyte, and acid-base balance, which do not fall under other specific categories. These conditions can arise from multiple causes, leading to potentially severe health issues if untreated. Patients may experience a range of symptoms such as dehydration, electrolyte imbalances, and metabolic acidosis or alkalosis.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Specified Disorders of Fluid, Electrolyte or Acid-Base Balance",
                                                 "This category includes disorders involving abnormal levels of fluids, electrolytes, or acid-base balance that are not classified under other specific conditions. These may result from various underlying diseases or conditions and can lead to significant health complications if not properly managed. Symptoms may include fatigue, confusion, muscle weakness, and irregular heartbeats.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Obstetrics and Gynecology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Ovarian Dysfunction",
                                                 "Ovarian dysfunction refers to a range of disorders that affect the normal function of the ovaries. These disorders can result in irregular or absent menstrual cycles, hormonal imbalances, and infertility. Causes may include polycystic ovary syndrome (PCOS), premature ovarian failure, and other endocrine disorders. Symptoms often involve menstrual irregularities, weight gain, and changes in hair growth. Effective management typically requires a multidisciplinary approach, including hormonal therapies and lifestyle modifications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Endometriosis",
                                                 "Endometriosis is a painful disorder in which tissue similar to the lining inside the uterus, called the endometrium, begins to grow outside the uterus. This abnormal growth can cause severe pain, particularly during menstrual periods, and may lead to fertility problems. Common symptoms include pelvic pain, menstrual irregularities, and pain during intercourse or bowel movements. Treatment options vary and may include pain medications, hormone therapy, and surgery.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Leiomyoma of Uterus",
                                                 "Leiomyoma of the uterus, commonly known as uterine fibroids, are non-cancerous growths that develop from the muscular tissue of the uterus. These fibroids can vary in size and number, and while they are often asymptomatic, they can sometimes cause symptoms like heavy menstrual bleeding, pelvic pain, and pressure on the bladder or bowel. Treatment options depend on the severity of symptoms and may include medication, non-invasive procedures, or surgery.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Benign Smooth Muscle or Skeletal Muscle Tumour",
                                                 "This category includes benign tumours originating from smooth or skeletal muscle tissue. These tumours are non-cancerous and typically grow slowly. Examples include leiomyomas, such as uterine fibroids, which develop from the smooth muscle cells of the uterus, and rhabdomyomas, which arise from skeletal muscle cells. Symptoms and treatment depend on the tumour's location and size, and may range from observation to surgical removal.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Noninflammatory Disorders of Cervix",
                                                 "This category includes a range of conditions that affect the cervix without causing inflammation. These disorders can involve structural abnormalities, cervical polyps, and various types of dysplasia. They can lead to symptoms such as abnormal bleeding, pelvic pain, and fertility issues. Diagnosis often involves a pelvic exam and imaging studies, while treatment depends on the specific condition and may include medication, surgical interventions, or lifestyle modifications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Dysplasia of Cervix Uteri",
                                                 "Dysplasia of the cervix uteri refers to the presence of precancerous cells on the cervix's surface. These abnormal cells are classified into mild, moderate, or severe dysplasia based on the extent of cell changes. Early detection through routine Pap smears is crucial for preventing progression to cervical cancer. Treatment options include watchful waiting for mild cases, cryotherapy, laser therapy, or surgical procedures for more severe dysplasia.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acquired Abnormalities of Cervix Uteri",
                                                 "Acquired abnormalities of the cervix uteri encompass a variety of conditions that develop due to infections, injuries, or other external factors. These may include cervical stenosis, cervical incompetence, and lesions such as low-grade squamous intraepithelial lesions (LSIL). Symptoms can vary widely but often involve irregular bleeding, pain, or complications during pregnancy. Management strategies depend on the specific abnormality and may range from conservative monitoring to surgical intervention.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Symptoms Involving Urinary System",
                                                 "This category includes a range of symptoms that affect the urinary system, which may indicate underlying conditions. Symptoms can include dysuria (painful urination), hematuria (blood in urine), polyuria (excessive urination), and urinary frequency or urgency. Accurate diagnosis of these symptoms often requires a combination of patient history, physical examination, and diagnostic tests to determine the root cause.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Unspecified Urinary Incontinence",
                                                 "Unspecified urinary incontinence refers to involuntary leakage of urine without a clear underlying cause. This condition can significantly impact the quality of life and may result from a variety of factors including aging, nerve damage, or muscular issues. Diagnosis usually involves urodynamic testing, and treatment options may include lifestyle modifications, pelvic floor exercises, medication, or surgery.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Abnormal Micturition",
                                                 "Abnormal micturition encompasses any deviations from normal urination patterns. This may include symptoms like urinary retention, incontinence, nocturia (frequent urination at night), and dysuria. The underlying causes can vary widely, including infections, neurological disorders, or structural abnormalities. Treatment depends on the specific cause and may involve medications, lifestyle changes, or surgical interventions.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Ophthalmology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Glaucoma",
                                                 "A group of eye conditions that damage the optic nerve, often caused by abnormally high pressure in the eye. It can lead to vision loss if not treated.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Senile Cataract",
                                                 "Senile cataract, also known as age-related cataract, is a common eye condition characterized by the gradual, progressive clouding and thickening of the lens of the eye. This clouding can lead to blurred vision, difficulty seeing at night, and increased sensitivity to glare. It is the leading cause of vision loss in older adults but can be treated effectively with surgical intervention to restore vision.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Cataract",
                                                 "A cataract is a clouding of the lens in the eye that affects vision. Cataracts are very common in older adults and can develop in one or both eyes. Symptoms include blurry vision, faded colors, difficulty with glare, and seeing halos around lights. Treatment usually involves surgical removal of the cataract and replacement with an artificial lens.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Refraction and Accommodation",
                                                 "Conditions that result in blurred vision due to the eye's inability to properly focus light on the retina. This includes myopia (nearsightedness), hyperopia (farsightedness), and astigmatism.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Refraction",
                                                 "Disorders of refraction involve the eye's inability to properly focus light on the retina, resulting in blurred vision. Common types include myopia (nearsightedness), hyperopia (farsightedness), and astigmatism. These conditions can often be corrected with glasses, contact lenses, or refractive surgery.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Accommodation",
                                                 "Disorders of accommodation refer to the eye's inability to change its focus from distant to near objects, leading to vision problems. This can include presbyopia, a condition often associated with aging where the lens loses its flexibility. Treatment options may involve corrective lenses or surgery.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Retinal Disorders",
                                                 "This category includes various disorders affecting the retina that do not fall under specific classifications. These conditions can lead to vision impairment or loss and may include symptoms such as floaters, flashes of light, and peripheral vision loss. Diagnosis often involves a comprehensive eye exam, and treatment depends on the specific disorder and may range from medication to surgical interventions.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Certain Specified Retinal Disorders",
                                                 "This category includes specific retinal disorders that are identified and classified separately from other retinal conditions. These disorders can vary widely in their presentation and severity, and may require specialized diagnostic and treatment approaches to manage effectively.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Conjunctiva",
                                                 "This category includes various conditions that affect the conjunctiva, the clear tissue covering the white part of the eye and the inside of the eyelids. Disorders can range from infections (such as conjunctivitis), allergic reactions, to inflammatory conditions. Symptoms may include redness, itching, discharge, and discomfort. Diagnosis is usually based on clinical examination, and treatment varies depending on the underlying cause, including medications such as antibiotics, antihistamines, or corticosteroids.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Conjunctivitis",
                                                 "An inflammation or infection of the conjunctiva, the clear tissue covering the white part of the eye and the inside of the eyelids. It can be caused by infections, allergies, or irritants.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Psychiatry Department ]
        this.Diseases.Add(DiseasesFactory.Create("Depressive Episode",
                                                 "A depressive episode refers to a period characterized by a persistently low mood or loss of interest in most activities, lasting for at least two weeks. Symptoms may include feelings of sadness, hopelessness, fatigue, changes in appetite or sleep patterns, difficulty concentrating, and sometimes thoughts of self-harm. Treatment typically involves a combination of medication, such as antidepressants, and psychotherapy.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Single Episode Depressive Disorder",
                                                 "Single episode depressive disorder is diagnosed when an individual experiences one major depressive episode that significantly impacts daily functioning. This condition involves symptoms such as persistent sadness, loss of interest in activities, changes in weight or sleep patterns, fatigue, feelings of worthlessness, and impaired concentration. Management often includes a mix of psychotherapy and pharmacological treatments.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Anxiety, Dissociative and Somatoform Disorders",
                                                 "This category encompasses a range of disorders characterized by anxiety, dissociation, and somatic symptoms. Disorders include generalized anxiety disorder, panic disorder, phobic disorders, obsessive-compulsive disorder, and somatoform disorders. These conditions often involve significant distress and impairment in functioning.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Generalised Anxiety Disorder",
                                                 "A mental health condition characterized by persistent and excessive worry about various aspects of daily life. Symptoms can include restlessness, fatigue, difficulty concentrating, irritability, muscle tension, and sleep disturbances. Treatment may involve therapy, medication, or a combination of both.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Schizophrenic Disorders",
                                                 "Schizophrenic disorders are severe mental illnesses that affect how a person thinks, feels, and behaves. Symptoms may include delusions, hallucinations, disorganized thinking, and abnormal behavior. Treatment usually involves antipsychotic medications, therapy, and support to help manage symptoms and improve quality of life.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Schizophrenia",
                                                 "Schizophrenia is a chronic and severe mental disorder that affects how a person thinks, feels, and behaves. People with schizophrenia may seem like they have lost touch with reality. Symptoms can include delusions, hallucinations, disorganized thinking, and significant social or occupational dysfunction. Treatment involves a combination of antipsychotic medications, psychotherapy, and social support.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Episodic Mood Disorders",
                                                 "Episodic mood disorders include various conditions characterized by periods of depression, mania, or a combination of both. These disorders encompass major depressive disorder, bipolar disorder, and other mood disturbances that occur in episodes. Treatment typically involves medication, psychotherapy, and lifestyle changes to manage symptoms and improve quality of life.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Bipolar Affective Disorder",
                                                 "Bipolar affective disorder, also known as bipolar disorder, is characterized by episodes of mania and depression. Individuals with this disorder experience extreme mood swings that can impact daily functioning. Management includes mood stabilizers, psychotherapy, and lifestyle modifications to stabilize mood and improve quality of life.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Bipolar Type I Disorder",
                                                 "Bipolar Type I Disorder is a mental health condition marked by one or more manic episodes that last at least seven days, or by manic symptoms that are so severe that immediate hospital care is needed. Depressive episodes often occur as well, typically lasting at least two weeks. Treatment includes medications such as mood stabilizers, antipsychotics, and psychotherapy.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Bipolar Type II Disorder",
                                                 "Bipolar Type II Disorder involves a pattern of depressive episodes and hypomanic episodes, but not the full-blown manic episodes that are typical of Bipolar Type I Disorder. Hypomanic episodes involve elevated mood, increased activity or energy, but without the severe impact on daily functioning seen in manic episodes. Treatment involves mood stabilizers, antidepressants, and psychotherapy.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [ Pulmonology Department ]
        this.Diseases.Add(DiseasesFactory.Create("Asthma",
                                                 "A chronic condition that causes inflammation and narrowing of the airways, leading to difficulty breathing, wheezing, and coughing. Management often includes inhalers, medication, and avoiding triggers.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Chronic Airway Obstruction, Not Elsewhere Classified",
                                                 "This condition refers to chronic obstruction of the airways that does not fit into other specific categories of lung diseases. It results in persistent breathing difficulties due to airflow limitation. Management typically involves bronchodilators, anti-inflammatory medications, and supportive care to improve respiratory function.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Chronic Obstructive Pulmonary Disease",
                                                 "This category includes various forms of chronic obstructive pulmonary disease that are not classified under a specific subtype. These conditions cause long-term breathing difficulties due to airflow obstruction and lung damage. Symptoms and treatment are similar to those of COPD, involving medications, lifestyle modifications, and supportive therapies.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Chronic Obstructive Pulmonary Disease",
                                                 "Chronic Obstructive Pulmonary Disease is a group of progressive lung diseases that cause airflow blockage and breathing-related problems. It includes conditions such as emphysema and chronic bronchitis. Symptoms often include shortness of breath, wheezing, chest tightness, and chronic cough. Management involves medications, lifestyle changes, oxygen therapy, and pulmonary rehabilitation.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Pneumonia, Organism Unspecified",
                                                 "Pneumonia, organism unspecified, refers to an infection of the lungs where the causative organism is not identified. This condition leads to inflammation of the air sacs in one or both lungs, which may fill with fluid or pus, causing symptoms such as cough, fever, chills, and difficulty breathing. Treatment typically involves antibiotics and supportive care to manage symptoms and improve lung function.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Pneumonia",
                                                 "An infection that inflames the air sacs in one or both lungs, which may fill with fluid or pus, causing cough, fever, and difficulty breathing. Treatment depends on the cause and may include antibiotics, antivirals, or supportive care.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Pulmonary Tuberculosis",
                                                 "Pulmonary tuberculosis is a bacterial infection caused by Mycobacterium tuberculosis that primarily affects the lungs. It is spread through airborne droplets when an infected person coughs or sneezes. Symptoms include persistent cough, chest pain, coughing up blood, night sweats, and weight loss. Treatment involves a long course of antibiotics.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Respiratory Tuberculosis, Bacteriologically and Histologically Confirmed",
                                                 "This form of tuberculosis is confirmed through bacteriological tests (such as sputum culture) and histological examination (such as biopsy). It affects the respiratory system, leading to symptoms like prolonged cough, chest pain, and hemoptysis. Treatment requires a prolonged regimen of antibiotics to eradicate the infection.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Tuberculosis of the Respiratory System",
                                                 "Tuberculosis of the respiratory system includes infections caused by Mycobacterium tuberculosis that affect the lungs and other parts of the respiratory tract. It can lead to symptoms such as persistent cough, chest pain, and difficulty breathing. Diagnosis is often confirmed through bacteriological and histological tests, and treatment involves a prolonged course of antibiotics.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Trachea, Bronchus, and Lung",
                                                 "This condition refers to a cancerous growth that can develop in the trachea, bronchus, or lungs. It is characterized by uncontrolled cell growth that can invade nearby tissues and spread to other parts of the body. Symptoms may include persistent cough, chest pain, shortness of breath, and unexplained weight loss. Treatment often involves a combination of surgery, radiation therapy, chemotherapy, and targeted therapies.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Bronchus and Lung",
                                                 "A type of cancer affecting the bronchus and lung, leading to symptoms like persistent cough, chest pain, and difficulty breathing.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Bronchus or Lung",
                                                 "Cancerous growths originating in the bronchus or lung, characterized by uncontrolled cell growth within these respiratory structures.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Chronic Bronchitis",
                                                 "Chronic bronchitis is a long-term inflammation of the bronchial tubes, leading to persistent coughing and mucus production. It is often caused by prolonged exposure to irritants like tobacco smoke or air pollution. Symptoms include a productive cough that lasts for at least three months, shortness of breath, and frequent respiratory infections. Treatment focuses on relieving symptoms and preventing complications, often involving medications, pulmonary rehabilitation, and lifestyle changes.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Bronchitis, Not Specified as Acute or Chronic",
                                                 "Bronchitis, not specified as acute or chronic, refers to inflammation of the bronchial tubes, which carry air to and from the lungs. This condition can cause symptoms such as coughing, mucus production, wheezing, and shortness of breath. Treatment typically includes rest, fluids, and medications to alleviate symptoms and clear the airways.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Bronchitis",
                                                 "Bronchitis is the inflammation of the bronchial tubes, which can be either acute or chronic. Acute bronchitis is usually caused by viral infections and lasts for a short period, while chronic bronchitis is often a result of long-term irritation, typically from smoking, and can persist for months or years. Symptoms include coughing, mucus production, chest discomfort, and fatigue. Treatment involves rest, fluids, medications, and avoiding irritants.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Acute Bronchitis",
                                                 "Acute bronchitis is a short-term inflammation of the bronchial tubes, typically caused by viral infections such as the common cold or influenza. Symptoms include coughing, production of mucus, wheezing, chest tightness, and fever. The condition usually resolves on its own within a few weeks, and treatment focuses on relieving symptoms through rest, fluids, and over-the-counter medications.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other and Unspecified Disorders of Metabolism",
                                                 "This category includes various metabolic disorders that are not classified under specific conditions. These disorders can affect the body's ability to process and convert food into energy, leading to a wide range of symptoms such as fatigue, weight changes, and organ dysfunction. Diagnosis and management depend on the specific metabolic disorder and may involve dietary modifications, medications, and regular monitoring.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Cystic Fibrosis",
                                                 "Cystic fibrosis is a genetic disorder that affects the respiratory and digestive systems. It leads to the production of thick, sticky mucus that can clog the airways and trap bacteria, causing frequent lung infections. It also affects the pancreas, preventing digestive enzymes from reaching the intestines. Symptoms include persistent coughing, frequent lung infections, and difficulty gaining weight. Treatment focuses on managing symptoms and may include medications, chest physiotherapy, and dietary adjustments.",
                                                 Domain.CodeStatus.Active));
        #endregion

        #region [Urology Department]
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Urethra and Urinary Tract",
                                                 "A group of conditions affecting the urethra and urinary tract that are not classified under specific, well-known categories. These disorders can cause a variety of symptoms, including pain, irritation, and urinary difficulties.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Urinary System",
                                                 "A collection of conditions affecting the urinary system, including the kidneys, ureters, bladder, and urethra, that do not fall under more specific classifications. These disorders may cause symptoms such as pain, changes in urination, and kidney function abnormalities.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Urinary Tract Infection, Site Not Specified",
                                                 "An infection in the urinary tract where the specific site of infection is not identified. Symptoms can include a strong urge to urinate, a burning sensation when urinating, and cloudy or strong-smelling urine.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Hyperplasia of Prostate",
                                                 "A non-cancerous enlargement of the prostate gland, common in older men. It can lead to urinary symptoms such as difficulty starting urination, weak urine flow, frequent urination, and the feeling of incomplete bladder emptying.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Prostate",
                                                 "A type of cancer that occurs in the prostate gland, which is a small gland in men that produces seminal fluid. This cancer can cause difficulty in urination, blood in urine, and pelvic discomfort. Early detection and treatment are crucial for better outcomes.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Prostate",
                                                 "A category encompassing various forms of cancer that develop in the prostate gland. These cancers can lead to urinary symptoms, pelvic pain, and systemic issues if they spread beyond the prostate. Early diagnosis and comprehensive treatment are vital for managing these conditions.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasm of Bladder",
                                                 "A type of cancer that originates in the bladder's lining cells. It can cause symptoms such as blood in the urine, frequent urination, and pain during urination. Early detection is crucial for effective treatment and better prognosis.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Malignant Neoplasms of Bladder",
                                                 "A type of cancer that begins in the cells of the bladder. This condition is characterized by abnormal cell growth in the bladder lining, which can lead to symptoms such as blood in the urine, frequent urination, and pain during urination. Early detection and treatment are crucial for better outcomes.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Cystitis",
                                                 "An inflammation of the bladder, usually caused by a bacterial infection. Symptoms include a strong, persistent urge to urinate, a burning sensation during urination, cloudy or strong-smelling urine, and pelvic discomfort. Treatment often involves antibiotics and increased fluid intake.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Symptoms Involving Urinary System",
                                                 "A range of symptoms indicating issues within the urinary system, such as dysuria (painful urination), polyuria (frequent urination), nocturia (frequent urination at night), and hematuria (blood in the urine). These symptoms can indicate various underlying conditions affecting the urinary tract.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Other Disorders of Urinary System",
                                                 "A collection of conditions affecting the urinary system that do not fall under more specific categories. These disorders can involve the kidneys, ureters, bladder, and urethra, leading to symptoms such as pain, changes in urination, and kidney function abnormalities.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Abnormal Micturition",
                                                 "A range of conditions causing abnormal urination patterns, such as difficulty starting urination, weak urine flow, frequent urination, or incomplete bladder emptying. These issues can result from various underlying medical conditions affecting the urinary system.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Hydronephrosis",
                                                 "A condition characterized by the swelling of one or both kidneys due to the build-up of urine. This occurs when there is an obstruction in the urinary tract or a condition that prevents proper drainage of urine from the kidney to the bladder.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Obstructive and Reflux Uropathy",
                                                 "A group of conditions where urinary flow is blocked (obstructive) or where urine flows backward from the bladder into the kidneys (reflux). These conditions can lead to kidney damage, infection, and other complications due to the abnormal flow of urine.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Obstructive or Reflux Nephropathy",
                                                 "A type of kidney damage caused by either an obstruction in the urinary tract or the backward flow of urine (reflux) from the bladder into the ureters or kidneys. This condition can lead to chronic kidney disease if not properly managed.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Urethritis Not Sexually Transmitted and Urethral Syndrome",
                                                 "A condition characterized by inflammation of the urethra that is not caused by a sexually transmitted infection. Symptoms may include pain or discomfort during urination, frequent urge to urinate, and urethral discharge. Urethral syndrome refers to a set of symptoms associated with urethritis without evidence of infection.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Urethritis and Urethral Syndrome",
                                                 "An inflammatory condition of the urethra, which can be caused by infection, irritants, or unknown factors. Symptoms typically include painful urination, frequent urge to urinate, and discomfort in the urinary tract. Urethral syndrome describes similar symptoms without a confirmed infection.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Disorders of Penis",
                                                 "A range of conditions affecting the penis, including congenital abnormalities, infections, inflammations, and other issues that can impact sexual function, urination, and overall health.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Sexual Dysfunction, Not Caused by Organic Disorder or Disease",
                                                 "A category of sexual problems that arise from psychological, emotional, or behavioral factors rather than physical or medical conditions. These dysfunctions can include issues with desire, arousal, orgasm, or pain during sexual activity.",
                                                 Domain.CodeStatus.Active));
        this.Diseases.Add(DiseasesFactory.Create("Sexual Arousal Dysfunctions",
                                                 "A group of conditions characterized by difficulties in becoming sexually aroused or maintaining arousal during sexual activity. These dysfunctions can be caused by psychological, emotional, or physical factors and can significantly impact sexual satisfaction and relationships.",
                                                 Domain.CodeStatus.Active));

        #endregion
    }

    private void LoadICDVersions()
    {
        this.ICDVersions.Add(ICDVersionFactory.Create("ICD-9"));
        this.ICDVersions.Add(ICDVersionFactory.Create("ICD-10"));
        this.ICDVersions.Add(ICDVersionFactory.Create("ICD-11"));
    }

    private void LoadICDCodes()
    {
        #region [ Infectious Disease Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Late Syphilis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "A52", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "A52.7", "Other Symptomatic Late Syphilis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "1A62", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "1A62.2", "Symptomatic Late Syphilis of other sites");
        #endregion
         
        #region [ Cardiology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Lipoprotein Metabolism and Other Lipidaemias"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E78", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E78.2", "Mixed hyperlipidaemia");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Hyperlipoproteinaemia"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5C80", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5C80.2", "Mixed hyperlipidaemia");
        #endregion

        #region [ Hematology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Anaemias"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "D64", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "D64.3", "Other sideroblastic anaemias");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Sideroblastic Anaemia"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "3A72", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "3A72.0Y", "Other specified congenital sideroblastic anaemias");
        #endregion

        #region [ Pathology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Findings of Drugs and Other Substances, Not Normally Found in Blood"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "R78", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "R78.9", "Finding of unspecified substance, not normally found in blood");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Specified Abnormal Findings of Blood Chemistry"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "R79", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "R79.8", "Other specified abnormal findings of blood chemistry");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Certain Clinical Findings of Blood Chemistry"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "MA18", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MA18.Y", "Other specified abnormal findings of blood chemistry");
        #endregion

        #region [ Oncology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Breast"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C50", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C50.9", "Breast, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Breast, Unspecified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C6Z", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Liver and Intrahepatic Bile Ducts"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "155", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "155.1", "Malignant neoplasm of intrahepatic bile ducts")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C22", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C22.9", "Liver, Unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Liver or Intrahepatic Bile Ducts"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C12", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C12.0Z", "Malignant neoplasm of liver, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Ovary"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C56", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C73", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C73.Z", "Malignant Neoplasms of Ovary, Unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Nonspecific Abnormal Histological and Immunological Findings"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "795", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "795.8", "Other and nonspecific abnormal cytological, histological, immunological and DNA test findings : Abnormal tumor markers")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "795.89", "Other Abnormal Tumor Markers");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Abnormal Tumor Markers"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "R97", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "R97.8", "Other Abnormal Tumor Markers");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Colon"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C18", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C18.9", "Colon, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2B90", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2B90.Z", "Malignant neoplasms of colon, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Rectum"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C20", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2B92", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2B92.Z", "Malignant neoplasms of rectum, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Other and Ill-Defined Digestive Organs"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C26", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C26.9", "Ill-defined sites within the digestive system");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Other or Ill-Defined Digestive Organs"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C11", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C11.2", "Other specified malignant neoplasms of other or ill-defined digestive organs");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Personal History of Malignant Neoplasm"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "V10", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "V10.4", "Personal history of malignant neoplasm of genital organs")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "V10.43", "Personal history of malignant neoplasm of ovary")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "Z85", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "Z85.3", "Personal history of malignant neoplasm of breast")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "Z85.4", "Personal history of malignant neoplasm of genital organs")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "Z85.43", "Personal history of malignant neoplasm of ovary")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "QC40", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "QC40.3", "Personal history of malignant neoplasm of breast")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "QC40.3", "Personal history of malignant neoplasm of genital organs");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Cervix Uteri"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "180", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "180.0", "Malignant neoplasm of endocervix")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C53", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C53.0", "Endocervix")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C53.9", "Cervix uteri, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Cervix Uteri"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C77", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C77.Z", "Malignant neoplasms of cervix uteri, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Body of Uterus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "182", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "182.0", "Malignant neoplasm of corpus uteri, except isthmus");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Corpus Uteri"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C54", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C54.9", "Corpus uteri, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Corpus Uteri"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C76", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C76.Z", "Malignant neoplasms of corpus uteri, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Ovary and Other Uterine Adnexa"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "183", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "183.2", "Malignant neoplasm of fallopian tube")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "183.9", "Malignant neoplasm of uterine adnexa, unspecified site");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Other and Unspecified Female Genital Organs"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "184", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "184.8", "Malignant neoplasm of other specified sites of female genital organs")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C57", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C57.0", "Fallopian tube")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C57.4", "Uterine adnexa, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C57.7", "Other specified female genital organs");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Uterine Ligament, Parametrium, or Uterine Adnexa"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C72", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C72.Z", "Malignant neoplasms of uterine ligament, parametrium, or uterine adnexa, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Secondary Malignant Neoplasm of Other Specified Sites"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "198", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "198.89", "Secondary malignant neoplasm of other specified sites");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Secondary Malignant Neoplasm of Other and Unspecified Sites"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C79", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C79.6", "Secondary malignant neoplasm of ovary");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm Metastasis in Female Reproductive System"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2E05", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2E05.0", "Malignant neoplasm metastasis in ovary");
        #endregion

        #region [ Dermatology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Atopic Dermatitis and Related Conditions"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "691", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "691.8", "Other atopic dermatitis and related conditions");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Atopic Dermatitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "L20", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "L20.9", "Atopic dermatitis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Atopic Eczema"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "EA80", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "EA80.Z", "Atopic eczema, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diseases of Hair and Hair Follicles"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "704", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "704.01", "Alopecia areata");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Alopecia Areata"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "L63", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "L63.9", "Alopecia areata, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "EA80", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "EA80.Z", "Atopic eczema, unspecified");
        #endregion

        #region [ Endocrinology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diabetes Mellitus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "250", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "250.01", "Diabetes mellitus without mention of complication, type I [juvenile type], not stated as uncontrolled")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "250.02", "Diabetes mellitus without mention of complication, type II or unspecified type, uncontrolled");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Type 1 Diabetes Mellitus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E10", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A10", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Type 2 Diabetes Mellitus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E11", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A11", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acquired Hypothyroidism"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "244", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "244.9", "Unspecified acquired hypothyroidism");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Hypothyroidism"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E03", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E03.9", "Hypothyroidism, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Hypothyroidism"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A00", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A00.2Z", "Acquired hypothyroidism, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Thyrotoxicosis with or without Goiter"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "242", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "242.9", "Thyrotoxicosis without mention of goiter or other cause");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Thyrotoxicosis [Hyperthyroidism]"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E05", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E05.9", "Thyrotoxicosis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Thyrotoxicosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A02", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A02.Z", "Thyrotoxicosis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Adrenal Glands"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "255", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "255.4", "Corticoadrenal insufficiency");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Adrenal Gland"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E27", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E27.1", "Primary adrenocortical insufficiency")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E27.9", "Disorder of adrenal gland, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Adrenocortical Insufficiency"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A74", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A74.Z", "Adrenocortical insufficiency, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A74.0", "Acquired adrenocortical insufficiency");
        #endregion

        #region [ Rheumatology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Bone and Cartilage"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "733", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "733.0", "Osteoporosis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "733.01", "Senile osteoporosis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Osteoporosis Without Pathological Fracture"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M81", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M81.0", "Postmenopausal osteoporosis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Low Bone Mass Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FB83", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FB83.1", "Osteoporosis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FB83.11", "Postmenopausal osteoporosis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Rheumatoid Arthritis and Other Inflammatory Polyarthropathies"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "714", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "714.0", "Rheumatoid arthritis ");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Rheumatoid Arthritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M06", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M06.9", "Rheumatoid arthritis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Rheumatoid Arthritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA20", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA20.Z", "Rheumatoid arthritis, serology unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Osteoarthrosis and Allied Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "715", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "715.9", "Osteoarthrosis unspecified whether generalized or localized");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Arthrosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M19", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M19.9", "Arthrosis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Osteoarthritis of Knee"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA01", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA01.Z", "Osteoarthritis of knee, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Psoriasis and Similar Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "696", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "696.0", "Psoriatic arthropathy");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Psoriasis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "L40", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "L40.5", "Arthropathic psoriasis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "L40.9", "Psoriasis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Psoriatic arthritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA21", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA21.Z", "Psoriatic arthritis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diffuse Diseases of Connective Tissue"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "710", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "710.0", "Systemic lupus erythematosus")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "710.1", "Systemic sclerosis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "710.2", "Sicca syndrome");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Systemic Lupus Erythematosus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M32", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M32.9", "Systemic lupus erythematosus, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Lupus Erythematosus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "4A40", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "4A40.0", "Systemic lupus erythematosus");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Ankylosing Spondylitis and Other Inflammatory Spondylopathies"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "720", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "720.0", "Ankylosing spondylitis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Ankylosing Spondylitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M45", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Inflammatory Spondyloarthritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA92", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA92.0", "Axial spondyloarthritis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA92.0Z", "Axial spondyloarthritis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Gout"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "274", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M10", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA25", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Soft Tissues"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "729", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "729.1", "Myalgia and myositis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Soft Tissue Disorders, Not Elsewhere Classified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M79", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M79.7", "Fibromyalgia");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic Pain"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MG30", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MG30.0", "Chronic primary pain")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MG30.01", "Chronic widespread pain");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Systemic Involvement of Connective Tissue"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M35", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M35.0", "Sicca syndrome [Sjögren]")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M35.3", "Polymyalgia rheumatica");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Overlap or Undifferentiated Non-Organ Specific Systemic Autoimmune Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "4A43", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "4A43.2", "Sjögren syndrome");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Systemic Sclerosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M34", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "4A42", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Polymyalgia Rheumatica"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "725", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "FA22", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Arteries and Arterioles"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "447", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "447.6", "Arteritis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Necrotizing Vasculopathies"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M31", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "M31.9", "Necrotizing vasculopathy, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Vasculitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "4A44", "");
        #endregion

        #region [ Gastroenterology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic Viral Hepatitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "B18", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "B18.2", "Chronic viral hepatitis C")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "1E51", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "1E51.1", "Chronic hepatitis C");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Mineral Metabolism"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E83", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E83.1", "Disorders of iron metabolism");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Mineral Absorption or Transport"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5C64", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5C64.1", "Disorders of iron metabolism");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Alcoholic Liver Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K70", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K70.3", "Alcoholic cirrhosis of liver")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB94", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB94.3", "Alcoholic cirrhosis of liver without hepatitis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic Hepatitis, not elsewhere classified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K73", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K73.9", "Chronic hepatitis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Certain Specified Inflammatory Liver Diseases"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB97", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB97.2", "Chronic hepatitis, not elsewhere classified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diseases of Esophagus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "530", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "530.8", "Other specified disorders of esophagus")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "530.81", "Esophageal reflux");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Gastro-Oesophageal Reflux Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K21", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K21.0", "Gastro-oesophageal reflux disease with oesophagitis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K21.9", "Gastro-oesophageal reflux disease without oesophagitis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DA22", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DA22.0", "Non-erosive gastro-oesophageal reflux disease")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DA22.Z", "Gastro-oesophageal reflux disease, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Functional Digestive Disorders, Not Elsewhere Classified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "564", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "564.1", "Irritable bowel syndrome");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Irritable Bowel Syndrome"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K58", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K58.8", "Other and unspecified irritable bowel syndrome");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Irritable Bowel Syndrome or Certain Specified Functional Bowel Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD91", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD91.0", "Irritable bowel syndrome")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD91.0Z", "Irritable bowel syndrome, type unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Regional Enteritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "555", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "555.9", "Regional enteritis of unspecified site");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Crohn Disease [Regional Enteritis]"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K50", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K50.9", "Crohn disease, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Crohn Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD70", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD70.Z", "Crohn disease, unspecified site");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Ulcerative Colitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "556", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "556.9", "Ulcerative colitis, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K51", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K51.9", "Ulcerative colitis, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD71", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD71.Z", "Ulcerative colitis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Intestinal Malabsorption"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "579", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "579.0", "Celiac disease")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K90", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K90.0", "Coeliac disease");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Coeliac Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DA95", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Cholelithiasis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "574", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "574.20", "Calculus of gallbladder without mention of cholecystitis, without mention of obstruction")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K80", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K80.2", "Calculus of gallbladder without cholecystitis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DC11", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DC11.3", "Calculus of gallbladder or cystic duct without cholecystitis or cholangitis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diverticula of Intestine"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "562", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "562.00", "Diverticulosis of small intestine (without mention of hemorrhage)")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "562.11", "Diverticulitis of colon (without mention of hemorrhage)");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diverticular Disease of Intestine"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K57", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K57.2", "Diverticular disease of large intestine with perforation and abscess")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K57.9", "Diverticular disease of intestine, part unspecified, without perforation or abscess");
        //
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diverticulosis of Unspecified part of Intestine without Haemorrhage"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD01", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DD01.1", "Diverticulosis of unspecified part of intestine without haemorrhage");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Functional Digestive Disorders, Not Elsewhere Classified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "564", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "564.0", "Constipation");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Functional Intestinal Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K59", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K59.0", "Constipation");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Change in Bowel Habit"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "ME05", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "ME05.0", "Constipation");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Haemorrhoids"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "455", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "455.6", "Unspecified hemorrhoids without mention of complication")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB60", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB60.Z", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Haemorrhoids and Perianal Venous Thrombosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K64", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K64.9", "Haemorrhoids, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Benign Neoplasm of Other Parts of Digestive System"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "211", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "211.3", "Benign neoplasm of colon");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Diseases of Intestine"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K63", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K63.5", "Polyp of colon");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Benign Neoplasm of Large Intestine"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB35", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DB35.0", "Hyperplastic polyp of large intestine");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Diseases of Pancreas"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "577", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "577.0", "Acute pancreatitis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Pancreatitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K85", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "K85.9", "Acute pancreatitis, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DC31", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "DC31.Z", "Acute pancreatitis, unspecified");
        #endregion

        #region [ Nephrology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic Kidney Disease"))!
                    .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "585", "")
                    .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "585.9", "Chronic kidney disease, unspecified")
                    .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N18", "")
                    .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N18.9", "Chronic kidney disease, unspecified")
                    .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB61", "")
                    .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB61.Z", "Chronic kidney disease, stage unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Kidney Failure"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "584", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "584.9", "Acute kidney failure, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB60", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB60.Z", "Acute kidney failure, stage unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Renal Failure"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N17", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N17.9", "Acute renal failure, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Calculus of Kidney and Ureter"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "592", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "592.0", "Calculus of kidney")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N20", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N20.0", "Calculus of kidney");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Calculus of Upper Urinary Tract"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB70", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB70.0", "Calculus of kidney");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Glomerulonephritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "580", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Nephritic Syndrome"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N00", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N00.4", "Diffuse endocapillary proliferative glomerulonephritis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Congenital Anomalies of Urinary System"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "753", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "753.12", "Polycystic kidney, unspecified type");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Cystic Kidney Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "Q61", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "Q61.2", "Polycystic kidney, autosomal dominant");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Autosomal Dominant Polycystic Kidney Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB81", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Nephrotic Syndrome"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "581", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N04", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB41", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Tubulo-Interstitial Nephritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N10", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB50", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Infections of kidney"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "590", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "590.1", "Acute pyelonephritis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Pyelonephritis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB51", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Hypertensive Chronic Kidney Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "403", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "403.9", "Hypertensive renal disease, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Hypertensive Renal Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "I12", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "BA02", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Fluid, Electrolyte and Acid-Base Balance"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E87", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E87.8", "Other disorders of electrolyte and fluid balance, not elsewhere classified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Specified Disorders of Fluid, Electrolyte or Acid-Base Balance"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5C7Y", "");
        #endregion

        #region [ Obstetrics and Gynecology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Ovarian Dysfunction"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "256", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "256.4", "Polycystic ovaries")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E28", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E28.2", "Polycystic ovarian syndrome")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A80", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "5A80.1", "Polycystic ovary syndrome");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Endometriosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "617", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N80", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GA10", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Leiomyoma of Uterus"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "218", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "218.9", "Leiomyoma of uterus, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "D25", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "D25.9", "Leiomyoma of uterus, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Benign Smooth Muscle or Skeletal Muscle Tumour"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2E86", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2E86.0", "Leiomyoma of uterus");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Noninflammatory Disorders of Cervix"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "622", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "622.10", "Dysplasia of cervix, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "622.11", "Mild dysplasia of cervix")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "622.12", "Moderate dysplasia of cervix");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Dysplasia of Cervix Uteri"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N87", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N87.0", "Mild cervical dysplasia")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N87.1", "Moderate cervical dysplasia")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N87.9", "Dysplasia of cervix uteri, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acquired Abnormalities of Cervix Uteri"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2D36", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2D36.7", "Low grade squamous intraepithelial lesion of cervix uteri");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Symptoms Involving Urinary System"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "788", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "788.3", "Urinary incontinence");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Unspecified Urinary Incontinence"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N32", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Abnormal Micturition"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MF50", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MF50.2", "Urinary incontinence");
        #endregion

        #region [ Ophthalmology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Glaucoma"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H40", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H40.9", "Glaucoma, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9C61", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9C61.Z", "Glaucoma, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Senile Cataract"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H25", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Cataract"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "366", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "366.19", "Other and combined forms of senile cataract")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9B10", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9B10.0", "Age-related cataract");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Refraction and Accommodation"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "367", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H52", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H52.1", "Myopia");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Refraction"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9D00", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Accommodation"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9D01", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Retinal Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "362", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "362.60", "Peripheral retinal degeneration, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H35", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H35.8", "Other specified retinal disorders");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Certain Specified Retinal Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9B78", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9B78.4", "Peripheral retinal degeneration");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Conjunctiva"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "372", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "372.30", "Conjunctivitis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Conjunctivitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H10", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "H10.9", "Conjunctivitis, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9A60", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "9A60.Z", "Conjunctivitis, unspecified");
        #endregion

        #region [ Psychiatry Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Episodic Mood Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "296", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "296.2", "Major depressive disorder, single episode");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Depressive Episode"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F32", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Single Episode Depressive Disorder"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "6A70", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Anxiety, Dissociative and Somatoform Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "300", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "300.02", "Generalized anxiety disorder");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Anxiety Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F41", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F41.1", "Generalized anxiety disorder");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Generalised Anxiety Disorder"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "6B00", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Schizophrenic Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "295", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Schizophrenia"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F20", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "6A20", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Episodic Mood Disorders"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "296", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "296.80", "Bipolar disorder, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Bipolar Affective Disorder"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F31", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F31.0", "Bipolar affective disorder, current episode hypomanic")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F31.2", "Bipolar affective disorder, current episode manic with psychotic symptoms");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Bipolar Type I Disorder"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "6A60", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Bipolar Type II Disorder"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "6A61", "");
        #endregion

        #region [ Pulmonology Department ]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Asthma"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "493", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "J45", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA23", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic Airway Obstruction, Not Elsewhere Classified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "496", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Chronic Obstructive Pulmonary Diseas"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "J44", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "J44.9", "Chronic obstructive pulmonary disease, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic Obstructive Pulmonary Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA22", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA22.Z", "Chronic obstructive pulmonary disease, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Pneumonia, Organism Unspecified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "486", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "J18", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Pneumonia"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA40", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA40.Z", "Pneumonia, organism unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Pulmonary tuberculosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "011", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Respiratory tuberculosis, bacteriologically and histologically confirmed"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "A15", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "A15.0", "Tuberculosis of lung, confirmed by sputum microscopy with or without culture");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Tuberculosis of the respiratory system"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "1B10", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Trachea, Bronchus, and Lung"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "162", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "162.9", "Malignant neoplasm of bronchus and lung, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Bronchus and Lung"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C34", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C34.9", "Bronchus or lung, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Bronchus or Lung"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C25", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C25.Z", "Malignant neoplasms of bronchus or lung, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Chronic Bronchitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "491", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Bronchitis, Not Specified as Acute or Chronic"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "490", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "J40", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Bronchitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA20", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA20.1", "Chronic bronchitis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA20.Z", "Bronchitis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Acute Bronchitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "J20", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "J20.9", "Acute bronchitis, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C25", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C25.Z", "Acute bronchitis, unspecified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other and Unspecified Disorders of Metabolism"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "277", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "277.0", "Cystic fibrosis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Cystic Fibrosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E84", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "E84.9", "Cystic fibrosis, unspecified")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA25", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "CA25.Z", "Cystic fibrosis, unspecified");
        #endregion

        #region [Urology Department]
        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Urethra and Urinary Tract"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "599", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "599.0", "Urinary tract infection, site not specified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Urinary System"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N39", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N39.0", "Urinary tract infection, site not specified");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Urinary Tract Infection, Site Not Specified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GC08", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Urinary Tract Infection, Site Not Specified"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "600", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "600.0", "Hypertrophy (benign) of prostate")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N40", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GA90", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasm of Prostate"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "185", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C61", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Prostate"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C82", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant neoplasm of bladder"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "188", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "C67", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Malignant Neoplasms of Bladder"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "2C94", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Cystitis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "595", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "595.1", "Chronic interstitial cystitis")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "N30", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "N30.1", "Interstitial cystitis (chronic)")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GC00", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GC00.3", "Interstitial cystitis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Symptoms Involving Urinary System"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "788", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "788.3", "Urinary incontinenc");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Other Disorders of Urinary System"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N39", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N39.4", "Other specified urinary incontinence");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Abnormal Micturition"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MF50", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "MF50.2", "Urinary incontinence");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Hydronephrosis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "591", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Obstructive and Reflux Uropathy"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N13", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N13.0", "Hydronephrosis with ureteropelvic junction obstruction");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Obstructive or Reflux Nephropathy"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB56", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GB56.2", "Hydronephrosis with ureteral orifice obstruction");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Urethritis Not Sexually Transmitted and Urethral Syndrome"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "597", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "597.8", "Other urethritis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Urethritis and Urethral Syndrome"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "N34", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "GC02", "");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Disorders of Penis"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "607", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-9")!, "607.8", "Other specified disorders of penis");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Sexual Dysfunction, Not Caused by Organic Disorder or Disease"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F52", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-10")!, "F52.2", "Failure of genital response");

        this.Diseases.FirstOrDefault(x => x.Name.Equals("Sexual Arousal Dysfunctions"))!
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "HA01", "")
                     .AddICDCodeWithVersion(this.ICDVersions.FirstOrDefault(v => v.Version == "ICD-11")!, "HA01.1", "Male erectile dysfunction");
        #endregion

        foreach (var item in Diseases)
        {
            this.ICDCodes.AddRange(item.ICDCodes);
        }
    }

    private void LoadICDCodeVersions()
    {
        foreach (var item in ICDCodes)
        {
            this.ICDCodeVersions.AddRange(item.ICDCodeVersions);
        }
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

    private void LoadFormType()
    {
        this.FormTypes.Add(FormTypeFactory.Create("Ultrasound Form", "Form for Ultrasound Machines", ""));
        this.FormTypes.Add(FormTypeFactory.Create("ECG Form", "Form for ECG Machines", ""));
        this.FormTypes.Add(FormTypeFactory.Create("X-Ray Form", "Form for X-Ray Machines", ""));
        this.FormTypes.Add(FormTypeFactory.Create("MRI Form", "Form for MRI Machines", ""));
        this.FormTypes.Add(FormTypeFactory.Create("CT Scan Form", "Form for CT Scanners", ""));
        this.FormTypes.Add(FormTypeFactory.Create("PET Scan Form", "Form for PET Scanners", ""));
        this.FormTypes.Add(FormTypeFactory.Create("Defibrillator Form", "Form for Defibrillators", ""));
        this.FormTypes.Add(FormTypeFactory.Create("Ventilator Form", "Form for Ventilators", ""));
        this.FormTypes.Add(FormTypeFactory.Create("Dialysis Form", "Form for Dialysis Machines", ""));
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

    private void LoadMedicalDeviceForm()
    {
        // Ultrasound Machines
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Voluson E10 Ultrasound Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Ultrasound Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips EPIQ Elite Ultrasound Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Ultrasound Form"))!); ;

        // Electrocardiogram (ECG) Machines
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE MAC 5500 HD ECG Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("ECG Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips PageWriter TC70 ECG Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("ECG Form"))!);

        // X-ray Machines
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Optima XR220amx X-ray Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("X-Ray Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips DigitalDiagnost C90 X-ray Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("X-Ray Form"))!);


        // Magnetic Resonance Imaging (MRI) Machines
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE SIGNA Premier MRI Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("MRI Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips Ingenia Elition MRI Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("MRI Form"))!);

        // Computed Tomography (CT) Scanners
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Revolution CT Scanner"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("CT Scan Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips Incisive CT Scanner"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("CT Scan Form"))!);

        // Positron Emission Tomography (PET) Scanners
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Discovery MI PET Scanner"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("PET Scan Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips Vereos PET Scanner"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("PET Scan Form"))!);

        // Defibrillators
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE Responder 2000 Defibrillator"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Defibrillator Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips HeartStart XL Defibrillator"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Defibrillator Form"))!);

        // Ventilators
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("GE CARESCAPE R860 Ventilator"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Ventilator Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Philips V680 Ventilator"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Ventilator Form"))!);

        // Dialysis Machines
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Fresenius 2008K Dialysis Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Dialysis Form"))!);
        this.MedicalDevices.FirstOrDefault(x => x.Name.Equals("Baxter HomeChoice Pro Dialysis Machine"))!
                           .AddMedicalDeviceFormWithFormType(FormTypes.FirstOrDefault(x => x.Name.Equals("Dialysis Form"))!);

        foreach (var item in MedicalDevices)
        {
            this.MedicalDeviceForms.AddRange(item.MedicalDeviceForms);
        }
    }

    private void LoadMedicalService()
    {
        // Common services
        this.MedicalServices.Add(MedicalServiceFactory.Create("Allergy Testing", Domain.ServiceType.Testing, 100, 200, 150));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Counseling and Support", Domain.ServiceType.Session, 80, 160, 120));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Health Metrics Tracking", Domain.ServiceType.Monitoring, 30, 60, 45));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Diet and Lifestyle Counseling", Domain.ServiceType.Session, 90, 180, 135));

        this.MedicalServices.Add(MedicalServiceFactory.Create("Routine Check-up", Domain.ServiceType.Visit, 50, 100, 80));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Blood Test", Domain.ServiceType.Testing, 20, 40, 30));
        this.MedicalServices.Add(MedicalServiceFactory.Create("X-ray", Domain.ServiceType.Scan, 100, 200, 150));
        this.MedicalServices.Add(MedicalServiceFactory.Create("MRI Scan", Domain.ServiceType.Scan, 500, 1000, 750));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Ultrasound", Domain.ServiceType.Scan, 200, 400, 300));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Physical Therapy Session", Domain.ServiceType.Session, 75, 150, 100));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Vaccination", Domain.ServiceType.Dose, 25, 50, 40));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Dental Cleaning", Domain.ServiceType.Visit, 100, 200, 150));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Eye Examination", Domain.ServiceType.Visit, 75, 150, 100));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Dermatology Consultation", Domain.ServiceType.Visit, 80, 160, 120));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Psychiatry Consultation", Domain.ServiceType.Visit, 120, 240, 180));

        this.MedicalServices.Add(MedicalServiceFactory.Create("Pulmonary Function Test", Domain.ServiceType.Scan, 70, 140, 105));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Oxygen Therapy Evaluation", Domain.ServiceType.Session, 100, 200, 150));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Vision Assessment", Domain.ServiceType.Scan, 60, 120, 90));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Pap Smear", Domain.ServiceType.Scan, 50, 100, 80));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Psychiatric Evaluation", Domain.ServiceType.Session, 100, 200, 150));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Dermatoscope Examination", Domain.ServiceType.Testing, 50, 100, 80));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Rheumatologic Assessment", Domain.ServiceType.Session, 100, 200, 150));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Urologic Assessment", Domain.ServiceType.Session, 100, 200, 150));

        // Rare services
        this.MedicalServices.Add(MedicalServiceFactory.Create("Cardiac Catheterization", Domain.ServiceType.Procedure, 2000, 4000, 3000));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Colonoscopy", Domain.ServiceType.Procedure, 800, 1600, 1200));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Endoscopy", Domain.ServiceType.Procedure, 800, 1600, 1200));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Joint Replacement Surgery", Domain.ServiceType.Surgery, 20000, 40000, 30000));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Cataract Surgery", Domain.ServiceType.Surgery, 3500, 7000, 5000));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Chemotherapy Session", Domain.ServiceType.Session, 2000, 4000, 3000));

        // Really rare services
        this.MedicalServices.Add(MedicalServiceFactory.Create("Organ Transplant", Domain.ServiceType.Surgery, 100000, 200000, 150000));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Gamma Knife Surgery", Domain.ServiceType.Surgery, 20000, 40000, 30000));
        this.MedicalServices.Add(MedicalServiceFactory.Create("Bone Marrow Transplant", Domain.ServiceType.Surgery, 50000, 100000, 75000));
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
                           .AddToStorage(this.Storages.FirstOrDefault(x => x.Location.Equals("Location 1"))!);

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
        //
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
        //
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
        //
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
        //
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
        this.Departments.Add(DepartmentFactory.Create("Radiology"));
    }

    private void LoadRoom()
    {
        // For Anesthesiology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("R101", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("R102", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("R103", Domain.RoomType.Recovery, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Anesthesiology"))!.AddRoom("R104", Domain.RoomType.Recovery, 2);

        // For Dermatology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("R105", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("R106", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("R107", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.AddRoom("R108", Domain.RoomType.Inpatient, 2);

        // For Emergency Medicine Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("R109", Domain.RoomType.Triage, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("R110", Domain.RoomType.TreatmentBay, 4);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("R111", Domain.RoomType.Resuscitation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Emergency Medicine"))!.AddRoom("R112", Domain.RoomType.ShortStay, 4);

        // For Endocrinology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Endocrinology"))!.AddRoom("R113", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Endocrinology"))!.AddRoom("R114", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Endocrinology"))!.AddRoom("R115", Domain.RoomType.Inpatient, 2);

        // For Gastroenterology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("R116", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("R117", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("R118", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.AddRoom("R119", Domain.RoomType.Inpatient, 2);

        // For Geriatrics Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Geriatrics"))!.AddRoom("R120", Domain.RoomType.General, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Geriatrics"))!.AddRoom("R121", Domain.RoomType.General, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Geriatrics"))!.AddRoom("R122", Domain.RoomType.General, 2);

        // For Hematology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("R201", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("R202", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("R203", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("R204", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Hematology"))!.AddRoom("R205", Domain.RoomType.Isolation, 1);

        // For Infectious Disease Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Infectious Disease"))!.AddRoom("R206", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Infectious Disease"))!.AddRoom("R207", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Infectious Disease"))!.AddRoom("R208", Domain.RoomType.Isolation, 2);

        // For Nephrology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("R209", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("R210", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("R211", Domain.RoomType.DialysisStation, 4);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.AddRoom("R212", Domain.RoomType.Inpatient, 2);

        // For Obstetrics and Gynecology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("R213", Domain.RoomType.LaborAndDelivery, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("R214", Domain.RoomType.GynecologicalConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("R215", Domain.RoomType.Postpartum, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.AddRoom("R216", Domain.RoomType.Operating, 1);

        // For Oncology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("R217", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("R218", Domain.RoomType.Chemotherapy, 4);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("R219", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Oncology"))!.AddRoom("R220", Domain.RoomType.Isolation, 2);

        // For Ophthalmology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Ophthalmology"))!.AddRoom("R301", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Ophthalmology"))!.AddRoom("R302", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Ophthalmology"))!.AddRoom("R303", Domain.RoomType.Procedure, 1);

        // For Pathology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pathology"))!.AddRoom("R304", Domain.RoomType.Laboratory, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pathology"))!.AddRoom("R305", Domain.RoomType.Laboratory, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pathology"))!.AddRoom("R306", Domain.RoomType.Laboratory, 1);

        // For Psychiatry Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("R307", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("R308", Domain.RoomType.Therapy, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("R309", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.AddRoom("R310", Domain.RoomType.Inpatient, 2);

        // For Pulmonology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("R311", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("R312", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("R313", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("R314", Domain.RoomType.Inpatient, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.AddRoom("R315", Domain.RoomType.ICU, 2);

        // For Rheumatology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Rheumatology"))!.AddRoom("R316", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Rheumatology"))!.AddRoom("R317", Domain.RoomType.OutpatientConsultation, 1);

        // For Surgery Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Surgery"))!.AddRoom("R401", Domain.RoomType.Operating, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Surgery"))!.AddRoom("R402", Domain.RoomType.Operating, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Surgery"))!.AddRoom("R403", Domain.RoomType.Recovery, 4);

        // For Urology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("R404", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("R405", Domain.RoomType.OutpatientConsultation, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("R406", Domain.RoomType.Procedure, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.AddRoom("R407", Domain.RoomType.Inpatient, 2);

        // For Radiology Department
        this.Departments.FirstOrDefault(x => x.Name.Equals("Radiology"))!.AddRoom("R408", Domain.RoomType.XRay, 2);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Radiology"))!.AddRoom("R409", Domain.RoomType.MRI, 1);
        this.Departments.FirstOrDefault(x => x.Name.Equals("Radiology"))!.AddRoom("R410", Domain.RoomType.Ultrasound, 2);

        //// For Internal Medicine Department
        //this.Departments.FirstOrDefault(x => x.Name.Equals("Internal Medicine"))!.AddRoom("F1R1", Domain.RoomType.OutpatientConsultation, 1);
        //this.Departments.FirstOrDefault(x => x.Name.Equals("Internal Medicine"))!.AddRoom("F1R2", Domain.RoomType.Laboratory, 2);

        foreach (var item in this.Departments)
        {
            this.Rooms.AddRange(item.Rooms);
        }
    }

    private void LoadBookingAppointment()
    {
        // Doctor 1 (ID: b1af80b4-cb25-4b15-858b-27c992d647a9)
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("b1af80b4-cb25-4b15-858b-27c992d647a9", "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "", new DateTime(2024, 1, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("b1af80b4-cb25-4b15-858b-27c992d647a9", "60b1647e-1474-4fae-95cf-43213dd070ae", "", new DateTime(2024, 2, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("b1af80b4-cb25-4b15-858b-27c992d647a9", "1c1217f4-4375-4a8d-a67e-8dd89bf99f41", "", new DateTime(2024, 3, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("b1af80b4-cb25-4b15-858b-27c992d647a9", "c2ecb78c-4bd2-40f6-a966-8eb1472382ce", "", new DateTime(2024, 4, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("b1af80b4-cb25-4b15-858b-27c992d647a9", "7baac533-bca9-40a8-9e69-c7df24170efa", "", new DateTime(2024, 5, 1)));

        // Doctor 2 (ID: 65410c16-c252-4c9d-accd-c4917fa87bd0)
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("65410c16-c252-4c9d-accd-c4917fa87bd0", "77204cd1-fba2-4faf-9fb6-ee258fddaa8d", "", new DateTime(2024, 6, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("65410c16-c252-4c9d-accd-c4917fa87bd0", "17e9c247-4bc1-492a-9f33-219e288ae5a9", "", new DateTime(2024, 1, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("65410c16-c252-4c9d-accd-c4917fa87bd0", "7f2287a6-011c-4f51-8ea0-9bb1857c05f9", "", new DateTime(2024, 2, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("65410c16-c252-4c9d-accd-c4917fa87bd0", "b28a4b05-8609-4f90-a484-73f69b1bc1c9", "", new DateTime(2024, 3, 1)));
        this.BookingAppointments.Add(BookingAppointmentFactory.Create("65410c16-c252-4c9d-accd-c4917fa87bd0", "c364faa0-652d-4aad-a5d4-9978989629dd", "", new DateTime(2024, 4, 1)));
    }

    private void LoadMedicalExam()
    {
        foreach (var item in this.BookingAppointments)
        {
            item.AddMedicalExam();

            this.MedicalExams.Add(item.MedicalExam!);
        }
    }

    private void LoadMedicalExamEpisode()
    {
        // Patient ID: f8d46725-b3d9-4c3f-b5ed-d0561e437f56
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 1, 2), 1, new DateTime(2024, 1, 2), 100)
                         .AddMedicalExamEpisode(new DateTime(2024, 2, 2), 2, new DateTime(2024, 2, 2), 120)
                         .AddMedicalExamEpisode(new DateTime(2024, 3, 2), 3, new DateTime(2024, 3, 2), 130)
                         .AddMedicalExamEpisode(new DateTime(2024, 4, 2), 4, new DateTime(2024, 4, 2), 140)
                         .AddMedicalExamEpisode(new DateTime(2024, 5, 2), 5, new DateTime(2024, 5, 2), 150);

        // Patient ID: 60b1647e-1474-4fae-95cf-43213dd070ae
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("60b1647e-1474-4fae-95cf-43213dd070ae"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 2, 4), 1, new DateTime(2024, 2, 4), 160)
                         .AddMedicalExamEpisode(new DateTime(2024, 3, 4), 2, new DateTime(2024, 3, 4), 170);

        // Patient ID: 1c1217f4-4375-4a8d-a67e-8dd89bf99f41
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("1c1217f4-4375-4a8d-a67e-8dd89bf99f41"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 3, 4), 1, new DateTime(2024, 3, 4), 180)
                         .AddMedicalExamEpisode(new DateTime(2024, 4, 4), 2, new DateTime(2024, 4, 4), 190);

        // Patient ID: c2ecb78c-4bd2-40f6-a966-8eb1472382ce
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 4, 17), 1, new DateTime(2024, 4, 17), 180)
                         .AddMedicalExamEpisode(new DateTime(2024, 5, 17), 2, new DateTime(2024, 5, 17), 190);

        // Patient ID: 77204cd1-fba2-4faf-9fb6-ee258fddaa8d
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("77204cd1-fba2-4faf-9fb6-ee258fddaa8d"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 1, 22), 1, new DateTime(2024, 1, 22), 180)
                         .AddMedicalExamEpisode(new DateTime(2024, 2, 22), 2, new DateTime(2024, 2, 22), 190);

        // Patient ID: 17e9c247-4bc1-492a-9f33-219e288ae5a9
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("17e9c247-4bc1-492a-9f33-219e288ae5a9"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 2, 15), 1, new DateTime(2024, 2, 16), 180)
                         .AddMedicalExamEpisode(new DateTime(2024, 3, 15), 2, new DateTime(2024, 3, 15), 190);

        // Patient ID: 7f2287a6-011c-4f51-8ea0-9bb1857c05f9
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("7f2287a6-011c-4f51-8ea0-9bb1857c05f9"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 4, 12), 1, new DateTime(2024, 4, 12), 180)
                         .AddMedicalExamEpisode(new DateTime(2024, 5, 12), 2, new DateTime(2024, 5, 13), 190);

        // Patient ID: b28a4b05-8609-4f90-a484-73f69b1bc1c9
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("b28a4b05-8609-4f90-a484-73f69b1bc1c9"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 5, 3), 1, new DateTime(2024, 5, 3), 180)
                         .AddMedicalExamEpisode(new DateTime(2024, 6, 3), 2, new DateTime(2024, 6, 3), 190);

        // Patient ID: c364faa0-652d-4aad-a5d4-9978989629dd
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c364faa0-652d-4aad-a5d4-9978989629dd"))!
                         .AddMedicalExamEpisode(new DateTime(2024, 5, 24), 1, new DateTime(2024, 5, 25), 180)
                         .AddMedicalExamEpisode(new DateTime(2024, 6, 24), 2, new DateTime(2024, 6, 24), 190);

        foreach (var item in this.MedicalExams)
        {
            this.MedicalExamEpisodes.AddRange(item.MedicalExamEpisodes);
        }
    }

    private void LoadDiagnosis()
    {
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("L63.9"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("60b1647e-1474-4fae-95cf-43213dd070ae"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("E10"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("1c1217f4-4375-4a8d-a67e-8dd89bf99f41"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("DB35.0"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("Q61"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("N87.0"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("77204cd1-fba2-4faf-9fb6-ee258fddaa8d"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("H52.1"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("17e9c247-4bc1-492a-9f33-219e288ae5a9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("F41.1"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("7f2287a6-011c-4f51-8ea0-9bb1857c05f9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("J44.9"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("b28a4b05-8609-4f90-a484-73f69b1bc1c9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("M06.9"))!, "", ""));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c364faa0-652d-4aad-a5d4-9978989629dd"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("N40"))!, "", ""));

        foreach (var item in this.MedicalExamEpisodes)
        {
            this.Diagnoses.AddRange(item.Diagnoses);
        }
    }

    private void LoadAssignmentHistory()
    {
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("60b1647e-1474-4fae-95cf-43213dd070ae"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("1c1217f4-4375-4a8d-a67e-8dd89bf99f41"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "7baac533-bca9-40a8-9e69-c7df24170efa"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("77204cd1-fba2-4faf-9fb6-ee258fddaa8d"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("17e9c247-4bc1-492a-9f33-219e288ae5a9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("7f2287a6-011c-4f51-8ea0-9bb1857c05f9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("b28a4b05-8609-4f90-a484-73f69b1bc1c9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0"));

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c364faa0-652d-4aad-a5d4-9978989629dd"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0"));

        foreach (var item in this.MedicalExamEpisodes)
        {
            this.AssignmentHistories.AddRange(item.AssignmentHistories);
        }
    }

    private void LoadAnalysisTest()
    {
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList() 
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("60b1647e-1474-4fae-95cf-43213dd070ae"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("1c1217f4-4375-4a8d-a67e-8dd89bf99f41"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("77204cd1-fba2-4faf-9fb6-ee258fddaa8d"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("17e9c247-4bc1-492a-9f33-219e288ae5a9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("7f2287a6-011c-4f51-8ea0-9bb1857c05f9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("b28a4b05-8609-4f90-a484-73f69b1bc1c9"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c364faa0-652d-4aad-a5d4-9978989629dd"))!.MedicalExamEpisodes
                         .ToList()
                         .ForEach(episode => episode.AddAnalysisTest());

        foreach (var item in this.MedicalExamEpisodes)
        {
            this.Diagnoses.AddRange(item.Diagnoses);
        }
    }

    private void LoadServiceEpisode()
    {
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Allergy Testing"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Counseling and Support"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Dermatoscope Examination"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Health Metrics Tracking"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList()[2].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList()[3].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Counseling and Support"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                         .ToList()[4].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Health Metrics Tracking"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("60b1647e-1474-4fae-95cf-43213dd070ae"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Blood Test"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Diet and Lifestyle Counseling"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("60b1647e-1474-4fae-95cf-43213dd070ae"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Health Metrics Tracking"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Counseling and Support"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("1c1217f4-4375-4a8d-a67e-8dd89bf99f41"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Colonoscopy"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("1c1217f4-4375-4a8d-a67e-8dd89bf99f41"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Diet and Lifestyle Counseling"))!); 

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Ultrasound"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Diet and Lifestyle Counseling"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Pap Smear"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Colonoscopy"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Pap Smear"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Diet and Lifestyle Counseling"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("77204cd1-fba2-4faf-9fb6-ee258fddaa8d"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Eye Examination"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("77204cd1-fba2-4faf-9fb6-ee258fddaa8d"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Vision Assessment"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("17e9c247-4bc1-492a-9f33-219e288ae5a9"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Psychiatric Evaluation"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("17e9c247-4bc1-492a-9f33-219e288ae5a9"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Physical Therapy Session"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("7f2287a6-011c-4f51-8ea0-9bb1857c05f9"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Pulmonary Function Test"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("7f2287a6-011c-4f51-8ea0-9bb1857c05f9"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Oxygen Therapy Evaluation"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("b28a4b05-8609-4f90-a484-73f69b1bc1c9"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Rheumatologic Assessment"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("b28a4b05-8609-4f90-a484-73f69b1bc1c9"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Physical Therapy Session"))!);

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c364faa0-652d-4aad-a5d4-9978989629dd"))!.MedicalExamEpisodes
                         .ToList()[0].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Urologic Assessment"))!);
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c364faa0-652d-4aad-a5d4-9978989629dd"))!.MedicalExamEpisodes
                         .ToList()[1].AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Routine Check-up"))!)
                                     .AddServiceEpisodeWithService(this.MedicalServices.FirstOrDefault(x => x.Name.Equals("Urologic Assessment"))!);

        foreach (var item in this.MedicalExamEpisodes)
        {
            this.ServiceEpisodes.AddRange(item.ServiceEpisodes);
        }
    }

    private void LoadMedicalExamEpisodeRelated()
    {
        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("f8d46725-b3d9-4c3f-b5ed-d0561e437f56"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                                {
                                                    episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9");
                                                    episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("L63.9"))!, "", "");
                                                    episode.AddAnalysisTest();
                                                    episode.AddDrugPrescription()
                                                           .AddDrugPrescription()
                                                           .AddDrugPrescription();
                                                    episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Dermatology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(), 
                                                                              episode.RecordDay, episode.RecordDay.AddHours(1), 
                                                                              "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                                });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("60b1647e-1474-4fae-95cf-43213dd070ae"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("E10"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Endocrinology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(), 
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1), 
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("1c1217f4-4375-4a8d-a67e-8dd89bf99f41"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("DB35.0"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Gastroenterology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(), 
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1), 
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "b1af80b4-cb25-4b15-858b-27c992d647a9");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("Q61"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Nephrology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(), 
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1), 
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c2ecb78c-4bd2-40f6-a966-8eb1472382ce"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "7baac533-bca9-40a8-9e69-c7df24170efa");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("N87.0"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Obstetrics and Gynecology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(), 
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1), 
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("77204cd1-fba2-4faf-9fb6-ee258fddaa8d"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("H52.1"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Ophthalmology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(),
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1),
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("17e9c247-4bc1-492a-9f33-219e288ae5a9"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("F41.1"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Psychiatry"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(),
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1),
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("7f2287a6-011c-4f51-8ea0-9bb1857c05f9"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("J44.9"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Pulmonology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(),
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1),
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("b28a4b05-8609-4f90-a484-73f69b1bc1c9"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("M06.9"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Rheumatology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(),
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1),
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });

        this.MedicalExams.FirstOrDefault(x => x.BookingAppointment!.PatientId!.Equals("c364faa0-652d-4aad-a5d4-9978989629dd"))!.MedicalExamEpisodes
                                               .ToList().ForEach(episode =>
                                               {
                                                   episode.AddAssignmentHistory("Completed", "65410c16-c252-4c9d-accd-c4917fa87bd0");
                                                   episode.AddDiagnosis(this.ICDCodes.FirstOrDefault(x => x.Code!.Equals("N40"))!, "", "");
                                                   episode.AddAnalysisTest();
                                                   episode.AddDrugPrescription()
                                                          .AddDrugPrescription()
                                                          .AddDrugPrescription();
                                                   episode.AddRoomAllocation(this.Departments.FirstOrDefault(x => x.Name.Equals("Urology"))!.Rooms.OrderBy(x => Guid.NewGuid()).First(),
                                                                             episode.RecordDay, episode.RecordDay.AddHours(1),
                                                                             "f8d46725-b3d9-4c3f-b5ed-d0561e437f56", "");
                                               });
    }

    private void LoadBills()
    {
        //this.MedicalExamEpisodes.ForEach(episode =>
        //{
        //    episode.AddBill(episode.DateTakeExam.AddDays(7), 
        //                    episode.DateTakeExam.AddDays(7), 
        //                    "Completed", 
        //                    episode.DrugPrescriptions.Sum(drug => drug.Amount * drug.DrugInventory.Drug!.UnitPrice) + episode.AnalysisTests.Sum(test => test.DeviceService.Service.ServicePrice),
        //                    0, 0, 0, 0, "");
        //});

        foreach (var item in this.MedicalExamEpisodes)
        {
            this.Bills.Add(item.Bill);
        }
    }
    #endregion
}

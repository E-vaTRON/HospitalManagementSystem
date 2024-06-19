namespace HospitalManagementSystem.Domain;

public static class MedicalExamEpisodeExtensions
{
    #region [ Private Methods ]
    private static MedicalExamEpisode AddAssignmentHistory(this MedicalExamEpisode medicalExamEpisode, AssignmentHistory assignmentHistory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(assignmentHistory));

        if (medicalExamEpisode.AssignmentHistories.Any(x => x.Id == assignmentHistory.Id))
        {
            return medicalExamEpisode;
        }

        assignmentHistory.MedicalExamEpisodeId = medicalExamEpisode.Id;
        assignmentHistory.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.AssignmentHistories.Add(assignmentHistory);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddDiagnosis(this MedicalExamEpisode medicalExamEpisode, Diagnosis diagnosis)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(diagnosis));

        if (medicalExamEpisode.Diagnoses.Any(x => x.Id == diagnosis.Id))
        {
            return medicalExamEpisode;
        }

        diagnosis.MedicalExamEpisodeId = medicalExamEpisode.Id;
        diagnosis.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.Diagnoses.Add(diagnosis);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddRoomAllocation(this MedicalExamEpisode medicalExamEpisode, RoomAllocation roomAllocation)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(roomAllocation));

        if (medicalExamEpisode.RoomAllocations.Any(x => x.Id == roomAllocation.Id))
        {
            return medicalExamEpisode;
        }

        roomAllocation.MedicalExamEpisodeId = medicalExamEpisode.Id;
        roomAllocation.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.RoomAllocations.Add(roomAllocation);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddDrugPrescription(this MedicalExamEpisode medicalExamEpisode, DrugPrescription drugPrescription)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugPrescription));

        if (medicalExamEpisode.DrugPrescriptions.Any(x => x.Id == drugPrescription.Id))
        {
            return medicalExamEpisode;
        }

        drugPrescription.MedicalExamEpisodeId = medicalExamEpisode.Id;
        drugPrescription.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.DrugPrescriptions.Add(drugPrescription);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddAnalysisTest(this MedicalExamEpisode medicalExamEpisode, AnalysisTest analysisTest)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(analysisTest));

        if (medicalExamEpisode.AnalysisTests.Any(x => x.Id == analysisTest.Id))
        {
            return medicalExamEpisode;
        }

        analysisTest.MedicalExamEpisodeId = medicalExamEpisode.Id;
        analysisTest.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.AnalysisTests.Add(analysisTest);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode, Bill bill)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(bill));

        if (medicalExamEpisode.Bill is null)
        {
            return medicalExamEpisode;
        }

        bill.MedicalExamEpisodeId = medicalExamEpisode.Id;
        bill.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.Bill = bill;
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddReExamAppointment(this MedicalExamEpisode medicalExamEpisode, ReExamAppointment reExamAppointment)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(reExamAppointment));

        if (medicalExamEpisode.ReExamAppointment is null)
        {
            return medicalExamEpisode;
        }

        reExamAppointment.MedicalExamEpisodeId = medicalExamEpisode.Id;
        reExamAppointment.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.ReExamAppointment = reExamAppointment;
        return medicalExamEpisode;
    }
    #endregion

    #region [ Public Methods ]
    public static MedicalExamEpisode AddAssignmentHistory(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddAssignmentHistory(AssignmentHistoryFactory.Create());
    }

    public static MedicalExamEpisode AddAssignmentHistory(this MedicalExamEpisode medicalExamEpisode, string assignmentStatus, string doctorId, string medicalExamEpisodeId, string referralDoctorId)
    {
        return medicalExamEpisode.AddAssignmentHistory(AssignmentHistoryFactory.Create(assignmentStatus, doctorId, medicalExamEpisodeId, referralDoctorId));
    }

    public static MedicalExamEpisode AddAssignmentHistory(this MedicalExamEpisode medicalExamEpisode, string assignmentStatus, string doctorId, string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddAssignmentHistory(AssignmentHistoryFactory.Create(assignmentStatus, doctorId, medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddDiagnosis(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddDiagnosis(DiagnosisFactory.Create());
    }

    public static MedicalExamEpisode AddDiagnosis(this MedicalExamEpisode medicalExamEpisode, string diagnosisCode, string description, string icdId, string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddDiagnosis(DiagnosisFactory.Create(diagnosisCode, description, icdId, medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddDiagnosis(this MedicalExamEpisode medicalExamEpisode, string diagnosisCode, string icdId, string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddDiagnosis(DiagnosisFactory.Create(diagnosisCode, icdId, medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddRoomAllocation(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddRoomAllocation(RoomAllocationFactory.Create());
    }

    public static MedicalExamEpisode AddRoomAllocation(this MedicalExamEpisode medicalExamEpisode, DateTime startTime, DateTime endTime, string patientId, string employeeId, string roomId, string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddRoomAllocation(RoomAllocationFactory.Create(startTime, endTime, patientId, employeeId, roomId, medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddRoomAllocation(this MedicalExamEpisode medicalExamEpisode, DateTime endTime, string patientId, string employeeId, string roomId)
    {
        return medicalExamEpisode.AddRoomAllocation(RoomAllocationFactory.Create(endTime, patientId, employeeId, roomId));
    }

    public static MedicalExamEpisode AddDrugPrescription(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddDrugPrescription(DrugPrescriptionFactory.Create());
    }

    public static MedicalExamEpisode AddDrugPrescription(this MedicalExamEpisode medicalExamEpisode, string medicalExamEpisodeId, string drugInventoryId)
    {
        return medicalExamEpisode.AddDrugPrescription(DrugPrescriptionFactory.Create(medicalExamEpisodeId, drugInventoryId));
    }

    public static MedicalExamEpisode AddAnalysisTest(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddAnalysisTest(AnalysisTestFactory.Create());
    }

    public static MedicalExamEpisode AddAnalysisTest(this MedicalExamEpisode medicalExamEpisode, string doctorComment, string result, string deviceServiceId, string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddAnalysisTest(AnalysisTestFactory.Create(doctorComment, result, deviceServiceId, medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddAnalysisTest(this MedicalExamEpisode medicalExamEpisode, string result, string deviceServiceId, string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddAnalysisTest(AnalysisTestFactory.Create(result, deviceServiceId, medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddBill(BillFactory.Create());
    }

    public static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode, DateTime deadline, DateTime? paidDate, string status,
                decimal totalAmount, decimal excessAmount, decimal underPaidAmount,
                decimal discountAmount, decimal adjustmentAmount, string paymentMethod,
                string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddBill(BillFactory.Create(deadline, paidDate, status,
                totalAmount, excessAmount, underPaidAmount,
                discountAmount, adjustmentAmount, paymentMethod,
                medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode, string status, decimal totalAmount, decimal excessAmount, decimal underPaidAmount,
                decimal discountAmount, decimal adjustmentAmount, string paymentMethod,
                string medicalExamEpisodeId)
    {
        return medicalExamEpisode.AddBill(BillFactory.Create(status, totalAmount, excessAmount, underPaidAmount,
                discountAmount, adjustmentAmount, paymentMethod,
                medicalExamEpisodeId));
    }

    public static MedicalExamEpisode AddReExamAppointment(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddReExamAppointment(ReExamAppointmentFactory.Create());
    }

    public static MedicalExamEpisode AddReExamAppointment(this MedicalExamEpisode medicalExamEpisode, string patientId, string medicalExamEpisodeId, string notes, DateTime dateTime)
    {
        return medicalExamEpisode.AddReExamAppointment(ReExamAppointmentFactory.Create(patientId, medicalExamEpisodeId, notes, dateTime));
    }

    public static MedicalExamEpisode AddReExamAppointment(this MedicalExamEpisode medicalExamEpisode, string patientId, string medicalExamEpisodeId, string notes)
    {
        return medicalExamEpisode.AddReExamAppointment(ReExamAppointmentFactory.Create(patientId, medicalExamEpisodeId, notes));
    }
    #endregion
}

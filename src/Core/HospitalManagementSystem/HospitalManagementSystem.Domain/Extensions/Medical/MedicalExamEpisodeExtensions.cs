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

    private static MedicalExamEpisode AddDiagnosis(this MedicalExamEpisode medicalExamEpisode, Diagnosis diagnosis, ICDCode iCDCode)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(diagnosis));

        if (medicalExamEpisode.Diagnoses.Any(x => x.Id == diagnosis.Id))
        {
            return medicalExamEpisode;
        }

        diagnosis.MedicalExamEpisodeId = medicalExamEpisode.Id;
        diagnosis.MedicalExamEpisode = medicalExamEpisode;
        diagnosis.ICDCodeId = iCDCode.Id;
        diagnosis.ICDCode = iCDCode;
        medicalExamEpisode.Diagnoses.Add(diagnosis);
        iCDCode.Diagnoses.Add(diagnosis);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddRoomAllocation(this MedicalExamEpisode medicalExamEpisode, RoomAllocation roomAllocation, Room room)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(roomAllocation));

        if (medicalExamEpisode.RoomAllocations.Any(x => x.Id == roomAllocation.Id))
        {
            return medicalExamEpisode;
        }

        roomAllocation.MedicalExamEpisodeId = medicalExamEpisode.Id;
        roomAllocation.MedicalExamEpisode = medicalExamEpisode;
        roomAllocation.RoomId = room.Id;
        roomAllocation.Room = room;
        medicalExamEpisode.RoomAllocations.Add(roomAllocation);
        room.RoomAllocations.Add(roomAllocation);
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

    private static MedicalExamEpisode AddDrugPrescriptionInStorage(this MedicalExamEpisode medicalExamEpisode, DrugInventory drugInventory, DrugPrescription drugPrescription)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugPrescription));

        if (medicalExamEpisode.DrugPrescriptions.Any(x => x.Id == drugPrescription.Id))
        {
            return medicalExamEpisode;
        }

        drugPrescription.MedicalExamEpisodeId = medicalExamEpisode.Id;
        drugPrescription.MedicalExamEpisode = medicalExamEpisode;
        drugPrescription.DrugInventoryId = drugInventory.Id;
        drugPrescription.DrugInventory = drugInventory;
        medicalExamEpisode.DrugPrescriptions.Add(drugPrescription);
        drugInventory.DrugPrescriptions.Add(drugPrescription);
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

    private static MedicalExamEpisode AddAnalysisTestWithDevice(this MedicalExamEpisode medicalExamEpisode, DeviceInventory deviceInventory, AnalysisTest analysisTest)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(analysisTest));

        if (medicalExamEpisode.AnalysisTests.Any(x => x.Id == analysisTest.Id))
        {
            return medicalExamEpisode;
        }

        analysisTest.MedicalExamEpisodeId = medicalExamEpisode.Id;
        analysisTest.MedicalExamEpisode = medicalExamEpisode;
        analysisTest.DeviceInventoryId = deviceInventory.Id;
        analysisTest.DeviceInventory = deviceInventory;
        medicalExamEpisode.AnalysisTests.Add(analysisTest);
        deviceInventory.AnalysisTests.Add(analysisTest);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddServiceEpisode(this MedicalExamEpisode medicalExamEpisode, ServiceEpisode serviceEpisode)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(serviceEpisode));

        if (medicalExamEpisode.ServiceEpisodes.Any(x => x.Id == serviceEpisode.Id))
        {
            return medicalExamEpisode;
        }

        serviceEpisode.MedicalExamEpisodeId = medicalExamEpisode.Id;
        serviceEpisode.MedicalExamEpisode = medicalExamEpisode;
        medicalExamEpisode.ServiceEpisodes.Add(serviceEpisode);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddServiceEpisodeWithService(this MedicalExamEpisode medicalExamEpisode, MedicalService medicalService, ServiceEpisode serviceEpisode)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(serviceEpisode));

        if (medicalExamEpisode.ServiceEpisodes.Any(x => x.Id == serviceEpisode.Id))
        {
            return medicalExamEpisode;
        }

        serviceEpisode.MedicalExamEpisodeId = medicalExamEpisode.Id;
        serviceEpisode.MedicalExamEpisode = medicalExamEpisode;
        serviceEpisode.MedicalServiceId = medicalService.Id;
        serviceEpisode.MedicalService = medicalService;
        medicalService.ServiceEpisodes.Add(serviceEpisode);
        medicalExamEpisode.ServiceEpisodes.Add(serviceEpisode);
        return medicalExamEpisode;
    }

    private static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode, Bill bill)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(bill));

        if (medicalExamEpisode.Bill is not null)
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

        if (medicalExamEpisode.ReExamAppointment is not null)
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

    public static MedicalExamEpisode AddAssignmentHistory(this MedicalExamEpisode medicalExamEpisode, string assignmentStatus, string doctorId, string referralDoctorId)
    {
        return medicalExamEpisode.AddAssignmentHistory(AssignmentHistoryFactory.Create(assignmentStatus, doctorId, referralDoctorId));
    }

    public static MedicalExamEpisode AddAssignmentHistory(this MedicalExamEpisode medicalExamEpisode, string assignmentStatus, string doctorId)
    {
        return medicalExamEpisode.AddAssignmentHistory(AssignmentHistoryFactory.Create(assignmentStatus, doctorId));
    }

    public static MedicalExamEpisode AddDiagnosis(this MedicalExamEpisode medicalExamEpisode, ICDCode iCDCode)
    {
        return medicalExamEpisode.AddDiagnosis(DiagnosisFactory.Create(), iCDCode);
    } 

    public static MedicalExamEpisode AddDiagnosis(this MedicalExamEpisode medicalExamEpisode, ICDCode iCDCode, string diagnosisCode, string description)
    {
        return medicalExamEpisode.AddDiagnosis(DiagnosisFactory.Create(diagnosisCode, description), iCDCode);
    }

    public static MedicalExamEpisode AddRoomAllocation(this MedicalExamEpisode medicalExamEpisode, Room room)
    {
        return medicalExamEpisode.AddRoomAllocation(RoomAllocationFactory.Create(), room);
    }

    public static MedicalExamEpisode AddRoomAllocation(this MedicalExamEpisode medicalExamEpisode, Room room, DateTime startTime, DateTime endTime, string patientId, string employeeId)
    {
        return medicalExamEpisode.AddRoomAllocation(RoomAllocationFactory.Create(startTime, endTime, patientId, employeeId), room);
    }

    public static MedicalExamEpisode AddDrugPrescription(this MedicalExamEpisode medicalExamEpisode, int amount)
    {
        return medicalExamEpisode.AddDrugPrescription(DrugPrescriptionFactory.Create(amount));
    }

    public static MedicalExamEpisode AddDrugPrescriptionInStorage(this MedicalExamEpisode medicalExamEpisode, DrugInventory drugInventory, int amount)
    {
        return medicalExamEpisode.AddDrugPrescriptionInStorage(drugInventory, DrugPrescriptionFactory.Create(amount));
    }

    public static MedicalExamEpisode AddAnalysisTest(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddAnalysisTest(AnalysisTestFactory.Create());
    }

    public static MedicalExamEpisode AddAnalysisTestWithDevice(this MedicalExamEpisode medicalExamEpisode, DeviceInventory deviceInventory, string resultSummary, string specificMeasurements, string userId, string technicianSignature)
    {
        return medicalExamEpisode.AddAnalysisTestWithDevice(deviceInventory, AnalysisTestFactory.Create(resultSummary, specificMeasurements, userId, technicianSignature));
    }

    public static MedicalExamEpisode AddAnalysisTest(this MedicalExamEpisode medicalExamEpisode, string doctorComment, string resultSummary, string specificMeasurements, string userId, string technicianSignature)
    {
        return medicalExamEpisode.AddAnalysisTest(AnalysisTestFactory.Create(doctorComment, resultSummary, specificMeasurements, userId, technicianSignature));
    }

    public static MedicalExamEpisode AddAnalysisTest(this MedicalExamEpisode medicalExamEpisode, string resultSummary, string specificMeasurements, string userId, string technicianSignature)
    {
        return medicalExamEpisode.AddAnalysisTest(AnalysisTestFactory.Create(resultSummary, specificMeasurements, userId, technicianSignature));
    }

    public static MedicalExamEpisode AddServiceEpisode(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddServiceEpisode(ServiceEpisodeFactory.Create());
    }

    public static MedicalExamEpisode AddServiceEpisodeWithService(this MedicalExamEpisode medicalExamEpisode, MedicalService medicalService)
    {
        return medicalExamEpisode.AddServiceEpisodeWithService(medicalService, ServiceEpisodeFactory.Create());
    }

    public static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddBill(BillFactory.Create());
    }

    public static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode, DateTime deadline, DateTime? paidDate, string status,
                decimal totalAmount, decimal excessAmount, decimal underPaidAmount,
                decimal discountAmount, decimal adjustmentAmount, string paymentMethod)
    {
        return medicalExamEpisode.AddBill(BillFactory.Create(deadline, paidDate, status,
                totalAmount, excessAmount, underPaidAmount,
                discountAmount, adjustmentAmount, paymentMethod));
    }

    public static MedicalExamEpisode AddBill(this MedicalExamEpisode medicalExamEpisode, string status, decimal totalAmount, decimal excessAmount, decimal underPaidAmount,
                decimal discountAmount, decimal adjustmentAmount, string paymentMethod)
    {
        return medicalExamEpisode.AddBill(BillFactory.Create(status, totalAmount, excessAmount, underPaidAmount,
                discountAmount, adjustmentAmount, paymentMethod));
    }

    public static MedicalExamEpisode AddReExamAppointment(this MedicalExamEpisode medicalExamEpisode)
    {
        return medicalExamEpisode.AddReExamAppointment(ReExamAppointmentFactory.Create());
    }

    public static MedicalExamEpisode AddReExamAppointment(this MedicalExamEpisode medicalExamEpisode, string patientId, string notes, DateTime dateTime)
    {
        return medicalExamEpisode.AddReExamAppointment(ReExamAppointmentFactory.Create(patientId, notes, dateTime));
    }

    public static MedicalExamEpisode AddReExamAppointment(this MedicalExamEpisode medicalExamEpisode, string patientId, string notes)
    {
        return medicalExamEpisode.AddReExamAppointment(ReExamAppointmentFactory.Create(patientId, notes));
    }

    public static MedicalExamEpisode RemoveRelated(this MedicalExamEpisode medicalExamEpisode)
    {
        medicalExamEpisode.MedicalExam = null!;
        medicalExamEpisode.ReExamAppointment = null!;
        medicalExamEpisode.Bill = null!;
        medicalExamEpisode.AssignmentHistories.Clear();
        medicalExamEpisode.AnalysisTests.Clear();
        medicalExamEpisode.Diagnoses.Clear();
        medicalExamEpisode.RoomAllocations.Clear();
        medicalExamEpisode.DrugPrescriptions.Clear();
        medicalExamEpisode.ServiceEpisodes.Clear();
        return medicalExamEpisode;
    }
    #endregion
}

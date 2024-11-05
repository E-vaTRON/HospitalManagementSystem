namespace HospitalManagementSystem.Application;

public record OutputMedicalExamEpisodeDTO : MedicalExamEpisodeDTO
{
    public OutputMedicalExamDTO?          MedicalExam          { get; init; }
    public OutputReExamAppointmentDTO?    ReExamAppointment    { get; init; }
    public OutputBillDTO?                 Bill                  { get; init; }

    public ICollection<OutputAssignmentHistoryDTO>?     AssignmentHistories { get; init; }
    public ICollection<OutputDiagnosisDTO>?             Diagnoses           { get; init; }
    public ICollection<OutputRoomAllocationDTO>?        RoomAllocations     { get; init; }
    public ICollection<OutputDrugPrescriptionDTO>?      DrugPrescriptions   { get; init; }
    public ICollection<OutputAnalysisTestDTO>?          AnalysisTests       { get; init; }
    public ICollection<OutputServiceEpisodeDTO>?        ServiceEpisodes     { get; init; }
}
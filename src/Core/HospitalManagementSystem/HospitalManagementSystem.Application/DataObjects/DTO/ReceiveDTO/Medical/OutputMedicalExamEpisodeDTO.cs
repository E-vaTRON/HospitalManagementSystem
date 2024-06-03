namespace HospitalManagementSystem.Application;

public record OutputMedicalExamEpisodeDTO : MedicalExamEpisodeDTO
{
    public OutputMedicalExamDTO?          MedicalExamDTO          { get; init; }
    public OutputReExamAppointmentDTO?    ReExamAppointmentDTO    { get; init; }

    public ICollection<OutputAssignmentHistoryDTO>?   AssignmentHistoryDTOs   { get; init; }
    public ICollection<OutputDiagnosisDTO>?           DiagnosisDTOs           { get; init; }
    public ICollection<OutputRoomAllocationDTO>?      RoomAllocationDTOs      { get; init; }
    public ICollection<OutputDrugPrescriptionDTO>?    DrugPrescriptionDTOs    { get; init; }
    public ICollection<OutputAnalysisTestDTO>?        AnalysisTestDTOs        { get; init; }
}
namespace HospitalManagementSystem.Application;

public record OutputMedicalExamEpisodeDTO : MedicalExamEpisodeDTO
{
    public MedicalExamDTO?          MedicalExamDTO          { get; init; }
    public ReExamAppointmentDTO?    ReExamAppointmentDTO    { get; init; }

    public ICollection<AssignmentHistoryDTO>?   AssignmentHistoryDTOs   { get; init; }
    public ICollection<DiagnosisDTO>?           DiagnosisDTOs           { get; init; }
    public ICollection<RoomAllocationDTO>?      RoomAllocationDTOs      { get; init; }
    public ICollection<DrugPrescriptionDTO>?    DrugPrescriptionDTOs    { get; init; }
    public ICollection<AnalysisTestDTO>?        AnalysisTestDTOs        { get; init; }
}
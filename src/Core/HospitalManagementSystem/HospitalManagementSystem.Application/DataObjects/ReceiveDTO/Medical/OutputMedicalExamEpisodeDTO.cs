namespace HospitalManagementSystem.Application;

public record OutputMedicalExamEpisodeDTO : MedicalExamEpisodeDTO
{
    public MedicalExamDTO?          MedicalExamDTO          { get; set; }
    public ReExamAppointmentDTO?    ReExamAppointmentDTO    { get; set; }

    public ICollection<AssignmentHistoryDTO>?   AssignmentHistoryDTOs   { get; set; }
    public ICollection<DiagnosisDTO>?           DiagnosisDTOs           { get; set; }
    public ICollection<RoomAllocationDTO>?      RoomAllocationDTOs      { get; set; }
    public ICollection<DrugPrescriptionDTO>?    DrugPrescriptionDTOs    { get; set; }
    public ICollection<AnalysisTestDTO>?        AnalysisTestDTOs        { get; set; }
}
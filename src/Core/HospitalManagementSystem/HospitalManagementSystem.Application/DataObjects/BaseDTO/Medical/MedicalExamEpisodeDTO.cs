namespace HospitalManagementSystem.Application;

public class MedicalExamEpisodeDTO : DTOBase
{
    public DateTime     DateTakeExam    { get; set; }       //ngày khám bệnh ?????
    public DateTime     DateReExam      { get; set; }       //ngày tái khám
    public int          LineNumber      { get; set; }       //bốc số ?????
    public DateTime     RecordDay       { get; set; }       //ngày ghi sổ ?????
    public int          TotalPrice      { get; set; }       //thành tiền

    public MedicalExamDTO          MedicalExamDTO         { get; set; } = default!;
    public ReExamAppointmentDTO?   ReExamAppointmentDTO   { get; set; }

    public virtual ICollection<AssignmentHistoryDTO>    AssignmentHistoryDTOs   { get; set; } = new HashSet<AssignmentHistoryDTO>();
    public virtual ICollection<DiagnosisDTO>            DiagnosisDTOs           { get; set; } = new HashSet<DiagnosisDTO>();
    public virtual ICollection<RoomAllocationDTO>       RoomAllocationDTOs      { get; set; } = new HashSet<RoomAllocationDTO>();
    public virtual ICollection<DrugPrescriptionDTO>     DrugPrescriptionDTOs    { get; set; } = new HashSet<DrugPrescriptionDTO>();
    public virtual ICollection<AnalysisTestDTO>         AnalysisTestDTOs        { get; set; } = new HashSet<AnalysisTestDTO>();
}
namespace HospitalManagementSystem.Application;

public record MedicalExamEpisodeDTO : DTOBase
{
    public DateTime     DateTakeExam    { get; init; }       //ngày khám bệnh ?????
    public DateTime     DateReExam      { get; init; }       //ngày tái khám
    public int          LineNumber      { get; init; }       //bốc số ?????
    public DateTime     RecordDay       { get; init; }       //ngày ghi sổ ?????
    public int          TotalPrice      { get; init; }       //thành tiền
}
namespace HospitalManagementSystem.Blazor;

public record HomeBillWithServicesModel : InputBillDTO
{
    public ICollection<OutputMedicalServiceDTO>    Services    { get; set; } = default!;
    public ICollection<DrugWithAmount>      Drugs       { get; set; } = default!;
    public ICollection<RoomWithTime>        Rooms       { get; set; } = default!;
    public OutputMedicalExamEpisodeDTO      Episode     { get; set; } = default!;
}
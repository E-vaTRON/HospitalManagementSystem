namespace HospitalManagementSystem.Blazor;

public record BillWithUserAndServicesModel : InputBillDTO
{
    public OutputUserDTO? User { get; set; } = default!;
    public ICollection<OutputMedicalServiceDTO>    Services    { get; set; } = default!;
    public ICollection<DrugWithAmount>      Drugs       { get; set; } = default!;
    public ICollection<RoomWithTime>        Rooms       { get; set; } = default!;
    public OutputMedicalExamEpisodeDTO      Episode     { get; set; } = default!;
}
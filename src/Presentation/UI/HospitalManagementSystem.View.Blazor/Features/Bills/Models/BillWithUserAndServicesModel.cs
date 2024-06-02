namespace HospitalManagementSystem.Blazor;

public record BillWithUserAndServicesModel : InputBillDTO
{
    public OutputUserDTO? User { get; set; } = default!;
    public ICollection<OutputServiceDTO>    Services    { get; set; } = default!;
    public ICollection<DrugWithAmount>      Drugs       { get; set; } = default!;
    public ICollection<RoomWithTime>        Rooms       { get; set; } = default!;
    public OutputMedicalExamEpisodeDTO      Episode     { get; set; } = default!;
}

public record DrugWithAmount : OutputDrugDTO
{
    public int Amount { get; set; }
}

public record RoomWithTime : OutputRoomDTO
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
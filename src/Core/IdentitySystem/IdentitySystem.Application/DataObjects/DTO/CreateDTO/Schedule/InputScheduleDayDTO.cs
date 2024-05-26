namespace IdentitySystem.Application;

public record InputScheduleDayDTO : ScheduleDayDTO
{
    public string? UserDTOId { get; init; }
}

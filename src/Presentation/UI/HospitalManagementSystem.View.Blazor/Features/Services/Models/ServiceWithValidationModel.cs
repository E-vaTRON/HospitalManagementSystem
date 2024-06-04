namespace HospitalManagementSystem.Blazor;

public record ServiceWithValidationModel : InputServiceDTO
{
    public bool IsServiceNameValid { get; set; }
    public bool IsNameNotDuplicated { get; set; }
    public bool IsPriceValid { get; set; }
}

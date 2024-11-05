namespace HospitalManagementSystem.Blazor;

public record ServiceWithValidationModel : InputMedicalServiceDTO
{
    public bool IsServiceNameValid { get; set; }
    public bool IsNameNotDuplicated { get; set; }
    public bool IsPriceValid { get; set; }
}

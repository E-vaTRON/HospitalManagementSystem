namespace HospitalManagementSystem.Blazor;

public record HomeServiceWithAmountModel : InputMedicalServiceDTO
{
    public int AnalysisTextAmount { get; set; }
}

namespace HospitalManagementSystem.Blazor;

public record HomeServiceWithAmountModel : InputServiceDTO
{
    public int AnalysisTextAmount { get; set; }
}

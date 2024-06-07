namespace HospitalManagementSystem.Blazor;

public class BadRequestException : Exception
{
    public IDictionary<string, string[]> ValidationErrors { get; set; }

    public BadRequestException(string message) : base(message)
    {
        ValidationErrors = new Dictionary<string, string[]>();
    }

    public BadRequestException(string message, FluentValidation.Results.ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
}

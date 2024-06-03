namespace HospitalManagementSystem.Blazor;

public record UserWithValidationModel : InputUserDTO
{
    public bool IsFirstNameValid    { get; set; }
    public bool IsLastNameValid     { get; set; }
    public bool IsPhoneNumberValid  { get; set; }
    public bool IsEmailValid        { get; set; }
}

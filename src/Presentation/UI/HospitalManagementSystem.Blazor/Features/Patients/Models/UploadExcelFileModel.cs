namespace HospitalManagementSystem.Blazor;

public class UploadExcelFileModel
{
    public bool         IsContentValid { get; set; }
    public IFormFile?   AttachedFile { get; set; }

    public IEnumerable<UserWithValidationModel> Users { get; set; } = new List<UserWithValidationModel>();
}

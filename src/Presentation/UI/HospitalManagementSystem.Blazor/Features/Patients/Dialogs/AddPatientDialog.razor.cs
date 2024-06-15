namespace HospitalManagementSystem.Blazor;

public partial class AddPatientDialog : IDialogContentComponent<UserWithValidationModel>
{
    #region [ Properties - Parameter ]
    [Parameter]
    public UserWithValidationModel Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog? Dialog { get; set; }
    #endregion

    string UploadError = string.Empty;

    private DateTime? SelectedDate = DateTime.Today;

    //FluentInputFileEventArgs[] Files = Array.Empty<FluentInputFileEventArgs>();

    //void OnCompleted(IEnumerable<FluentInputFileEventArgs> files)
    //{
    //    var file = files.FirstOrDefault();
    //    if (file == null)
    //    {
    //        // No file was uploaded
    //        UploadError = "No file was uploaded.";
    //        return;
    //    }
    //    else if (!file.ContentType.StartsWith("image/"))
    //    {
    //        // The uploaded file is not an image
    //        UploadError = "The uploaded file is not an image.";
    //        return;
    //    }
    //    Files = files.ToArray();

    //    Content.AvatarFiles = Files
    //        .Where(file => file.LocalFile != null || file.Buffer != null || file.Stream != null)
    //        .Select(file =>
    //        {
    //            IFormFile formFile;

    //            if (file.LocalFile != null)
    //            {
    //                // Create an instance of FormFile using LocalFile
    //                formFile = new FormFile(
    //                    file.LocalFile.OpenRead(),
    //                    0,
    //                    file.LocalFile.Length,
    //                    file.Name, // Set the actual file name
    //                    file.Name)
    //                {
    //                    Headers = new HeaderDictionary(),
    //                    ContentType = file.ContentType // Set the correct content type
    //                };
    //            }
    //            else if (file.Buffer != null)
    //            {
    //                // Create an instance of FormFile using Buffer
    //                formFile = new FormFile(
    //                    new MemoryStream(file.Buffer.Data),
    //                    0,
    //                    file.Buffer.Data.Length,
    //                    file.Name, // Set the actual file name
    //                    file.Name)
    //                {
    //                    Headers = new HeaderDictionary(),
    //                    ContentType = file.ContentType // Set the correct content type
    //                };
    //            }
    //            else if (file.Stream != null)
    //            {
    //                // Create an instance of FormFile using Stream
    //                formFile = new FormFile(
    //                    file.Stream,
    //                    0,
    //                    file.Stream.Length,
    //                    file.Name, // Set the actual file name
    //                    file.Name)
    //                {
    //                    Headers = new HeaderDictionary(),
    //                    ContentType = file.ContentType // Set the correct content type
    //                };
    //            }
    //            else
    //            {
    //                throw new InvalidOperationException("Unsupported upload mode");
    //            }

    //            return formFile;
    //        })
    //        .ToArray();
    //    UploadError = string.Empty;
    //}

    //void OnError(FluentInputFileEventArgs file)
    //{
    //}

    #region [ Methods ]
    private void HandleDateChange(DateTime? newDate)
    {
        if (!newDate.HasValue)
            return;

        SelectedDate = newDate.Value;
        Content.CreatedOn = newDate.Value;
    }

    #region [ Validate ]
    private void ValidateAndSetIsFirstNameValid()
    {
        // Use regex pattern for first name validation
        string firstNamePattern = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        Content.IsFirstNameValid = Regex.IsMatch(Content.FirstName ?? "", firstNamePattern);
    }

    private void ValidateAndSetIsLastNameValid()
    {
        // Use regex pattern for last name validation
        string lastNamePattern = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        Content.IsLastNameValid = Regex.IsMatch(Content.LastName ?? "", lastNamePattern);
    }

    private void ValidateAndSetIsPhoneNumberValid()
    {
        // Use regex pattern for phone number validation
        string phonePattern = @"^\+?\d{1,4}?\s?\d{6,}$";
        Content.IsPhoneNumberValid = Regex.IsMatch(Content.PhoneNumber ?? "", phonePattern);
    }

    private void ValidateAndSetIsEmailValid()
    {
        // Use regex pattern for email validation
        string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        Content.IsEmailValid = Regex.IsMatch(Content.Email ?? "", emailPattern);
    }

    private void ValidateAccount()
    {
        ValidateAndSetIsFirstNameValid();
        ValidateAndSetIsLastNameValid();
        ValidateAndSetIsPhoneNumberValid();
        ValidateAndSetIsEmailValid();

        //if (!string.IsNullOrEmpty(Content.MiddleName) || !string.IsNullOrWhiteSpace(Content.MiddleName))
        //    ValidateAndSetIsMiddleNameValid();
        //else Content.IsMiddleNameValid = true;

        if (Content.IsFirstNameValid
            && Content.IsLastNameValid
            && Content.IsPhoneNumberValid
            && Content.IsEmailValid)
            Dialog!.TogglePrimaryActionButton(true);
    }
    #endregion
    #endregion
}

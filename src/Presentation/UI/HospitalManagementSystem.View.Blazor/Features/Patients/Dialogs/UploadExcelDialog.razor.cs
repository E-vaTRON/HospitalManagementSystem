namespace HospitalManagementSystem.Blazor;

public partial class UploadExcelDialog : IDialogContentComponent<UploadExcelFileModel>
{
    #region [ Properties - Parameter ]
    [Inject]
    protected ISServiceContext ISContext { get; set; }

    [Inject]
    protected IExcelService ExcelService { get; set; }
    #endregion

    #region [ Properties - Parameter ]
    [Parameter]
    public UploadExcelFileModel Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog? Dialog { get; set; }
    #endregion

    string UploadError = string.Empty;

    FluentInputFileEventArgs[] Files = Array.Empty<FluentInputFileEventArgs>();

    #region [ CTor ]
    public UploadExcelDialog()
    { 
    }
    #endregion

    async Task OnCompleted(IEnumerable<FluentInputFileEventArgs> files)
    {
        UploadError = string.Empty;
        var currentUsers = ISContext.Users.FindAll().ToList();

        var file = files.FirstOrDefault();
        if (file == null)
        {
            // No file was uploaded
            UploadError = "No file was uploaded.";
            return;
        }
        else if (!file.ContentType.Equals("application/vnd.ms-excel") && !file.ContentType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
        {
            // The uploaded file is not an image
            UploadError = "The uploaded file is not an excel file.";
            return;
        }

        IFormFile formFile;

        if (file.LocalFile != null)
        {
            // Create an instance of FormFile using LocalFile
            formFile = new FormFile(
                file.LocalFile.OpenRead(),
                0,
                file.LocalFile.Length,
                Path.GetFileNameWithoutExtension(file.Name), // Set the actual file name
                file.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = file.ContentType // Set the correct content type
            };
        }
        else if (file.Buffer != null)
        {
            // Create an instance of FormFile using Buffer
            formFile = new FormFile(
                new MemoryStream(file.Buffer.Data),
                0,
                file.Buffer.Data.Length,
                Path.GetFileNameWithoutExtension(file.Name),
                file.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = file.ContentType // Set the correct content type
            };
        }
        else if (file.Stream != null)
        {
            // Create an instance of FormFile using Stream
            formFile = new FormFile(
                file.Stream,
                0,
                file.Stream.Length,
                Path.GetFileNameWithoutExtension(file.Name),
                file.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = file.ContentType // Set the correct content type
            };
        }
        else
        {
            throw new InvalidOperationException("Unsupported upload mode");
        }

        if (formFile is null)
        {
            return;
        }

        Content.AttachedFile = formFile;

        var dataTable = await ExcelService.GetDataTableAsync(Content.AttachedFile);
        var datas = new List<UserWithValidationModel>();
        var rows = dataTable?.Rows;
        for (int i = 0; i < rows?.Count; i++)
        {
            var row = rows[i];
            string[] formats =
            {
                "yyyy-MM-dd",
                "M/d/yyyy",
                "dd/MM/yy",
                "M/dd/yyyy HH:mm:ss tt",
                "MM/dd/yyyy HH:mm:ss",
                "dd-MMM-yyyy",
                "yyyy-MM-dd HH:mm:ss",
                "yyyy-MM-dd HH:mm",
            };
            var username = row["User Name"]?.ToString();
            var email = row["Email"]?.ToString();

            if (currentUsers.Any(x => x.UserName == username))
            {
                UploadError = $"Data in file is invalid, Duplicate Username At row: {i + 2}";
                break;
            }

            if (currentUsers.Any(x => x.Email == email))
            {
                UploadError = $"Data in file is invalid, Duplicate Email At row: {i + 2}";
                break;
            }

            var userNameValid = this.ValidateAndSetIsUsernameValid(row["User Name"]?.ToString());
            var firstNameValid = this.ValidateAndSetIsFirstNameValid(row["First Name"]?.ToString());
            var lastNameValid = this.ValidateAndSetIsLastNameValid(row["Last Name"]?.ToString());
            var emailValid = this.ValidateAndSetIsEmailValid(row["Email"]?.ToString());
            var phoneNumberValid = this.ValidateAndSetIsPhoneNumberValid(row["Phone number"]?.ToString());
            var canParseDate = DateTime.TryParseExact(row["Join Date"]?.ToString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var createdOn);
            var address = row["Address"]?.ToString();
            if (!firstNameValid || !lastNameValid || !emailValid || !phoneNumberValid || !canParseDate)
            {
                UploadError = $"Data in file is invalid, At row: {i + 2}";
                break;
            }

            datas.Add(new UserWithValidationModel
            {
                UserName = username,
                Email = email,
                FirstName = row["First Name"]?.ToString()!,
                LastName = row["Last Name"]?.ToString()!,
                PhoneNumber = row["Phone number"]?.ToString(),
                CreatedOn = createdOn,
                Address = address
            });
        }
        Content.Users = datas;
    }

    void OnError(FluentInputFileEventArgs file)
    {
    }

    #region [ Validation ]
    private bool ValidateAndSetIsFirstNameValid(string? value)
    {
        // Use regex pattern for first name validation
        string firstNamePattern = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        return Regex.IsMatch(value ?? "", firstNamePattern);
    }

    bool ValidateAndSetIsUsernameValid(string? value)
    {
        string pattern = @"^[-_a-zA-Z0-9]+(\.[-_a-zA-Z0-9]+)*$";
        return Regex.IsMatch(value ?? "", pattern);
    }

    bool ValidateAndSetIsMiddleNameValid(string? value)
    {
        // Use regex pattern for first name validation
        string firstNamePattern = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        return Regex.IsMatch(value ?? "", firstNamePattern);
    }

    bool ValidateAndSetIsLastNameValid(string? value)
    {
        // Use regex pattern for last name validation
        string lastNamePattern = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        return Regex.IsMatch(value ?? "", lastNamePattern);
    }

    bool ValidateAndSetIsPhoneNumberValid(string? value)
    {
        // Use regex pattern for phone number validation
        string phonePattern = @"^\+?\d{1,4}?\s?\d{6,}$";
        return Regex.IsMatch(value ?? "", phonePattern);
    }

    bool ValidateAndSetIsEmailValid(string? value)
    {
        // Use regex pattern for email validation
        string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        return Regex.IsMatch(value ?? "", emailPattern);
    }
    #endregion
}

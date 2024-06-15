namespace HospitalManagementSystem.Blazor;

public partial class EditPatientDialog : IDialogContentComponent<UserWithPaymentModel>
{
    [Parameter]
    public UserWithPaymentModel Content { get; set; } = default!;

    private DateTime? SelectedDate = DateTime.Today;

    JustifyContent Justification = JustifyContent.FlexStart;

    //FluentInputFileEventArgs[] Files = Array.Empty<FluentInputFileEventArgs>();

    //void OnCompleted(IEnumerable<FluentInputFileEventArgs> files)
    //{
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
    //}

    //void OnError(FluentInputFileEventArgs file) { }

    private void HandleDateChange(DateTime? newDate)
    {
        if (!newDate.HasValue)
            return;

        SelectedDate = newDate.Value;
        Content.CreatedOn = newDate.Value;
    }
}

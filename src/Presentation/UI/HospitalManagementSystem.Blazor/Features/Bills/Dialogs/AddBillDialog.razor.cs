namespace HospitalManagementSystem.Blazor;

public partial class AddBillDialog : IDialogContentComponent<BillWithSelectionModel>
{
    #region [ Properties - Inject ]
    //[Inject]
    //protected ISServiceContext Context { get; set; } 
    #endregion

    #region [ Properties - Parameter ]
    [Parameter]
    public BillWithSelectionModel Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog? Dialog { get; set; }
    #endregion

    #region [ Field ]
    private DateTime? selectedDate = DateTime.Now;

    public FluentAutocomplete<OutputUserDTO> Users { get; set; } = default!;
    #endregion

    string errorMessage = string.Empty;
     
    void OnSearch(OptionsSearchEventArgs<OutputUserDTO> search)
    {
        search.Items = Content.UserSelectList!.Where(x => x.LastName
                                              .Contains(search.Text, StringComparison.OrdinalIgnoreCase))
                                              .OrderBy(x => x.LastName);
    }


    void OnAutocompleteValueChanged(string selectedOptions)
    {
        Content.SelectedUser = Content.UserSelectList!.FirstOrDefault(user =>
                               (user.FirstName + " " + user.LastName).Equals(selectedOptions, StringComparison.OrdinalIgnoreCase));
    }

    //async Task CheckUserGuid()
    //{
    //    errorMessage = string.Empty;
    //    Content.SelectedUser = null!;

    //    if (string.IsNullOrEmpty(userGuid))
    //    {
    //        errorMessage = "Please insert user ID";
    //        return;
    //    }

    //    isLoading = true;
    //    var userInfo = await UsersRepository.FindByGuidAsync(userGuid);
    //    if (userInfo is null)
    //    {
    //        errorMessage = "No user found please check your ID again";
    //        isLoading = false;
    //        return;
    //    }

    //    Content.SelectedUser = userInfo;

    //    ValidateUserGuid();

    //    isLoading = false;
    //}

    private void HandleDatePickerValueChanged(DateTime? newDate)
    {
        if (newDate.HasValue)
        {
            Content = Content with { Deadline = newDate.Value };
            selectedDate = newDate.Value;

            ValidateDeadline();
        }

    }

    void ValidateUserGuid()
    {
        if (Content.SelectedUser is not null)
            Content!.IsUserIdValid = true;
        else
        {
            Content.SelectedUser = null!;
        }
    }

    void ValidateDeadline()
    {
        if (Content.Deadline != default(DateTime))
            Content.IsDeadlineValid = true;
    }

    void ValidateBill()
    {
        ValidateUserGuid();
        ValidateDeadline();

        if (Content.IsUserIdValid && Content.IsDeadlineValid)
            Dialog!.TogglePrimaryActionButton(true);
    }
}

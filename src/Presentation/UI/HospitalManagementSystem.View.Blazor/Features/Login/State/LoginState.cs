namespace HospitalManagementSystem.Blazor;

public class LoginState : StateBase
{
    #region [ Fields ]
    private LoginModel? loginMode;
    private PhoneNumberLoginRecord? phoneNumberLoginModel;
    private EmailLoginRecord? emailLoginModel;
    private UserNameLoginRecord? userNameLoginModel;
    private bool isBusy;
    #endregion

    #region [ CTor ]
    public LoginState()
    {
    }
    #endregion

    #region [ Properties ]
    public LoginModel LoginMode
    {
        get { return this.loginMode!; }
        set { this.SetProperty(ref this.loginMode, value); }
    }

    public PhoneNumberLoginRecord PhoneNumberLoginModel
    {
        get { return this.phoneNumberLoginModel!; }
        set { this.SetProperty(ref this.phoneNumberLoginModel, value); }
    }

    public EmailLoginRecord EmailLoginModel
    {
        get { return this.emailLoginModel!; }
        set { this.SetProperty(ref this.emailLoginModel, value); }
    }

    public UserNameLoginRecord UserNameLoginModel
    {
        get { return this.userNameLoginModel!; }
        set { this.SetProperty(ref this.userNameLoginModel, value); }
    }

    public bool IsBusy
    {
        get { return this.isBusy; }
        set { this.SetProperty(ref this.isBusy, value); }
    }
    #endregion
}

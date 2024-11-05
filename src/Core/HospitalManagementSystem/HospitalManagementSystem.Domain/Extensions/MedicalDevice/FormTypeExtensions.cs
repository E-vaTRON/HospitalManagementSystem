namespace HospitalManagementSystem.Domain;

public static class FormTypeExtensions
{
    #region [ Private Methods ]
    private static FormType AddMedicalDeviceForm(this FormType formType, MedicalDeviceForm medicalDeviceForm)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(medicalDeviceForm));

        if (formType.MedicalDeviceForms.Any(x => x.Id == medicalDeviceForm.Id))
        {
            return formType;
        }

        medicalDeviceForm.FormTypeId = formType.Id;
        medicalDeviceForm.FormType = formType;
        formType.MedicalDeviceForms.Add(medicalDeviceForm);
        return formType;
    }
    #endregion

    #region [ Public Methods ]
    public static FormType AddMedicalDeviceForm(this FormType formType)
    {
        return formType.AddMedicalDeviceForm(MedicalDeviceFormFactory.Create());
    }


    public static FormType RemoveRelated(this FormType formType)
    {
        formType.MedicalDeviceForms.Clear();
        return formType;
    }
    #endregion
}

namespace HospitalManagementSystem.Domain;

public static class MedicalDeviceFormExtensions
{
    #region [ Private Methods ]
    private static MedicalDevice AddMedicalDeviceForm(this MedicalDevice medicalDevice, MedicalDeviceForm medicalDeviceForm)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(medicalDeviceForm));

        if (medicalDevice.MedicalDeviceForms.Any(x => x.Id == medicalDeviceForm.Id))
        {
            return medicalDevice;
        }

        medicalDeviceForm.MedicalDeviceId = medicalDevice.Id;
        medicalDeviceForm.MedicalDevice = medicalDevice;
        medicalDevice.MedicalDeviceForms.Add(medicalDeviceForm);
        return medicalDevice;
    }

    private static MedicalDevice AddMedicalDeviceFormWithFormType(this MedicalDevice medicalDevice, FormType formType, MedicalDeviceForm medicalDeviceForm)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(medicalDeviceForm));

        if (medicalDevice.MedicalDeviceForms.Any(x => x.Id == medicalDeviceForm.Id))
        {
            return medicalDevice;
        }

        medicalDeviceForm.MedicalDeviceId = medicalDevice.Id;
        medicalDeviceForm.MedicalDevice = medicalDevice;
        medicalDeviceForm.FormTypeId = formType.Id;
        medicalDeviceForm.FormType = formType;
        medicalDevice.MedicalDeviceForms.Add(medicalDeviceForm);
        formType.MedicalDeviceForms.Add(medicalDeviceForm);
        return medicalDevice;
    }
    #endregion

    #region [ Public Methods ]
    public static MedicalDevice AddMedicalDeviceForm(this MedicalDevice medicalDevice)
    {
        return medicalDevice.AddMedicalDeviceForm(MedicalDeviceFormFactory.Create());
    }

    public static MedicalDevice AddMedicalDeviceFormWithFormType(this MedicalDevice medicalDevice, FormType formType)
    {
        return medicalDevice.AddMedicalDeviceFormWithFormType(formType, MedicalDeviceFormFactory.Create());
    }

    public static MedicalDeviceForm RemoveRelated(this MedicalDeviceForm medicalDeviceForm)
    {
        medicalDeviceForm.MedicalDevice = null!;
        medicalDeviceForm.FormType = null!;
        return medicalDeviceForm;
    }
    #endregion
}

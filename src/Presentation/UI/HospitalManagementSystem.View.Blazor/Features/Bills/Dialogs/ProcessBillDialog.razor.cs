namespace HospitalManagementSystem.Blazor;

public partial class ProcessBillDialog : IDialogContentComponent<BillWithUserAndServicesModel>
{
    #region [ Properties - Parameter ]
    [Parameter]
    public BillWithUserAndServicesModel Content { get; set; } = default!;
    #endregion

    #region [ Field ]
    decimal amount;
    string userGuid = string.Empty;
    string amountColor = string.Empty;
    string amountMessage = string.Empty;
    #endregion

    #region [ Price - Calculation ]
    private string PricePerBill()
    {
        if (Content != null)
        {
            var totalAmount = CalculateAmountPerBill();

            return totalAmount.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));
        }

        return "P0.00";
    }

    private decimal CalculateAmountPerBill()
    {
        decimal totalAmount = 0;

        foreach (var analysisTest in Content.Episode.AnalysisTestDTOs!)
        {
            if (analysisTest.DeviceServiceDTO != null)
            {
                totalAmount += analysisTest.DeviceServiceDTO.ServiceDTO!.ServicePrice;
            }
        }

        // Calculate based on drug prescriptions
        foreach (var drugPrescription in Content.Episode.DrugPrescriptionDTOs!)
        {
            if (drugPrescription.DrugInventoryDTO != null)
            {
                totalAmount += drugPrescription.DrugInventoryDTO.DrugDTO!.UnitPrice * drugPrescription.Amount;
            }
        }

        // Calculate based on room allocations (if applicable)
        foreach (var roomAllocation in Content.Episode.RoomAllocationDTOs!)
        {
            if (roomAllocation.RoomDTO != null)
            {
                totalAmount += roomAllocation.RoomDTO.PricePerHour * (roomAllocation.EndTime - roomAllocation.StartTime).Hours;
            }
        }

        return totalAmount;
    }

    private void CheckBillPayment(ChangeEventArgs e)
    {
        if (decimal.TryParse(e.Value!.ToString(), out decimal userInput))
        {
            decimal totalAmount = CalculateAmountPerBill();

            if (userInput < totalAmount)
            {
                var underPaidAmount = totalAmount - userInput;
                amountColor = "red";
                amountMessage = $"Underpaid: {underPaidAmount}";
                Content = Content with
                {
                    ExcessAmount = default,
                    UnderPaidAmount = underPaidAmount
                };

            }
            else if (userInput > totalAmount)
            {
                var excessAmount = userInput - totalAmount;
                amountColor = "#5cd54a";
                amountMessage = $"Excess: {excessAmount}";
                Content = Content with
                {
                    UnderPaidAmount = default,
                    ExcessAmount = excessAmount
                };
            }
            else
            {
                amountColor = "#0cffbb";
                amountMessage = "Payment is exact";
                Content = Content with
                {
                    ExcessAmount = default,
                    UnderPaidAmount = default
                };
            }
        }
        else
        {
            // Handle invalid input (non-decimal)
            Console.WriteLine("Invalid input");
        }
    }
    #endregion
}

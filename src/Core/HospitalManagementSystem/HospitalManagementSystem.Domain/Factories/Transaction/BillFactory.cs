namespace HospitalManagementSystem.Domain;

public static class BillFactory
{
    public static Bill Create()
    {
        return new Bill();
    }

    public static Bill Create(DateTime deadline, DateTime? paidDate, string status,
                decimal totalAmount, decimal excessAmount, decimal underPaidAmount,
                decimal discountAmount, decimal adjustmentAmount, string paymentMethod)
    {
        return new Bill()
        {
            Deadline = deadline,
            PaidDate = paidDate,
            Status = status,
            TotalAmount = totalAmount,
            ExcessAmount = excessAmount,
            UnderPaidAmount = underPaidAmount,
            DiscountAmount = discountAmount,
            AdjustmentAmount = adjustmentAmount,
            PaymentMethod = paymentMethod
        };
    }

    public static Bill Create(string status, decimal totalAmount, decimal excessAmount, decimal underPaidAmount,
        decimal discountAmount, decimal adjustmentAmount, string paymentMethod)
    {
        return new Bill()
        {
            Status = status,
            TotalAmount = totalAmount,
            ExcessAmount = excessAmount,
            UnderPaidAmount = underPaidAmount,
            DiscountAmount = discountAmount,
            AdjustmentAmount = adjustmentAmount,
            PaymentMethod = paymentMethod
        };
    }
}
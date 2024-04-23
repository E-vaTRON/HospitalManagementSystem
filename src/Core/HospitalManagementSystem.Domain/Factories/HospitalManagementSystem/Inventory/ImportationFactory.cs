namespace HospitalManagementSystem.Domain;

public static class ImportationFactory
{
    public static Importation Create()
    {
        return new Importation();
    }

    public static Importation Create(string receiptNumber, string billNumber, DateTime recordDay, int tax, int totalPrice, string company)
    {
        return new Importation()
        {
            ReceiptNumber = receiptNumber,
            Billnumber = billNumber,
            RecordDay = recordDay,
            ReceiptDay = DateTime.Now,
            Tax = tax,
            TotalPrice = totalPrice,
            Company = company
        };
    }

    public static Importation Create(string receiptNumber, string billNumber, DateTime recordDay, DateTime receiptDay, int tax, int totalPrice, string company)
    {
        return new Importation()
        {
            ReceiptNumber = receiptNumber,
            Billnumber = billNumber,
            RecordDay = recordDay,
            ReceiptDay = receiptDay,
            Tax = tax,
            TotalPrice = totalPrice,
            Company = company
        };
    }
}

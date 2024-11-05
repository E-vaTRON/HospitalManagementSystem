namespace HospitalManagementSystem.Domain;

public static class BillExtensions
{
    public static Bill RemoveRelated(this Bill bill)
    {
        bill.MedicalExamEpisode = null!;
        return bill;
    }
}

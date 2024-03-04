﻿namespace HospitalManagementSystem.DataProvider;

public class Transaction : ModelBase
{
    public DateTime     RecordDay       { get; set; }   //ngày ghi sổ
    public long         TotalPrice      { get; set; }   //thành tiền

    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;

    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
}
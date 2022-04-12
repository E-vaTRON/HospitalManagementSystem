using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class PatientTransactionHistory : BaseEntity
    {
        public string InventoryID { get; set; } = string.Empty;
        public DateTime     RecordDay       { get; set; }                       //ngày ghi sổ
        public string       ExamID          { get; set; } = string.Empty;
        public int          Amount          { get; set; }                       //số lượng
        public int          TotalPrice      { get; set; }                       //thành tiền
        public int          PatientID       { get; set; }                       //mã số bệnh nhân


        public Inventory?           Inventory           { get; set; }
        public HistoryMedicalExam?  HistoryMedicalExam  { get; set; }

    }
}

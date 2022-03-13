using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalDataBase.Core.Entities
{
    public class GoodsExportation : BaseEntity
    {
        public string       GoodID          { get; set; } = string.Empty;       //mã hàng
        public DateTime     RecordDay       { get; set; }                       //ngày ghi sổ
        public int          InventoryID     { get; set; }                       //mã kho
        public string       ExamID          { get; set; } = string.Empty;
        public int          Amount          { get; set; }                       //số lượng
        public int          TotalPrice      { get; set; }                       //thành tiền
        public int          PatientID       { get; set; }                       //mã số bệnh nhân


        public Inventory?           Inventory           { get; set; }
        public HistoryMedicalExam?  HistoryMedicalExam  { get; set; }

    }
}

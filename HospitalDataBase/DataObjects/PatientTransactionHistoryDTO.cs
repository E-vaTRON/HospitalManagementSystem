using System;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<PatientTransactionHistoryDTO>))]
    public class PatientTransactionHistoryDTO :BaseDTO
    {
        public string   GoodID          { get; set; } = string.Empty;       //mã hàng
        public string   RecordDay       { get; set; } = string.Empty;       //ngày ghi sổ
        public int      InventoryID     { get; set; }                       //Mã kho
        public string   ExamID          { get; set; } = string.Empty;
        public int      Amount          { get; set; }                       //số lượng
        public int      TotalPrice      { get; set; }                       //thành tiền
        public int      PatientID       { get; set; }                       //mã số bệnh nhân
    }
}

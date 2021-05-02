using System;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<GoodsExportationDTO>))]
    public class GoodsExportationDTO :BaseDTO
    {
        public string RecordDay { get; set; }           //ngày ghi sổ
        public string GoodID { get; set; }                //mã hàng
        public int InventoryID { get; set; }
        public string ExamID { get; set; }
        public string ShipmentID { get; set; }            //số lô
        public string ExpiryDate { get; set; }          //hạn dùng
        public int Amount { get; set; }                   //số lượng
        public int TotalPrice { get; set; }               //thành tiền
        public int PatientID { get; set; }                //mã số bệnh nhân
        public string PatientName { get; set; }           //tên bệnh nhân
        public string StorageID { get; set; }             //mã kho
    }
}

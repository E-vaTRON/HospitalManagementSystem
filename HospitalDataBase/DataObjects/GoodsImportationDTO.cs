using System;
using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;


namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<GoodsImportationDTO>))]
    public class GoodsImportationDTO : BaseDTO
    {
        public int InventoryID { get; set; }
        public string ReceiptID { get; set; } = string.Empty;           //số chứng từ
        public string BillID { get; set; } = string.Empty;              //số hóa đơn
        public string RecordDay { get; set; } = string.Empty;           //ngày ghi sổ
        public string ReceiptDay { get; set; } = string.Empty;          //ngày chứng từ
        public string GoodID { get; set; } = string.Empty;              //mã hàng
        public string ShipmentID { get; set; } = string.Empty;          //số lô
        public string ExpiryDate { get; set; } = string.Empty;          //hạng dùng
        public int Amout { get; set; }                                  //số lượng
        public int Tax { get; set; }                                    //thuế VAT
        public int TotalPrice { get; set; }                             //thành tiền
        public string Company { get; set; } = string.Empty;             //nhà cung cấp
        public string StorageID { get; set; } = string.Empty;           //mã kho

    }
}

using System;


namespace HospitalDataBase.Core.Entities
{
    public class GoodsImportation : BaseEntity
    {
        public int InventoryID { get; set; }
        public string ReceiptID { get; set; } = string.Empty;              //số chứng từ
        public string BillID { get; set; } = string.Empty;                //số hóa đơn
        public DateTime RecordDay { get; set; }            //ngày ghi sổ
        public DateTime ReceiptDay { get; set; }           //ngày chứng từ
        public string GoodID { get; set; } = string.Empty;                //mã hàng
        public string ShipmentID { get; set; } = string.Empty;            //số lô
        public DateTime ExpiryDate { get; set; }           //hạng dùng
        public int Amout { get; set; }                     //số lượng
        public int Tax { get; set; }                       //thuế VAT
        public int TotalPrice { get; set; }                //thành tiền
        public string Company { get; set; } = string.Empty;               //nhà cung cấp
        public string StorageID { get; set; } = string.Empty;             //mã kho

        public Inventory? Inventory { get; set; }
    }
}

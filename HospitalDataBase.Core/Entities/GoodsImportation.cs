using System;


namespace HospitalDataBase.Core.Entities
{
    public class GoodsImportation : BaseEntity
    {
        public string ReceiptID { get; set; }              //số chứng từ
        public string BillID { get; set; }                 //số hóa đơn
        public DateTime RecordDay { get; set; }            //ngày ghi sổ
        public DateTime ReceiptDay { get; set; }           //ngày chứng từ
        public string GoodID { get; set; }                 //mã hàng
        public string ShipmentID { get; set; }             //số lô
        public DateTime ExpiryDate { get; set; }           //hạng dùng
        public int Amout { get; set; }                     //số lượng
        public int Tax { get; set; }                       //thuế VAT
        public int TotalPrice { get; set; }                //thành tiền
        public string Company { get; set; }                //nhà cung cấp
        public string StorageID { get; set; }              //mã kho

        public Drug Drug { get; set; }
    }
}

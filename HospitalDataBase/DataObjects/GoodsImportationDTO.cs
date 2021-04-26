using System;


namespace HospitalDataBase.DataObjects
{
    public class GoodsImportationDTO : BaseDTO
    {
        public string ReceiptID { get; set; }              //số chứng từ
        public string BillID { get; set; }                 //số hóa đơn
        public string RecordDay { get; set; }              //ngày ghi sổ
        public string ReceiptDay { get; set; }             //ngày chứng từ
        public string GoodID { get; set; }                 //mã hàng
        public string ShipmentID { get; set; }             //số lô
        public string ExpiryDate { get; set; }             //hạng dùng
        public int Amout { get; set; }                     //số lượng
        public int Tax { get; set; }                       //thuế VAT
        public int TotalPrice { get; set; }                //thành tiền
        public string Company { get; set; }                //nhà cung cấp
        public string StorageID { get; set; }              //mã kho

    }
}

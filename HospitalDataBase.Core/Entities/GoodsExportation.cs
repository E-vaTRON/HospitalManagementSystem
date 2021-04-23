using System;

namespace HospitalDataBase.Core.Entities
{
    public class GoodsExportation : BaseEntity
    {
        public DateTime RecordDay { get; set; }           //ngày ghi sổ
        public string GoodID { get; set; }                //mã hàng
        public string ShipmentID { get; set; }            //số lô
        public DateTime ExpiryDate { get; set; }          //hạn dùng
        public int Amount { get; set; }                   //số lượng
        public int TotalPrice { get; set; }               //thành tiền
        public int PatientID { get; set; }                //mã số bệnh nhân
        public string PatientName { get; set; }           //tên bệnh nhân
        public string StorageID { get; set; }             //mã kho

        public Drug Drug { get; set; }
    }
}

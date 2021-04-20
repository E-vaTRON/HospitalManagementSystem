using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class GoodsImportation
    {
        public Guid ID { get; set; }
        public string receiptID { get; set; }              //số chứng từ
        public string billID { get; set; }                 //số hóa đơn
        public DateTime recordDay { get; set; }            //ngày ghi sổ
        public DateTime receiptDay { get; set; }           //ngày chứng từ
        public string goodID { get; set; }                 //mã hàng
        public string shipmentID { get; set; }             //số lô
        public DateTime expiryDate { get; set; }           //hạng dùng
        public int amout { get; set; }                     //số lượng
        public int tax { get; set; }                       //thuế VAT
        public int totalPrice { get; set; }                //thành tiền
        public string company { get; set; }                //nhà cung cấp
        public string storageID { get; set; }              //mã kho

        public Drug Drug { get; set; }
    }
}

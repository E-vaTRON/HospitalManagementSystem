using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class GoodsExportation
    {
        public DateTime recordDay { get; set; }           //ngày ghi sổ
        public string goodID { get; set; }                //mã hàng
        public string shipmentID { get; set; }            //số lô
        public DateTime expiryDate { get; set; }          //hạn dùng
        public int amount { get; set; }                   //số lượng
        public int totalPrice { get; set; }               //thành tiền
        public int patientID { get; set; }                //mã số bệnh nhân
        public string patientName { get; set; }           //tên bệnh nhân
        public string storageID { get; set; }             //mã kho

        public Drug Drug { get; set; }
    }
}
    
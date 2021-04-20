using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Entities.Entities
{
    public class Inventory
    {
        public string goodID { get; set; }                 //mã hàng
        public string shipmentID { get; set; }             //số lô
        public DateTime expiryDate { get; set; }           //hạng dùng
        public int currentAmount { get; set; }             //số lượng hiện tại

        public Drug Drug { get; set; }
    }
}

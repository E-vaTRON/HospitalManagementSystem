using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalDataBase.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public string GoodID { get; set; }                 //mã hàng
        public string ShipmentID { get; set; }             //số lô
        public DateTime ExpiryDate { get; set; }           //hạng dùng
        public int CurrentAmount { get; set; }             //số lượng hiện tại

        public Drug Drug { get; set; }
    }
}

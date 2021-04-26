using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDataBase.DataObjects
{
    public class InventoryDTO :BaseDTO
    {
        public string GoodID { get; set; }                 //mã hàng
        public string ShipmentID { get; set; }             //số lô
        public string ExpiryDate { get; set; }           //hạng dùng
        public int CurrentAmount { get; set; }             //số lượng hiện tại
    }
}

using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<InventoryDTO>))]
    public class InventoryDTO :BaseDTO
    {
        public string GoodID { get; set; }                 //mã hàng
        public string ShipmentID { get; set; }             //số lô
        public string ExpiryDate { get; set; }           //hạng dùng
        public int CurrentAmount { get; set; }             //số lượng hiện tại
    }
}

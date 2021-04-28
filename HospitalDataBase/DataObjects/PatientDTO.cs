using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalDataBase.DataObjects
{

    [ModelBinder(typeof(MultipleSourcesModelBinder<PatientDTO>))]
    public class PatientDTO : BaseDTO
    {
        public string PatientID { get; set; }
        public string FirstName { get; set; }      //họ
        public string LastName { get; set; }       //tên
        public string DayOfBirth { get; set; }   //ngày sinh
        public int Age { get; set; }               //tuổi
        public bool Sex { get; set; }              //giới tính
        public string Address { get; set; }        //địa chỉ
        public string CardID { get; set; }         //mã thẻ
        public string PnoneNumber { get; set; }    //số điện thoại
    }
}

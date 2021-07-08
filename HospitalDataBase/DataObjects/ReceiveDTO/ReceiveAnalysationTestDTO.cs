using HospitalDataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDataBase.DataObjects.ReceiveDTO
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<ReceiveAnalysationTestDTO>))]
    public class ReceiveAnalysationTestDTO : BaseDTO
    {
        public string? LastName { get; set; }
        public string? Service { get; set; }
        public string DSymptom { get; set; } = string.Empty;           //triệu chứng lâm sàng
        public string DoctorComment { get; set; } = string.Empty;      // chỉ định
    }
}

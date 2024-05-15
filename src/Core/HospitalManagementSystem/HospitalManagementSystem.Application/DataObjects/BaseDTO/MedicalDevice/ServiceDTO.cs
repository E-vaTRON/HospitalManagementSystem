﻿namespace HospitalManagementSystem.Application;

public class ServiceDTO : DTOBase
{
    public string       Name                    { get; set; } = string.Empty;
    public Units        Unit                    { get; set; }                       //đơn vị tính
    public int          UnitPrice               { get; set; }                       //đơn giá
    public int          ServicePrice            { get; set; }                       //giá thu phí
    public int          HealthInsurancePrice    { get; set; }                       //giá bảo hiểm y tế
    public FormTypes    ResultFromType          { get; set; }                       //form kết quả chuẩn đoán

    public virtual ICollection<DeviceServiceDTO>   DeviceServiceDTOs  { get; set; } = new HashSet<DeviceServiceDTO>();
}
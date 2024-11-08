﻿namespace HospitalManagementSystem.Application;

public record MedicalServiceDTO : DTOBase
{
    public string       Name                    { get; init; } = string.Empty;
    public Units        Unit                    { get; init; }                       //đơn vị tính
    public int          UnitPrice               { get; init; }                       //đơn giá
    public int          ServicePrice            { get; init; }                       //giá thu phí
    public int          HealthInsurancePrice    { get; init; }                       //giá bảo hiểm y tế
}

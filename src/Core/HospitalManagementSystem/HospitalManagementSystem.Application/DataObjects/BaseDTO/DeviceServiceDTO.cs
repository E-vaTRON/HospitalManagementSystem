using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Application;
public class DeviceServiceDTO : BaseDTO
{
    public string   DeviceName              { get; set; } = string.Empty;       
    public string   Service                 { get; set; } = string.Empty;
    public string   Unit                    { get; set; } = string.Empty;       
    public int      UnitPrice               { get; set; }                       
    public int      ServicePrice            { get; set; }                       
    public int      HealthInsurancePrice    { get; set; }                       
    public string   ManagementID            { get; set; } = string.Empty;       
    public string   Country                 { get; set; } = string.Empty;        
    public string   SmallID                 { get; set; } = string.Empty;       
    public string   GroupID                 { get; set; } = string.Empty;       
    public int      Min                     { get; set; }                       
    public int      Max                     { get; set; }                       
    public string   ResultFromType          { get; set; } = string.Empty;

    public virtual ICollection<int> 
        Tests { get; set; } = Array.Empty<int>();
}

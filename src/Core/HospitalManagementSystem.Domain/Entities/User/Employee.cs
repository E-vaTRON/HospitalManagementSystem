﻿using HospitalManagementSystem.Domain.Entities.User.UserFunction;

namespace HospitalManagementSystem.Domain;

public class Employee : User
{
    public virtual ICollection<Specialization>      Specializations     { get; set; } = new HashSet<Specialization>();
    public virtual ICollection<EmployeeSchedule>    EmployeeSchedules   { get; set; } = new HashSet<EmployeeSchedule>();
}

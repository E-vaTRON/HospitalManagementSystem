﻿namespace HospitalManagementSystem.Application;

public interface IDataObject : IEntity
{
}

public interface IDataObject<TEId> : IEntity<TEId>
{
}
namespace HospitalManagementSystem.Application;

public interface IDataObject : IEntity
{
}

public interface IDataObject<TDId> : IEntity<TDId>
{
}
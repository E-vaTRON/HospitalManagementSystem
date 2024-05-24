namespace HospitalManagementSystem.Application;

public interface IServiceProviderBase
{
}

public interface IServiceProviderBase<TDto, TDId> : IContractBase<TDto, TDId>
    where TDto : class, IDataObject<TDId>
{
}

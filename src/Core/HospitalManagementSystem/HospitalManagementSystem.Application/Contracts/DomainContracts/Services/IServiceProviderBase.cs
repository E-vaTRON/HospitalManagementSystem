namespace HospitalManagementSystem.Application;

public interface IServiceProviderBase
{
}

public interface IServiceProviderBase<TOutputDto, TInputDto, TDId> : IContractBase<TOutputDto, TInputDto, TDId>
    where TOutputDto : class, IDataObject<TDId>
    where TInputDto : class, IDataObject<TDId>
{
}

namespace IdentitySystem.Application;

public interface IIdentityServiceProviderBase<TOutputDto, TInputDto, TDId> : IIdentityContractBase<TOutputDto, TInputDto, TDId>
    where TOutputDto : class, IDataObject<TDId>
    where TInputDto : class, IDataObject<TDId>
{

}

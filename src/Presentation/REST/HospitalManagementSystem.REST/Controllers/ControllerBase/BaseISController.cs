using ISApplication = IdentitySystem.Application;

namespace HospitalManagementSystem.REST;

//[ApiController]
//[Route("/api/[controller]/[action]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//public class BaseISController<TDto, TDId, TServiceProvider> : ControllerBase
//    where TDto : class, ISApplication.IDataObject<TDId>
//    where TServiceProvider : ISApplication.IServiceProviderBase<TDto, TDId>
//{
//    #region [ Field ]
//    protected TServiceProvider ServiceProvider { get; set; }
//    #endregion

//    #region [ CTor ]
//    public BaseISController(TServiceProvider serviceProvider)
//    {
//        ServiceProvider = serviceProvider;
//    }
//    #endregion
//}

//[ApiController]
//[Route("/api/[controller]/[action]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//public class BaseISController<TDto>(ISApplication.IServiceProviderBase<TDto, string> serviceProvider)
//    : BaseISController<TDto, string, ISApplication.IServiceProviderBase<TDto, string>>(serviceProvider)
//    where TDto : class, ISApplication.IDataObject<string>
//{
//}

//[ApiController]
//[Route("/api/[controller]/[action]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//public class BaseISIntController<TDto>(ISApplication.IServiceProviderBase<TDto, int> serviceProvider)
//    : BaseISController<TDto, int, ISApplication.IServiceProviderBase<TDto, int>>(serviceProvider)
//    where TDto : class, ISApplication.IDataObject<int>
//{
//}
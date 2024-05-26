using HMSApplication = HospitalManagementSystem.Application;

namespace HospitalManagementSystem.REST;

[ApiController]
[Route("/api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BaseHMSController<TOutputDto, TInputDto, TDId, TServiceProvider> : ControllerBase
    where TOutputDto : class, HMSApplication.IDataObject<TDId>
    where TInputDto : class, HMSApplication.IDataObject<TDId>
    where TServiceProvider : HMSApplication.IServiceProviderBase<TOutputDto, TInputDto, TDId>
{
    #region [ Field ]
    protected TServiceProvider ServiceProvider { get; set; }
    #endregion

    #region [ CTor ]
    public BaseHMSController(TServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
    #endregion

    #region [ Methods ]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dtos = await ServiceProvider.FindAllAsync();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(TDId id)
    {
        var dto = await ServiceProvider.FindByIdAsync(id);
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TInputDto dto)
    {
        await ServiceProvider.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(TDId id, TInputDto dto)
    {
        if (!id!.Equals(dto.Id))
        {
            return BadRequest();
        }
        await ServiceProvider.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(TDId id)
    {
        await ServiceProvider.DeleteByIdAsync(id);
        return NoContent();
    }
    #endregion
}

[ApiController]
[Route("/api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BaseHMSController<TOutputDto, TInputDto>(HMSApplication.IServiceProviderBase<TOutputDto, TInputDto, string> serviceProvider) 
    : BaseHMSController<TOutputDto, TInputDto, string, HMSApplication.IServiceProviderBase<TOutputDto, TInputDto, string>>(serviceProvider)
    where TOutputDto : class, HMSApplication.IDataObject<string>
    where TInputDto : class, HMSApplication.IDataObject<string>
{
}
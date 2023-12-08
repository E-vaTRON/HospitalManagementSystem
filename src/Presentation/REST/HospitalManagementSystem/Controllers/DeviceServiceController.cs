namespace HospitalManagementSystem.API;

[Route("api/[controller]/[action]")]
[ApiController]
public class DeviceServiceController : BaseController
{
    private readonly IDeviceServiceRepository _deviceServiceRepository;
    private readonly IAnalyzationTestRepository _analyzationTestRepository;

    public DeviceServiceController(IDeviceServiceRepository deviceServiceRepository, IAnalyzationTestRepository analyzationTestRepository)
    {
        _deviceServiceRepository = deviceServiceRepository;
        _analyzationTestRepository = analyzationTestRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var device = await _deviceServiceRepository.FindAll().ToListAsync(cancellationToken);
        if (device is null) return NotFound();

        return Ok();
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var deviceService = await _deviceServiceRepository.FindByIdAsync(id);
        if (deviceService is null)
            return NotFound();

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DeviceServiceDTO dto, CancellationToken cancellationToken = default)
    {
        //var deviceServices = _mapper.Map<DeviceService>(dto);

        //foreach (var analyzationTest in dto.AnalyzationTests)
        //{
        //    var foundTest = await _analyzationTestRepository.FindByIdAsync(dto.ID, cancellationToken);
        //    if (foundTest is null)
        //        return NotFound($"AuthorGuid {analyzationTest} not found");

        //    deviceServices.AnalyzationTests.Add(foundTest);
        //}
        //_deviceServiceRepository.Add(deviceServices);

        //await _deviceServiceRepository.SaveChangesAsync(cancellationToken);
        //return CreatedAtAction(nameof(Get), new { deviceServices.ID }, _mapper.Map<DeviceServiceDTO>(deviceServices));

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] DeviceServiceDTO dto, CancellationToken cancellationToken = default)
    {
        //var deviceServices = await _deviceServiceRepository.FindByIdAsync(dto.ID, cancellationToken);
        //if (deviceServices is null)
        //    return NotFound();

        //_mapper.Map(dto, deviceServices);

        //ICollection<AnalyzationTest> Tests = deviceServices.AnalyzationTests;
        //ICollection<int> requestTests = dto.AnalyzationTests;
        //ICollection<int> originalTests = deviceServices.AnalyzationTests.Select(s => s.ID).ToList();

        //// Delete breed from species
        //ICollection<int> deleteTests = originalTests.Except(requestTests).ToList();
        //if (deleteTests.Count > 0)
        //{
        //    foreach (var test in deleteTests)
        //    {
        //        var foundTest = await _analyzationTestRepository.FindByIdAsync(dto.ID, cancellationToken);
        //        if (foundTest is null)
        //            return NotFound($"AuthorGuid {Tests} not found");

        //        Tests.Remove(foundTest);
        //    }
        //}

        //// Add new breed to species
        //ICollection<int> newTests = requestTests.Except(originalTests).ToList();
        //if (newTests.Count > 0)
        //{
        //    foreach (var test in newTests)
        //    {
        //        var foundTest = await _analyzationTestRepository.FindByIdAsync(dto.ID, cancellationToken);
        //        if (foundTest is null)
        //            return NotFound($"AuthorGuid {Tests} not found");

        //        Tests.Add(foundTest);
        //    }
        //}

        //await _deviceServiceRepository.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {
        //var deviceServices = await _deviceServiceRepository.FindByIdAsync(id, cancellationToken);
        //if (deviceServices is null)
        //    return NotFound();

        //_deviceServiceRepository.Delete(deviceServices);
        //await _deviceServiceRepository.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}

namespace HospitalManagementSystem.REST;

[Route("api/[controller]/[action]")]
[ApiController]
public class AnalyzationTestController : ControllerBase
{
    //private readonly IAnalyzationTestRepository _analyzationTestRepository;
    //private readonly IHistoryMedicalExamRepository _historyMedicalExamRepository;
    //private readonly IDeviceServiceRepository _deviceServiceRepository;

    //public AnalyzationTestController(IAnalyzationTestRepository analyzationTestRepository, IHistoryMedicalExamRepository historyMedicalExamRepository, IDeviceServiceRepository deviceServiceRepository)
    //{
    //    _analyzationTestRepository = analyzationTestRepository;
    //    _deviceServiceRepository = deviceServiceRepository;
    //    _historyMedicalExamRepository = historyMedicalExamRepository;
    //}

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    //{
    //    var analy = await _analyzationTestRepository.FindAll().ToListAsync(cancellationToken);
    //    if (analy is null) return NotFound();

    //    return Ok();
    //}

    //[HttpGet("{ID}")]
    //public async Task<IActionResult> Get(string Id, CancellationToken cancellationToken = default)
    //{
    //    var Analy = await _analyzationTestRepository.FindByIdAsync(Id, cancellationToken);
    //    if (Analy is null) return NotFound();
    //    return Ok();
    //}

    //[HttpPost]
    //public async Task<IActionResult> Post([FromBody] CreateAnalyzationTestDTO dto, CancellationToken cancellationToken = default)
    //{
    //    //var Analy = _mapper.Map<AnalyzationTest>(dto);
    //    //_analyzationTestRepository.Add(Analy);
    //    //await _analyzationTestRepository.SaveChangesAsync(cancellationToken);
    //    //return CreatedAtAction(nameof(Get), new { Analy.ID}, _mapper.Map<CreateAnalyzationTestDTO>(Analy));
    //    return Ok();
    //}

    //[HttpPut("{ID}")]
    //public async Task<IActionResult> Put([FromBody] AnalyzationTestDTO dto, CancellationToken cancellationToken = default)
    //{
    //    //var analy = await _
    //    //TestRepository.FindByIdAsync(dto.ID, cancellationToken);
    //    //if (analy is null)
    //    //    return NotFound();

    //    //_mapper.Map(dto, analy);
    //    //await _analyzationTestRepository.SaveChangesAsync(cancellationToken);

    //    return NoContent();
    //}

    //[HttpDelete("{ID}")]
    //public async Task<IActionResult> Delete(int ID, CancellationToken cancellationToken = default)
    //{
    //    //var analy = await _analyzationTestRepository.FindByIdAsync(ID, cancellationToken);
    //    //if (analy is null)
    //    //    return NotFound();

    //    //_analyzationTestRepository.Delete(analy);
    //    //await _analyzationTestRepository.SaveChangesAsync(cancellationToken);

    //    return NoContent();
    //}
}

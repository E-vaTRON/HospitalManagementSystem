using AutoMapper;
using HospitalDataBase.Contracts;
using HospitalDataBase.Core.Entities;
using HospitalDataBase.DataObjects;
using HospitalDataBase.DataObjects.CreateDTO;
using HospitalDataBase.DataObjects.ReceiveDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalDataBase.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnalysationTestController : ControllerBase
    {
        private readonly IAnalysationTestRepository _analysationTestRepository;
        private readonly IHistoryMedicalExamRepository _historyMedicalExamRepository;
        private readonly IDeviceServiceRepository _deviceServiceRepository;
        private readonly IMapper _mapper;

        public AnalysationTestController(IAnalysationTestRepository analysationTestRepository, IHistoryMedicalExamRepository historyMedicalExamRepository, IDeviceServiceRepository deviceServiceRepository, IMapper mapper)
        {
            _analysationTestRepository = analysationTestRepository;
            _deviceServiceRepository = deviceServiceRepository;
            _historyMedicalExamRepository = historyMedicalExamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var analy = await _analysationTestRepository.FindAll().ToListAsync(cancellationToken);
            if (analy is null) return NotFound();

            return Ok(_mapper.Map<AnalysationTestDTO>(analy));
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> Get(int ID, CancellationToken cancellationToken = default)
        {
            var @analy = await _analysationTestRepository.FindByIdAsync(ID, cancellationToken);
            if (@analy is null) return NotFound();
            return Ok(_mapper.Map<ReceiveAnalysationTestDTO>(@analy));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAnalysationTestDTO dto, CancellationToken cancellationToken = default)
        {
            var @analy = _mapper.Map<AnalysationTest>(dto);
            _analysationTestRepository.Add(@analy);
            await _analysationTestRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(Get), new { @analy.ID}, _mapper.Map<AnalysationTestDTO>(@analy));
        }

        [HttpPut("{ID}")]
        public async Task<IActionResult> Put([FromBody] AnalysationTestDTO dto, CancellationToken cancellationToken = default)
        {
            var analy = await _analysationTestRepository.FindByIdAsync(dto.ID, cancellationToken);
            if (analy is null)
                return NotFound();

            _mapper.Map(dto, analy);
            await _analysationTestRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID, CancellationToken cancellationToken = default)
        {
            var analy = await _analysationTestRepository.FindByIdAsync(ID, cancellationToken);
            if (analy is null)
                return NotFound();

            _analysationTestRepository.Delete(analy);
            await _analysationTestRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}

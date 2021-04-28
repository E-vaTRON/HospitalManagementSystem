using AutoMapper;
using HospitalDataBase.Contracts;
using HospitalDataBase.DataObjects;
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
        private readonly IPatientRepository _patientRepository;
        private readonly IDeviceServiceRepository _deviceServiceRepository;
        private readonly IMapper _mapper;

        public AnalysationTestController(IAnalysationTestRepository analysationTestRepository, IPatientRepository patientRepository, IDeviceServiceRepository deviceServiceRepository)
        {
            _analysationTestRepository = analysationTestRepository;
            _deviceServiceRepository = deviceServiceRepository;
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var @class = await _analysationTestRepository.FindAll().ToListAsync(cancellationToken);
            if (@class is null) return NotFound();

            return Ok(_mapper.Map<AnalysationTestDTO>(@class));
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> Get(int ID, CancellationToken cancellationToken)
        {
            var @class = await _analysationTestRepository.FindByIdAsync(ID, cancellationToken);
            if (@class is null) return NotFound();
            return Ok(_mapper.Map<AnalysationTestDTO>(@class));
        }
    }
}

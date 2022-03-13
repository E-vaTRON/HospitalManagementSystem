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
    public class DeviceServiceController : Controller
    {
        private readonly IDeviceServiceRepository _deviceServiceRepository;
        private readonly IMapper _mapper;

        public DeviceServiceController(IDeviceServiceRepository deviceServiceRepository, Mapper mapper)
        {
            _deviceServiceRepository = deviceServiceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var device = await _deviceServiceRepository.FindAll().ToListAsync(cancellationToken);
            if (device is null) return NotFound();

            return Ok(_mapper.Map<DeviceServiceDTO>(device));
        }
    }
}

using AutoMapper;
using Fuel_Delivery.Data;
using Fuel_Delivery.IRepository;
using Fuel_Delivery.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fuel_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DriverController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("AddDriver")]
        public async Task<IActionResult> AddDriver(DriverDTO driverDTO)
        {
            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<Driver>(driverDTO);
                await _unitOfWork.Driver.Insert(driver);
                await _unitOfWork.Save();
            }
            return Ok(driverDTO);

        }
    }
}

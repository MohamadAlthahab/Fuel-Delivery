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
    public class FuelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public FuelController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("AddFuel")]
        public async Task<IActionResult> AddFuel(FuelDTO fuelDTO)
        {
            if(ModelState.IsValid)
            {
                var fuel = _mapper.Map<Fuel>(fuelDTO);
                await _unitOfWork.Fuel.Insert(fuel);
                await _unitOfWork.Save();
            }
            return Ok(fuelDTO);
        }

    }
}

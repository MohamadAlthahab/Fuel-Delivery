using AutoMapper;
using Fuel_Delivery.Data;
using Fuel_Delivery.IRepository;
using Fuel_Delivery.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fuel_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Driver> _driverManager;
        public DriverController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<Driver> driverManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _driverManager = driverManager;
        }


        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriver(DriverDTO driverDTO)
        {
            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<Driver>(driverDTO);
                var result = await _driverManager.CreateAsync(driver, driverDTO.Password);
                await _driverManager.AddPasswordAsync(driver , driverDTO.Password);
                if (result.Succeeded)
                {
                    return Ok("Success");
                }
            }
            return BadRequest();

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Driver.Get(u => u.Id == id);
            await _unitOfWork.Driver.Remove(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}

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
    public class CarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CarController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("AddCar")]
        public async Task<IActionResult> AddCar(CarDTO carDTO)
        {
            if (carDTO != null)
            {
                var car = _mapper.Map<Car>(carDTO);
                await _unitOfWork.Car.Insert(car);
                await _unitOfWork.Save();
            }
            return Ok(carDTO);
        }


        [HttpPut("{id=int}")]
        public async Task<IActionResult> UpdateCar(int id, UpdateCarDTO carDTO)
        {
            var car = await _unitOfWork.Car.Get(u => u.Id == id);
            if (car != null)
            {
                _mapper.Map(carDTO , car);
                _unitOfWork.Car.Update(car);
                await _unitOfWork.Save();
            }
            return Ok(carDTO);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _unitOfWork.Car.Get(u => u.Id == id);
            if (car != null)
            {
                await _unitOfWork.Car.Remove(id);
                await _unitOfWork.Save();
            }
            
            return NoContent();
        }


        [HttpGet]
        [Route("GetAllCar")]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _unitOfWork.Car.GetAll();
            IList<Car> carsList = new List<Car>();
            foreach (var car in cars)
            {
                carsList.Add(car);
            }
            return Ok(carsList);
        }
    }
}

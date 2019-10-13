using Domain;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DAL;
using System;

namespace RepositoryPattern.ApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dbItems = _unitOfWork.ServiceRepository.GetAll();
            return Ok(dbItems);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var dbItem = _unitOfWork.ServiceRepository.Get(id);

            if (dbItem == null)
                return NotFound();

            return Ok(dbItem);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Service model)
        {
            if (ModelState.IsValid)
            {
                var dbCar = _unitOfWork.CarRepository.Get(model.CarId);

                if (dbCar == null)
                    return NotFound();

                dbCar.LastService = DateTime.Now;
                _unitOfWork.CarRepository.Update(dbCar);
                _unitOfWork.ServiceRepository.Insert(model);

                _unitOfWork.Commit();

                return Ok();
            }

            return BadRequest(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using GenericRepositoryPattern.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPattern.ApiClient.Controllers
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
            return Ok(_unitOfWork.ServiceRepository.Get());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var dbItem = _unitOfWork.ServiceRepository.Get(id);
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

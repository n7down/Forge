using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;
using Forge.Repository;
using Microsoft.Extensions.Options;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class MotorController : Controller
    {
        private readonly MotorRepository _repository;

        public MotorController(IOptions<Settings> settings) 
        {
           _repository = new MotorRepository(settings);
        }

        // GET api/frame
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetMotor")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Motor motor)
        {
            _repository.Add(motor);
            return CreatedAtRoute("GetBattery", new { id = motor.Id}, motor);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Motor motor)
        {
            _repository.Update(id, motor);
            return new OkResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _repository.Delete(id);
            return new OkResult();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;
using Forge.Repository;
using Microsoft.Extensions.Options;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class FcController : Controller
    {
        private readonly FlightControllerRepository _repository;

        public FcController(IOptions<Settings> settings) 
        {
            _repository = new FlightControllerRepository(settings);
        }

        // GET api/fc
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/fc/5
        [HttpGet("{id}", Name = "GetFC")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/fc
        [HttpPost]
        public IActionResult Post([FromBody] FlightController flightController)
        {
            _repository.Add(flightController);
            return CreatedAtRoute("GetBattery", new { id = flightController.Id}, flightController);
        }

        // PUT api/fc/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] FlightController flightController)
        {
            _repository.Update(id, flightController);
            return new OkResult();
        }

        // DELETE api/fc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _repository.Delete(id);
            return new OkResult();
        }
    }
}

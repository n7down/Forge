using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;
using Forge.Repository;
using Microsoft.Extensions.Options;

namespace Forge.Controllers
{
    [Route("api/v1/[controller]")]
    public class FcController : Controller
    {
        private readonly FlightControllerRepository _repository;

        public FcController(IOptions<Settings> settings) 
        {
            _repository = new FlightControllerRepository(settings);
        }

        // GET api/v1/fc
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/fc/v1/5
        [HttpGet("{id}", Name = "GetFC")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/v1/fc
        [HttpPost]
        public IActionResult Post([FromBody] FlightController flightController)
        {
            // TODO: updated ID with every post
            _repository.Add(flightController);
            return CreatedAtRoute("GetFC", new { id = flightController.Id}, flightController);
        }

        // PUT api/v1/fc/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] FlightController flightController)
        {
            _repository.Update(id, flightController);
            return new OkResult();
        }

        // DELETE api/v1/fc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _repository.Delete(id);
            return new OkResult();
        }
    }
}

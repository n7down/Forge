using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Forge.Models;
using Forge.Repository;
using MongoDB.Driver;
using MongoDB.Bson;

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
        public IActionResult Get(string id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/v1/fc
        [HttpPost]
        public IActionResult Post([FromBody] FlightController flightController)
        {
            flightController.Id = ObjectId.GenerateNewId().ToString();
            _repository.Add(flightController);
            return CreatedAtRoute("GetFC", new { id = flightController.Id}, flightController);
        }

        // PUT api/v1/fc/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] FlightController flightController)
        {
            _repository.Update(id, flightController);
            return CreatedAtRoute("GetFC", new { id = flightController.Id}, flightController);
        }

        // DELETE api/v1/fc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _repository.Delete(id);
            return new OkResult();
        }
    }
}

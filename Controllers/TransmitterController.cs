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
    public class TransmitterController : Controller
    {
        private readonly TransmitterRepository _repository;

        public TransmitterController(IOptions<Settings> settings) 
        {
            _repository = new TransmitterRepository(settings);
        }

        // GET api/frame
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetTransmitter")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Transmitter transmitter)
        {
            _repository.Add(transmitter);
            return CreatedAtRoute("GetBattery", new { id = transmitter.Id}, transmitter);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Transmitter transmitter)
        {
            _repository.Update(id, transmitter);
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

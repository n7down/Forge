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
    public class ReceiverController : Controller
    {
        private readonly ReceiverRepository _repository;

        public ReceiverController(IOptions<Settings> settings) 
        {
            _repository = new ReceiverRepository(settings);
        }

        // GET api/frame
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetReceiver")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Receiver receiver)
        {
            _repository.Add(receiver);
            return CreatedAtRoute("GetBattery", new { id = receiver.Id}, receiver);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Receiver receiver)
        {
            _repository.Update(id, receiver);
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

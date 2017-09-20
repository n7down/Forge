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
    public class FrameController : Controller
    {
        private readonly FrameRepository _repository;

        public FrameController(IOptions<Settings> settings) 
        {
            _repository = new FrameRepository(settings);
        }

        // GET api/frame
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetFrame")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Frame frame)
        {
            _repository.Add(frame);
            return CreatedAtRoute("GetBattery", new { id = frame.Id}, frame);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Frame frame)
        {
            _repository.Update(id, frame);
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

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
    public class PropellerController : Controller
    {
        private readonly PropellerRepository _repository;

        public PropellerController(IOptions<Settings> settings) 
        {
            _repository = new PropellerRepository(settings);
        }

        // GET api/frame
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetPropeller")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Propeller propeller)
        {
            _repository.Add(propeller);
            return CreatedAtRoute("GetBattery", new { id = propeller.Id}, propeller);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Propeller propeller)
        {
            _repository.Update(id, propeller);
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

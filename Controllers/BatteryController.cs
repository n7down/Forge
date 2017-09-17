using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Forge.Models;
using Forge.Repository;
using MongoDB.Driver;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class BatteryController : Controller
    {
        private readonly BatteryRepository _repository;

        public BatteryController(IOptions<Settings> settings) 
        {
            _repository = new BatteryRepository(settings);
        }

        // GET api/battery
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/battery/5
        [HttpGet("{id}", Name = "GetBattery")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/battery
        [HttpPost]
        public IActionResult Post([FromBody] Battery battery)
        {
            _repository.Add(battery);
            return CreatedAtRoute("GetBattery", new { id = battery.Id}, battery);
        }

        // PUT api/battery/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Battery battery)
        {
            _repository.Update(id, battery);
            return new OkResult();
        }

        // DELETE api/battery/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(long id)
        {
            _repository.Delete(id);
            return new OkResult();
        }
    }
}

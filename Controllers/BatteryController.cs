using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class BatteryController : Controller
    {
        private readonly BatteryRepository _repository;

        public BatteryController() 
        {
            // if(_context.Batteries.Count() == 0)
            // {
            //     _context.Batteries.Add(new Battery 
            //     {
            //         Name = "Tattu 14.8V 1300mAh LiPo Battery", 
            //         LipoVoltage = "4S",
            //         MAh = "1300",
            //         CRating = 45, 
            //         PlugType = "XT60",
            //         Weight = "154g",
            //         Dimension = "72*37*30"
            //     });
			// 	_context.SaveChanges();
            // }
            _repository = new BatteryRepository();
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

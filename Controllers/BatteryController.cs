using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class BatteryController : Controller
    {
        private BatteryRepository _repository;

        public BatteryController(BatteryRepository repository) 
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
            _repository = repository;
        }

        // GET api/battery
        [HttpGet]
        public IEnumerable<Battery> Get()
        {
            return _repository.GetAll();
        }

        // GET api/battery/5
        [HttpGet("{id}", Name = "GetBattery")]
        public Battery Get(long id)
        {
            return _repository.Get(id);
        }

        // POST api/battery
        [HttpPost]
        public IActionResult Post([FromBody] Battery battery)
        {
            _repository.Add(new Battery() {
                Name = battery.Name,
                LipoVoltage = battery.LipoVoltage,
                MAh = battery.MAh,
                CRating = battery.CRating,
                PlugType = battery.PlugType,
                Weight = battery.Weight,
                Dimension = battery.Dimension
            });
            return CreatedAtRoute("GetBattery", new { id = battery.Id}, battery);
        }

        // PUT api/battery/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Battery battery)
        {
            _repository.Update(id, battery);
            return new NoContentResult();
        }

        // DELETE api/battery/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(long id)
        {
            _repository.Remove(id);
            return new NoContentResult();
        }
    }
}

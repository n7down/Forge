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
        private readonly BatteryContext _context;

        public BatteryController(BatteryContext batteryContext) 
        {
            _context = batteryContext;
            if(_context.Batteries.Count() == 0)
            {
                _context.Batteries.Add(new Battery 
                {
                    Name = "Tattu 14.8V 1300mAh LiPo Battery", 
                    LipoVoltage = "4S",
                    MAh = "1300",
                    CRating = 45, 
                    PlugType = "XT60",
                    Weight = "154g",
                    Dimension = "72*37*30"
                });
				_context.SaveChanges();
            }
        }

        // GET api/frame
        [HttpGet]
        public IEnumerable<Battery> Get()
        {
            return _context.Batteries.ToList();
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetBattery")]
        public IActionResult Get(long id)
        {
            var frame = _context.Batteries.FirstOrDefault(t => t.Id == id);
            if(frame == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(frame);
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Battery battery)
        {
            if(battery == null)
            {
                return BadRequest();
            }
            _context.Batteries.Add(battery);
            _context.SaveChanges();
            return CreatedAtRoute("GetBattery", new { id = battery.Id}, battery);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Battery battery)
        {
            if(battery == null || battery.Id != id)
            {
                return BadRequest();
            }
            
            var b = _context.Batteries.FirstOrDefault(t => t.Id == id);
            if (b == null)
            {
                return NotFound();
            }

            b.Id = battery.Id;
            b.Name = battery.Name;
			b.LipoVoltage = battery.LipoVoltage;
			b.MAh = battery.MAh;
			b.CRating = battery.CRating;
			b.PlugType = battery.PlugType;
			b.Weight = battery.Weight;
			b.Dimension = battery.Dimension;

            _context.Batteries.Update(b);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var battery = _context.Batteries.FirstOrDefault(t => t.Id == id);
            if (battery == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(battery);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class MotorController : Controller
    {
        private readonly MotorContext _context;

        public MotorController(MotorContext motorContext) 
        {
            _context = motorContext;
            if(_context.Motors.Count() == 0)
            {
                _context.Motors.Add(new Motor 
                {

                });
                _context.SaveChanges();
            }
        }

        // GET api/frame
        [HttpGet]
        public IEnumerable<Motor> Get()
        {
            return _context.Motors.ToList();
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetMotor")]
        public IActionResult Get(long id)
        {
            var motor = _context.Motors.FirstOrDefault(t => t.Id == id);
            if(motor == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(motor);
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Motor motor)
        {
            if(motor == null)
            {
                return BadRequest();
            }
            _context.Motors.Add(motor);
            _context.SaveChanges();
            return CreatedAtRoute("GetBattery", new { id = motor.Id}, motor);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Motor motor)
        {
            if(motor == null || motor.Id != id)
            {
                return BadRequest();
            }
            
            var m = _context.Motors.FirstOrDefault(t => t.Id == id);
            if (m == null)
            {
                return NotFound();
            }

            m.Id = motor.Id;
            m.Name = motor.Name;
            m.Model = motor.Model;
            m.Kv = motor.Kv;
            m.Weight = motor.Weight;
            m.LipoVoltage = motor.LipoVoltage;

            _context.Motors.Update(m);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var motor = _context.Motors.FirstOrDefault(t => t.Id == id);
            if (motor == null)
            {
                return NotFound();
            }

            _context.Motors.Remove(motor);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

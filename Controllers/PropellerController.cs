using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class PropellerController : Controller
    {
        private readonly PropellerContext _context;

        public PropellerController(PropellerContext propellerContext) 
        {
            _context = propellerContext;
            if(_context.Propellers.Count() == 0)
            {
                _context.Propellers.Add(new Propeller 
                {

                });
                _context.SaveChanges();
            }
        }

        // GET api/frame
        [HttpGet]
        public IEnumerable<Propeller> Get()
        {
            return _context.Propellers.ToList();
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetPropeller")]
        public IActionResult Get(long id)
        {
            var propeller = _context.Propellers.FirstOrDefault(t => t.Id == id);
            if(propeller == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(propeller);
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Propeller propeller)
        {
            if(propeller == null)
            {
                return BadRequest();
            }
            _context.Propellers.Add(propeller);
            _context.SaveChanges();
            return CreatedAtRoute("GetBattery", new { id = propeller.Id}, propeller);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Propeller propeller)
        {
            if(propeller == null || propeller.Id != id)
            {
                return BadRequest();
            }
            
            var p = _context.Propellers.FirstOrDefault(t => t.Id == id);
            if (p == null)
            {
                return NotFound();
            }

            p.Id = propeller.Id;
            p.Name = propeller.Name;
            p.Diameter = propeller.Diameter;
            p.Pitch = propeller.Pitch;
            p.Blades = propeller.Blades;
            p.Material = propeller.Material;
            p.Shaft = propeller.Shaft;

            _context.Propellers.Update(p);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var propeller = _context.Propellers.FirstOrDefault(t => t.Id == id);
            if (propeller == null)
            {
                return NotFound();
            }

            _context.Propellers.Remove(propeller);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class EscController : Controller
    {
        private readonly EscContext _context;

        public EscController(EscContext escContext) 
        {
            _context = escContext;
            if(_context.Escs.Count() == 0)
            {
                _context.Escs.Add(new Esc 
                {
                    
                });
                _context.SaveChanges();
            }
        }

        // GET api/esc
        [HttpGet]
        public IEnumerable<Esc> Get()
        {
            return _context.Escs.ToList();
        }

        // GET api/esc/5
        [HttpGet("{id}", Name = "GetEsc")]
        public IActionResult Get(long id)
        {
            var esc = _context.Escs.FirstOrDefault(t => t.Id == id);
            if(esc == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(esc);
        }

        // POST api/esc
        [HttpPost]
        public IActionResult Post([FromBody] Esc esc)
        {
            if(esc == null)
            {
                return BadRequest();
            }
            _context.Escs.Add(esc);
            _context.SaveChanges();
            return CreatedAtRoute("GetEsc", new { id = esc.Id}, esc);
        }

        // PUT api/esc/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Esc esc)
        {
            if(esc == null || esc.Id != id)
            {
                return BadRequest();
            }
            
            var e = _context.Escs.FirstOrDefault(t => t.Id == id);
            if (e == null)
            {
                return NotFound();
            }

            e.Name = esc.Name;
            e.Weight = esc.Weight;
            e.MaxCurrent = esc.MaxCurrent;
            e.AllInOne = esc.AllInOne;
            e.EscProtocol = esc.EscProtocol;
            e.LipoVoltage = esc.LipoVoltage;
            e.EscFirmware = esc.EscFirmware;
            e.Chip = esc.Chip;

            _context.Escs.Update(e);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/esc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var esc = _context.Escs.FirstOrDefault(t => t.Id == id);
            if (esc == null)
            {
                return NotFound();
            }

            _context.Escs.Remove(esc);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

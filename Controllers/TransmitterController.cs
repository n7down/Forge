using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class TransmitterController : Controller
    {
        private readonly TransmitterContext _context;

        public TransmitterController(TransmitterContext transmitterContext) 
        {
            _context = transmitterContext;
            if(_context.Transmitters.Count() == 0)
            {
                _context.Transmitters.Add(new Transmitter 
                {

                });
                _context.SaveChanges();
            }
        }

        // GET api/frame
        [HttpGet]
        public IEnumerable<Transmitter> Get()
        {
            return _context.Transmitters.ToList();
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetTransmitter")]
        public IActionResult Get(long id)
        {
            var transmitter = _context.Transmitters.FirstOrDefault(t => t.Id == id);
            if(transmitter == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(transmitter);
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Transmitter transmitter)
        {
            if(transmitter == null)
            {
                return BadRequest();
            }
            _context.Transmitters.Add(transmitter);
            _context.SaveChanges();
            return CreatedAtRoute("GetBattery", new { id = transmitter.Id}, transmitter);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Transmitter transmitter)
        {
            if(transmitter == null || transmitter.Id != id)
            {
                return BadRequest();
            }
            
            var tr = _context.Transmitters.FirstOrDefault(t => t.Id == id);
            if (tr == null)
            {
                return NotFound();
            }

            tr.Id = transmitter.Id;
            tr.Name = transmitter.Name;
            tr.Weight = transmitter.Weight;
            tr.NumberChannels = transmitter.NumberChannels;
            tr.Voltage = transmitter.Voltage;

            _context.Transmitters.Update(tr);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var transmitter = _context.Transmitters.FirstOrDefault(t => t.Id == id);
            if (transmitter == null)
            {
                return NotFound();
            }

            _context.Transmitters.Remove(transmitter);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

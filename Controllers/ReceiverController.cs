using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class ReceiverController : Controller
    {
        private readonly ReceiverContext _context;

        public ReceiverController(ReceiverContext receiverContext) 
        {
            _context = receiverContext;
            if(_context.Receivers.Count() == 0)
            {
                _context.Receivers.Add(new Receiver 
                {

                });
                _context.SaveChanges();
            }
        }

        // GET api/frame
        [HttpGet]
        public IEnumerable<Receiver> Get()
        {
            return _context.Receivers.ToList();
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetReceiver")]
        public IActionResult Get(long id)
        {
            var propeller = _context.Receivers.FirstOrDefault(t => t.Id == id);
            if(propeller == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(propeller);
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Receiver receiver)
        {
            if(receiver == null)
            {
                return BadRequest();
            }
            _context.Receivers.Add(receiver);
            _context.SaveChanges();
            return CreatedAtRoute("GetBattery", new { id = receiver.Id}, receiver);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Receiver receiver)
        {
            if(receiver == null || receiver.Id != id)
            {
                return BadRequest();
            }
            
            var r = _context.Receivers.FirstOrDefault(t => t.Id == id);
            if (r == null)
            {
                return NotFound();
            }

            r.Id = receiver.Id;
            r.Name = receiver.Name;
            r.Weight = receiver.Weight;
            r.Channels = receiver.Channels;
            r.Telemetry = receiver.Telemetry;

            _context.Receivers.Update(r);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var receiver = _context.Receivers.FirstOrDefault(t => t.Id == id);
            if (receiver == null)
            {
                return NotFound();
            }

            _context.Receivers.Remove(receiver);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

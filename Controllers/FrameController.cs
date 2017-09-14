using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class FrameController : Controller
    {
        private readonly FrameContext _context;

        public FrameController(FrameContext flightControllerContext) 
        {
            _context = flightControllerContext;
            if(_context.Frames.Count() == 0)
            {
                _context.Frames.Add(new Frame 
                {

                });
                _context.SaveChanges();
            }
        }

        // GET api/frame
        [HttpGet]
        public IEnumerable<Frame> Get()
        {
            return _context.Frames.ToList();
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetFrame")]
        public IActionResult Get(long id)
        {
            var frame = _context.Frames.FirstOrDefault(t => t.Id == id);
            if(frame == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(frame);
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Frame frame)
        {
            if(frame == null)
            {
                return BadRequest();
            }
            _context.Frames.Add(frame);
            _context.SaveChanges();
            return CreatedAtRoute("GetFrame", new { id = frame.Id}, frame);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Frame frame)
        {
            if(frame == null || frame.Id != id)
            {
                return BadRequest();
            }
            
            var f = _context.Frames.FirstOrDefault(t => t.Id == id);
            if (f == null)
            {
                return NotFound();
            }

            f.Name = frame.Name;
            f.Weight = frame.Weight;

            _context.Frames.Update(f);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var frame = _context.Frames.FirstOrDefault(t => t.Id == id);
            if (frame == null)
            {
                return NotFound();
            }

            _context.Frames.Remove(frame);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class CameraController : Controller
    {
        private readonly CameraContext _context;

        public CameraController(CameraContext cameraContext) 
        {
            _context = cameraContext;
            if(_context.Cameras.Count() == 0)
            {
                _context.Cameras.Add(new Camera 
                {
                    Name = "Runcam Swift 2",
                    IRBlock = true,
                    Mic = true, 
                    WeightInGrams = 12
                });
                _context.SaveChanges();
            }
        }

        // GET api/frame
        [HttpGet]
        public IEnumerable<Camera> Get()
        {
            return _context.Cameras.ToList();
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetCamera")]
        public IActionResult Get(long id)
        {
            var camera = _context.Cameras.FirstOrDefault(t => t.Id == id);
            if(camera == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(camera);
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Camera camera)
        {
            if(camera == null)
            {
                return BadRequest();
            }
            _context.Cameras.Add(camera);
            _context.SaveChanges();
            return CreatedAtRoute("GetBattery", new { id = camera.Id}, camera);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Camera camera)
        {
            if(camera == null || camera.Id != id)
            {
                return BadRequest();
            }
            
            var c = _context.Cameras.FirstOrDefault(t => t.Id == id);
            if (c == null)
            {
                return NotFound();
            }

            c.Id = camera.Id;
            c.Name = camera.Name;

            _context.Cameras.Update(c);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var camera = _context.Cameras.FirstOrDefault(t => t.Id == id);
            if (camera == null)
            {
                return NotFound();
            }

            _context.Cameras.Remove(camera);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

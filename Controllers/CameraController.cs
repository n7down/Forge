using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;
using Forge.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class CameraController : Controller
    {
        private readonly CameraRepository _repository;

        public CameraController(IOptions<Settings> settings) 
        {
            _repository = new CameraRepository(settings);
        }

        // GET api/frame
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/frame/5
        [HttpGet("{id}", Name = "GetCamera")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/frame
        [HttpPost]
        public IActionResult Post([FromBody] Camera camera)
        {
            _repository.Add(camera);
            return CreatedAtRoute("GetBattery", new { id = camera.Id}, camera);
        }

        // PUT api/frame/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Camera camera)
        {
            _repository.Update(id, camera);
            return new OkResult();
        }

        // DELETE api/frame/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _repository.Delete(id);
            return new OkResult();
        }
    }
}

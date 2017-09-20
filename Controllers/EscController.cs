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
    public class EscController : Controller
    {
        private readonly EscRepository _repository;

        public EscController(IOptions<Settings> settings) 
        {
            _repository = new EscRepository(settings);
        }

        // GET api/esc
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_repository.GetAll());
        }

        // GET api/esc/5
        [HttpGet("{id}", Name = "GetEsc")]
        public IActionResult Get(long id)
        {
            return new OkObjectResult(_repository.Get(id));
        }

        // POST api/esc
        [HttpPost]
        public IActionResult Post([FromBody] Esc esc)
        {
            _repository.Add(esc);
            return CreatedAtRoute("GetBattery", new { id = esc.Id}, esc);
        }

        // PUT api/esc/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Esc esc)
        {
            _repository.Update(id, esc);
            return new OkResult();
        }

        // DELETE api/esc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _repository.Delete(id);
            return new OkResult();
        }
    }
}

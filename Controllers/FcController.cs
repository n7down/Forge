using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Forge.Models;

namespace Forge.Controllers
{
    [Route("api/[controller]")]
    public class FcController : Controller
    {
        private readonly FlightControllerContext _context;

        public FcController(FlightControllerContext flightControllerContext) 
        {
            _context = flightControllerContext;
            if(_context.FlightControllers.Count() == 0)
            {
                _context.FlightControllers.Add(new FlightController 
                {
                    Name = "Betaflight F3",
                    MCU = "STM32F303CCT6",
                    GyroName = "MPU6000",
                    OSD = true,
                    OSDName = "AB7456",
                    PDB = true,
                    LipoVoltage = "3S-4S",
                    SDCard = true,
                    Weight = 8.6F,
                    NumberUARTS = 3,
                    Barometer = false,
                    PWM = true,
                    SBUS = true,
                    DSMTwo = true,
                    LedStrip = true,
                    VideoIn = true,
                    VideoOut = true,
                    Buzzer = true,
                    NumberSoftSerial = 1
                });
                _context.FlightControllers.Add(new FlightController 
                {
                    Name = "DYS F4",
                    LipoVoltage = "2S-6S",
                    Weight = 11.2F
                });
                _context.SaveChanges();
            }
        }

        // GET api/fc
        [HttpGet]
        public IEnumerable<FlightController> Get()
        {
            return _context.FlightControllers.ToList();
        }

        // GET api/fc/5
        [HttpGet("{id}", Name = "GetFC")]
        public IActionResult Get(long id)
        {
            var flightController = _context.FlightControllers.FirstOrDefault(t => t.Id == id);
            if(flightController == null)
            {
                return new JsonResult("{}");
            }
            return new ObjectResult(flightController);
        }

        // POST api/fc
        [HttpPost]
        public IActionResult Post([FromBody] FlightController flightController)
        {
            if(flightController == null)
            {
                return BadRequest();
            }
            _context.FlightControllers.Add(flightController);
            _context.SaveChanges();
            return CreatedAtRoute("GetFC", new { id = flightController.Id}, flightController);
        }

        // PUT api/fc/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] FlightController flightController)
        {
            if(flightController == null || flightController.Id != id)
            {
                return BadRequest();
            }
            
            var fc = _context.FlightControllers.FirstOrDefault(t => t.Id == id);
            if (fc == null)
            {
                return NotFound();
            }

            fc.Name = flightController.Name;
            fc.MCU = flightController.MCU;
            fc.GyroName = flightController.GyroName;
            fc.OSD = flightController.OSD;
            fc.OSDName = flightController.OSDName;
            fc.PDB = flightController.PDB;
            fc.LipoVoltage = flightController.LipoVoltage;
            fc.SDCard = flightController.SDCard;
            fc.Weight = flightController.Weight;
            fc.NumberUARTS = flightController.NumberUARTS;
            fc.Barometer = flightController.Barometer;
            fc.PWM = flightController.PWM;
            fc.SBUS = flightController.SBUS;
            fc.DSMTwo = flightController.DSMTwo;
            fc.LedStrip = flightController.LedStrip;
            fc.VideoIn = flightController.VideoIn;
            fc.VideoOut = flightController.VideoOut;
            fc.Buzzer = flightController.Buzzer;
            fc.NumberSoftSerial = flightController.NumberSoftSerial;

            _context.FlightControllers.Update(fc);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/fc/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var flightController = _context.FlightControllers.FirstOrDefault(t => t.Id == id);
            if (flightController == null)
            {
                return NotFound();
            }

            _context.FlightControllers.Remove(flightController);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

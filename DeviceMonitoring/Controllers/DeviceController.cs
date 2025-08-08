using DeviceMonitoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        private List<Device> _devices = new List<Device>();

        [HttpPost]
        public IActionResult Add([FromBody] Device device)
        {
            if (ModelState.IsValid)
            {
                _devices.Add(device);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_devices);
        }

        [HttpGet("{id}")]
        public IActionResult GetTryId(Guid id)
        {
            var device = _devices.Find(dev => dev.Id == id);

            if (device == null)
            { 
                return NotFound();
            }
            return Ok(device);
        }
    }
}

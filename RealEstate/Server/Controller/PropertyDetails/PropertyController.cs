using Microsoft.AspNetCore.Mvc;
using RealEstate.Server.Model.PropertyDetails;
using RealEstate.Server.Service;
using RealEstate.Shared.DTO.PropertyDetails;

namespace RealEstate.Server.Controller.PropertyDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _propertyService;
        private readonly ILogger<PropertyController> _logger;
        public PropertyController(PropertyService propertyService, ILogger<PropertyController> logger)
        {
            _propertyService = propertyService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<PropertyDTO>> GetAllProperties()
        {
            _logger.LogInformation("Getting all properties");
            var properties = _propertyService.GetAllProperty();
            return Ok(properties);
        }

        [HttpGet("GetById")]
        public ActionResult<PropertyDTO> GetPropertyById(int id)
        {
            _logger.LogInformation($"Getting property by id: {id}");
            var property = _propertyService.GetPropertyById(id);
            if (property == null)
            {
                _logger.LogWarning($"Property with id: {id} not found");
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddProperty(PropertyDTO PropertyDTO)
        {
            _logger.LogInformation("Adding a new property");
            var result = await _propertyService.AddProperty(PropertyDTO);
            if (result)
            {
                _logger.LogInformation("Property added successfully");
                return Ok();
            }

            _logger.LogError("Failed to add property");
            return BadRequest();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateProperty(PropertyDTO PropertyDTO)
        {

            _logger.LogInformation($"Updating property with id: {PropertyDTO.Id}");

            var result = await _propertyService.UpdateProperty(PropertyDTO);
            if (result)
            {
                _logger.LogInformation("Property updated successfully");
                return Ok();
            }

            _logger.LogError("Failed to update property");
            return BadRequest(ModelState);
        }
    }
}

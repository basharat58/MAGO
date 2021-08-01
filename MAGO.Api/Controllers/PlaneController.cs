using MAGO.Core.Requests;
using MAGO.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAGO.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaneController : ControllerBase
    {
        private readonly IPlaneService _planeService;
        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        [HttpPost]        
        public IActionResult BookPlane(ParkingRequest parkingRequest)
        {
            var result = _planeService.BookParkingSlot(parkingRequest);
            return result.Success == true ? Ok(new { result.Message }) : NotFound(new { result.Message });
        }
    }
}

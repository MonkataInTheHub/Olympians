using Microsoft.AspNetCore.Mvc;
using Olympians.Models;
using Olympians.Models.Interfaces;
using Olympians.Services;
using Olympians.Services.Interfaces;

namespace Olympians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OlympiansController : ControllerBase
    {
        readonly IOlympianService _olympianService;

        public OlympiansController(IOlympianService olympianService)
        {
            _olympianService = olympianService;
        }
        [HttpGet("ListOlympians")]
        public IEnumerable<IOlympian> ListOlympians()
        {
            return _olympianService.ListOlympians();
        }
    }
}

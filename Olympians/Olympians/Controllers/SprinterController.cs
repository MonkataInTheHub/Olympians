using Microsoft.AspNetCore.Mvc;
using Olympians.Models;
using Olympians.Services.Interfaces;

namespace Olympians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprinterController : ControllerBase
    {
        readonly ISprinterService _sprinterService;
        public SprinterController(ISprinterService sprinterService)
        {
            _sprinterService = sprinterService;
        }
       
        [HttpGet("GetAllSprinters")]
        public IEnumerable<Sprinter> GetAllSprinters()
        {
            return _sprinterService.GetAllSprinters();
        }
        
        [HttpGet("GetSprinter")]
        public Sprinter Get(string firstName, string lastName)
        {
            return _sprinterService.Get(firstName, lastName);
        }
        
        [HttpPost]
        public void Create([FromBody] Sprinter sprinter)
        {
            _sprinterService.Create(sprinter);
        }
       
        [HttpPut]
        public void Update([FromBody] Sprinter sprinter)
        {
            _sprinterService.Update(sprinter);
        }
        
        [HttpDelete]
        public void Delete([FromBody] Sprinter sprinter)
        {
            _sprinterService.Delete(sprinter);
        }
    }
}

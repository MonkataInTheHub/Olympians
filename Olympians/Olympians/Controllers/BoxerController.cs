using Microsoft.AspNetCore.Mvc;
using Olympians.Models;
using Olympians.Services.Interfaces;
namespace Olympians.Controllers
{
    [Route("api /[controller]")]
    [ApiController]
    public class BoxerController : ControllerBase
    {
        readonly IBoxerService _boxerService;
        public BoxerController(IBoxerService boxerService)
        {
            boxerService = boxerService;
        }

        [HttpGet("GetAllBoxers")]
        public IEnumerable<Boxer> GetAllBoxers()
        {
            return _boxerService.GetAllBoxers();
        }

        [HttpGet("GetBoxer")]
        public Boxer Get(string firstName, string lastName)
        {
            return _boxerService.Get(firstName, lastName);
        }

        [HttpPost]
        public void Create([FromBody] Boxer boxer)
        {
            _boxerService.Create(boxer);
        }

        [HttpPut]
        public void Update([FromBody] Boxer boxer)
        {
            _boxerService.Update(boxer);
        }

        [HttpDelete]
        public void Delete([FromBody] Boxer boxer)
        {
            _boxerService.Delete(boxer);
        }
    }
}

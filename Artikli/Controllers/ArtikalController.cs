using Artikli.Data;
using Artikli.Model;
using Microsoft.AspNetCore.Mvc;

namespace Artikli.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtikalController(ILogger<ArtikalController> _logger, AppDbContext _dbContext) : ControllerBase
    {
        [HttpGet("{naziv}")]
        public IActionResult Get([FromRoute] string naziv)
        {
            var result = _dbContext.Artikli.FirstOrDefault(x => x.Name == naziv);

            return result is null ? NotFound("Artikal nije pronadjen...") : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Artikal artikal)
        {
            _dbContext.Artikli.Add(artikal);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}

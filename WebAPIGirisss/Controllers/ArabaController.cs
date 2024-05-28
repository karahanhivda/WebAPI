using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPIGirisss.Contexts;
using WebAPIGirisss.Data;

namespace WebAPIGirisss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArabaController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public ArabaController(AppDbContext context)
        {
            context = _appDbContext;
        }

        [HttpGet("Arabalar")]
        public IEnumerable<Araba> Birinci()
        {

            return _appDbContext.Arabalar.ToList();
        }
    }
}

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
            _appDbContext = context;
        }

        [HttpGet("Arabalar")]
        public IEnumerable<Araba> Birinci()
        {

            return _appDbContext.Arabalar.ToList();
        }

        [HttpPost("Arabalar")]
        public IActionResult ArabaEkle([FromBody] Araba Araba)
        {
            Araba araba = new Araba();
            araba.Marka=Araba.Marka;
            araba.Renk=Araba.Renk;

            _appDbContext.Arabalar.Add(araba);
            _appDbContext.SaveChanges();

            return Ok("Eklendi!");   
        }

        [HttpDelete("Arabalar")]
        public IActionResult ArabaSil(int Id) 
        {
            //_appDbContext.Arabalar.FirstOrDefault(a => a.Id==Id);
            var sil = _appDbContext.Arabalar.FirstOrDefault(a => a.Id == Id);
            if (sil == null)
            {
                return BadRequest("Hata");
            }
             
            _appDbContext.Arabalar.Remove(sil);
            _appDbContext.SaveChanges();

            return Ok("Silindi");    
        }

        [HttpPut("Arabalar")]
        public IActionResult ArabaGuncelle(int Id, Araba araba)
        {
            Araba arabaa = new Araba();
            var guncelle = _appDbContext.Arabalar.FirstOrDefault(arabaa => arabaa.Id == Id);
        
            if(guncelle == null)
            {
                return BadRequest("Hata!");
            }
            guncelle.Marka = araba.Marka;
            guncelle.Renk = araba.Renk;

            _appDbContext.Arabalar.Update(guncelle);
            _appDbContext.SaveChanges();

            return Ok();
        }
    }
}

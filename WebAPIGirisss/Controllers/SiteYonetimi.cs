using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGirisss.Data;

namespace WebAPIGirisss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteYonetimi : ControllerBase
    {
        string[] bloklar = { "A", "B", "C", "D", "E" };
        static List<Blok> daireler = new List<Blok>();

        [HttpGet("SiteYonetimi")]
        public IEnumerable<Blok> GetBlok()
        {
            
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 1; j < 201; j++) 
                {
                    Blok blok = new Blok();
                    blok.Daire = j;
                    blok.Ucret= new Random().Next(950, 2501);
                    blok.No = bloklar[i];
                    daireler.Add(blok);
                }
            }
            return daireler;
        }

        [HttpPost("YonetimSite")]
        public string BlokEkleme([FromBody] Blok blok)
        {
            Blok bloks = new Blok();
            bloks.No = blok.No; 
            bloks.Ucret = blok.Ucret;
            bloks.Daire = blok.Daire;
            daireler.Add(bloks);
            return "Verileriniz Eklendi!";
        }

        [HttpGet("YonetimSite")]
        public IEnumerable<Blok> BLokListele()
        {
            return daireler;
        }
    }
}


using Business;
using System.Web.Mvc;

namespace KartRank.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            var caminho = Server.MapPath("~") + "Arquivos\\rank.txt";
            var allLine = System.IO.File.ReadAllLines(caminho, System.Text.Encoding.Default);
            
            var result = RankBusiness.CalcularVoltas(allLine);
            ViewBag.MelhorVoltaCorrida = RankBusiness.Melhortempo(result);

            return View(result);
        }
    }
}

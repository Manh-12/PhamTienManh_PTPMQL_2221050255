using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers
{
    public class DemoController : Controller
    {
        // GET: /Demo/
        public IActionResult Index()
        {
            return View();
        }
    }
}   
using Microsoft.AspNetCore.Mvc;

namespace PTPMQL_MVC.Controllers
{
    public class BaitapController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello Hoàng Công Hiếu - MSSV: 2221050356";
            return View();
        }
    }
}
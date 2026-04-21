using Microsoft.AspNetCore.Mvc;

namespace DemoController.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello Hoàng Công Hiếu - MSSV: 2221050356";
            return View();
        }
    }
}
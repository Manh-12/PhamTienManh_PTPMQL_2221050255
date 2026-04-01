using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public IActionResult Index() // Đổi string thành IActionResult
        {
            return View(); // Đổi return chuỗi thành return View()
        }

        // ... giữ nguyên phần Welcome
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
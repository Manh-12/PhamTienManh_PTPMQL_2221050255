using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace FirstWebMVC.Controllers
{
    public class TestController : Controller
    {
        // 1. GET: Chạy khi người dùng gõ URL vào trang web
        // Nhiệm vụ: Chỉ đơn giản là hiện cái Form ra
        [HttpGet] 
        public ActionResult Index()
        {
            return View();
        }

        // 2. POST: Chạy khi người dùng bấm nút "Gửi Lời Chào"
        // Nhiệm vụ: Nhận tên, xử lý chuỗi và gửi lại View
        [HttpPost]
        public ActionResult Index(string hoTen)
        {
            // Kiểm tra xem người dùng có nhập gì không
            if (string.IsNullOrEmpty(hoTen))
            {
                ViewBag.LoiNhan = "Bạn chưa nhập tên!";
            }
            else
            {
                // Xử lý logic: Nối chuỗi
                string thongBao = "Xin chào " + hoTen + ", chúc bạn một ngày tốt lành!";
                
                // Gửi kết quả về View qua ViewBag
                ViewBag.LoiNhan = thongBao;
            }

            // Trả về lại đúng View Index để hiện kết quả ngay tại đó
            return View();
        }
    }
}
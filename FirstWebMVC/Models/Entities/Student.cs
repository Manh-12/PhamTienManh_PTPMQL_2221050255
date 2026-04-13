using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models.Entities
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [Required(ErrorMessage = "Mã sinh viên không được để trống!")]
        // Thêm = string.Empty để xóa cảnh báo CS8618
        public string StudentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ và tên không được để trống!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Họ tên phải từ 3 đến 50 ký tự!")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập tuổi!")]
        [Range(18, 200, ErrorMessage = "Yêu cầu trên 18 tuổi!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng (VD: ten@gmail.com)!")]
        public string Email { get; set; } = string.Empty;

        // Khóa ngoại nên khởi tạo giá trị mặc định để tránh lỗi khi tạo Migration
        public string FacultyID { get; set; } = string.Empty;

        [ForeignKey("FacultyID")]
        // Thêm dấu ? vì Faculty là một đối tượng liên kết, có thể null khi chưa load dữ liệu
        public virtual Faculty? Faculty { get; set; } 
    }
}
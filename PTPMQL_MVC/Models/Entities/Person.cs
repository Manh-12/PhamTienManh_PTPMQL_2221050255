using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PTPMQL_MVC.Models.Entities; // Dùng dấu chấm phẩy ở đây

public class Person
{
    [Key]
    [Required(ErrorMessage = "Id không được để trống")]
    public string PersonId { get; set; } = default!;

    [Required(ErrorMessage = "Tên không được để trống")]
    [StringLength(50, ErrorMessage = "Tên tối đa 50 ký tự")]
    public string FullName { get; set; } = default!;

    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    public string Address { get; set; } = default!;

    [Range(1, 120, ErrorMessage = "Tuổi phải từ 1 đến 120")]
    [Required(ErrorMessage = "Tuổi không được để trống")]
    public int Age { get; set; } // Đổi sang kiểu int để dùng Range cho đúng

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [Required(ErrorMessage = "Email không được để trống")]
    public string Email { get; set; } = default!;
}

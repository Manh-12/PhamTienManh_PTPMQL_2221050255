using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTPMQL_MVC.Models.Entities
{
public class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }

    // FK Order
    [Required(ErrorMessage = "Đơn hàng là bắt buộc")]
    public int OrderId { get; set; }

    public Order? Order { get; set; }

    // FK Product
    [Required(ErrorMessage = "Sản phẩm là bắt buộc")]
    public int ProductId { get; set; }

    public Product? Product { get; set; }

    [Required(ErrorMessage = "Số lượng là bắt buộc")]
    [Range(1, 1000, ErrorMessage = "Số lượng phải từ 1 đến 1000")]
    public int Quantity { get; set; }
}
}
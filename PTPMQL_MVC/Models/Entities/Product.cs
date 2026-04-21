using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTPMQL_MVC.Models.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [StringLength(150, MinimumLength = 2)]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(0.01, 100000000)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    // 1 Product - n OrderDetails
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
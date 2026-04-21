using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTPMQL_MVC.Models.Entities
{

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required(ErrorMessage = "Ngày đặt hàng là bắt buộc")]
    [DataType(DataType.Date)]
    public DateTime OrderDate { get; set; }

    // FK Customer
    [Required(ErrorMessage = "Khách hàng là bắt buộc")]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }

    // 1 Order - n OrderDetails
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
}
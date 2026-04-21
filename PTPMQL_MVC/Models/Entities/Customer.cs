using System.ComponentModel.DataAnnotations;
namespace PTPMQL_MVC.Models.Entities;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Tên khách hàng không được để trống")]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }

    // 1 Customer - n Orders
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
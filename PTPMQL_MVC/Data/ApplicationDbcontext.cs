using Microsoft.EntityFrameworkCore;
using PTPMQL_MVC.Models.Entities;

namespace PTPMQL_MVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Đảm bảo các tên này PHẢI CÓ chữ 's' ở cuối để khớp với Controller
    public DbSet<Person> Person { get; set; } // Nếu Controller dùng .Person thì để Person
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
}

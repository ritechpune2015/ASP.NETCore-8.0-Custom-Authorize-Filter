using Microsoft.EntityFrameworkCore;

namespace Custom_Authorize_Filter.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User { UserID = 1, FirstName = "Sunil", LastName = "Doe", Password = "abcd", EmailID = "sunil@example.com", MobileNo = "1234560989" }
                );  

            modelBuilder.Entity<Product>().HasData(
                 new Product { ProductID = 1, ProductName = "Laptop", MfgName = "Dell", Price = 50000 },
                 new Product { ProductID = 2, ProductName = "Mobile", MfgName = "Samsung", Price = 20000 },
                 new Product { ProductID = 3, ProductName = "Tablet", MfgName = "Apple", Price = 30000 }
                );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;

namespace OnlineShopping.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Register> tbl_register { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scify", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Sonata",
                    ProductDescription = "Watch",
                    ProductCategoryId = 1,
                    ProductPrice = 500
                },
                new Product
                {
					Id = 2,
					ProductName = "Titan",
					ProductDescription = "Watch",
					ProductCategoryId = 1,
					ProductPrice = 500
				},
                new Product
                {
					Id = 3,
					ProductName = "Samsung-M13",
					ProductDescription = "Mobile",
					ProductCategoryId = 2,
					ProductPrice = 12000
				},
                new Product
                {
					Id = 4,
					ProductName = "Samsung-Note",
					ProductDescription = "Mobile",
					ProductCategoryId = 2,
					ProductPrice = 15000
				}
                );
            modelBuilder.Entity<Register>().HasData(
                new Register
                {
                    Id = 1,
                    FullName = "sudhar",
                    Gender = "Male",
                    DOB = "20-05-2010",
                    Email ="sudhar@gmail.com",
                    Phone = "6666667857",
                    Address = "tirupur"
               
                }
                );
            
        }

    }
}

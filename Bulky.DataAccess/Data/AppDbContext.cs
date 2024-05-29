using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<OrderHeader> OrderHeaders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Drama", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Comedy", DisplayOrder = 3 });
            
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Alpha", StreetAddress = "123 Allen Avenue", City="Ikeja", State="Lagos", PostalCode = "14252" },
                new Company { Id = 2, Name = "Beta", StreetAddress = "123 Allen Avenue", City = "Akure", State = "Kanu", PostalCode = "64352" },
                new Company { Id = 3, Name = "Omega", StreetAddress = "123 Allen Avenue", City = "Asaba", State = "Delta", PostalCode = "07252" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Fortune of time", Author = "Billy Spark", Description = "Lorem Ipsum", ISBN = "Ikj32728", ListPrice = 99, Price = 90, Price50 = 50 - 85, Price100 = 100 - 80, CategoryId = 3, ImageUrl = ""},
                new Product { Id = 2, Title = "Dark Skies", Author = "Willy Wonka", Description = "Lorem Ipsum", ISBN = "Mus53720", ListPrice = 49, Price = 70, Price50 = 50 - 65, Price100 = 100 - 70, CategoryId = 2, ImageUrl = "" },
                new Product { Id = 3, Title = "Fortune of time", Author = "Billy Spark", Description = "Lorem Ipsum", ISBN = "Ikj32728", ListPrice = 99, Price = 90, Price50 = 50 - 85, Price100 = 100 - 80, CategoryId = 1, ImageUrl = "" },
                new Product { Id = 4, Title = "Dark Skies", Author = "Willy Wonka", Description = "Lorem Ipsum", ISBN = "Mus53720", ListPrice = 49, Price = 70, Price50 = 50 - 65, Price100 = 100 - 70, CategoryId = 3, ImageUrl = "" },
                new Product { Id = 5, Title = "Fortune of time", Author = "Billy Spark", Description = "Lorem Ipsum", ISBN = "Ikj32728", ListPrice = 99, Price = 90, Price50 = 50 - 85, Price100 = 100 - 80, CategoryId = 2, ImageUrl = "" },
                new Product { Id = 6, Title = "Dark Skies", Author = "Willy Wonka", Description = "Lorem Ipsum", ISBN = "Mus53720", ListPrice = 49, Price = 70, Price50 = 50 - 65, Price100 = 100 - 70 , CategoryId = 1, ImageUrl = "" },
                new Product { Id = 7, Title = "Fortune of time", Author = "Billy Spark", Description = "Lorem Ipsum", ISBN = "Ikj32728", ListPrice = 99, Price = 90, Price50 = 50 - 85, Price100 = 100 - 80, CategoryId = 3, ImageUrl = "" }
                );
        }
    }
}

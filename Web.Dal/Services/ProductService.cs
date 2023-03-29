using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database;
using WEB.Database.Models;

namespace Web.Dal.Services
{
    public class ProductService
    {
        private ApplicationDbContext dbContext;
        public ProductService(IConfiguration configuration)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            dbContext=new ApplicationDbContext(builder.Options);    
        }
        public void Store(Product product )
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
        public List<Product>GetProduct()
        {
           return dbContext.Products
                .Include(p => p.Category).ToList();
        }
        public List<Category>GetCategories()
        {
            return dbContext.Categories.ToList();
        }
    }
}

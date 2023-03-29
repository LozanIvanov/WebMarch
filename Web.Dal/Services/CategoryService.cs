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
    public class CategoryService
    {
        private ApplicationDbContext dbContext;
        public CategoryService(IConfiguration configuration)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer( configuration.GetConnectionString("DefaultConnection"));
           dbContext=new ApplicationDbContext(builder.Options); 

        }

        public List<Category>GetCategory()
        {
            return dbContext.Categories.ToList();
        }
        public void Store(Category category)
        {
           
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();    
        }
        public Category GetCategoryById(int id)
        {
            return dbContext.Categories.Where(x=>x.Id == id).FirstOrDefault();
        }
        public void Update(Category category)
        {
            dbContext.Entry(category).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var d = dbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Entry(d).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

    }
}

using WEB.Database.Models;

namespace WebMarch.Models.Admin
{
    public class ProductEditViewModel
    {
        public List<Category>Categories { get; set; }
        public ProductCreateModel? ViewProduct { get; set; }
    }
}

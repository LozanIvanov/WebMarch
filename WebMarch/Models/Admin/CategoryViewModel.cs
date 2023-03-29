using WEB.Database.Models;

namespace WebMarch.Models.Admin
{
    public class CategoryViewModel
    {
        public Category SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}

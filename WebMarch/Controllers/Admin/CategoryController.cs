using Microsoft.AspNetCore.Mvc;
using Web.Dal.Services;
using WEB.Database.Models;
using WebMarch.Models.Admin;

namespace WebMarch.Controllers.Admin
{
    [Route("/Admin/Categories")]
    
    public class CategoryController : Controller
    {
        private CategoryService service;
        public CategoryController(CategoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("/Admin/Categories")]
        public IActionResult index()
        {
            List<Category> model = service.GetCategory();
            return View("~/Views/Admin/Categories/Index.cshtml",model);
        }
       [HttpGet]
       [Route("/Admin/Categories/Create")]
        public IActionResult Create()
        {
            var model=service.GetCategory();
            return View("~/Views/Admin/Categories/Create.cshtml",model);
        }
        [HttpPost]
        [Route("/Admin/Categories/Create")]
        public IActionResult Create(Category category)
        {
            service.Store(category);
            return Redirect("/Admin/Categories");
        }
        [HttpGet]
        [Route("/Admin/Categories/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = new CategoryViewModel();
            model.Categories = service.GetCategory();
            model.SelectedCategory=service.GetCategoryById(id);
            return View("~/Views/Admin/Categories/Edit.cshtml", model);
        }
        [HttpPost]
        [Route("/Admin/Categories/Edit/{id}")]
        public IActionResult Edit(int id,Category category)
        {
            service.Update(category);
            return Redirect("/Admin/Categories");
        }
        [HttpGet]
        [Route("/Admin/Categories/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Redirect("/Admin/Categories");
        }
    }
    

}

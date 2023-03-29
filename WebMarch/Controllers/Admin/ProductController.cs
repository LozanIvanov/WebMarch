using Microsoft.AspNetCore.Mvc;
using Web.Dal.Services;
using WEB.Database.Models;
using WebMarch.Models.Admin;

namespace WebMarch.Controllers.Admin
{
    [Route("/Admin/Product")]
    public class ProductController: Controller
    {
        private ProductService productservice;
        private readonly IWebHostEnvironment environment;
        private CategoryService categoryService;
        public ProductController(ProductService productservice,  IWebHostEnvironment environment, CategoryService categoryService)
        {
            this.productservice = productservice; 
            this.environment=environment;
            this.categoryService=categoryService;
    }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/Admin/Product/Create")]
        public IActionResult Create()
        {
            var model = new ProductEditViewModel();
            model.Categories = this.productservice.GetCategories();
            return View("~/Views/Admin/Products/Form.cshtml",model);
        }
        [HttpPost]
        [Route("/Admin/Product/Create")]
        public async Task<IActionResult> Create(ProductEditViewModel productModel)
        {



            var product = new Product()
            {
                Name = productModel.ViewProduct.Name,
                Discription = productModel.ViewProduct.Discription,
                Quantity = productModel.ViewProduct.Quantity,
                Price = productModel.ViewProduct.Price,

                CategoryId = productModel.ViewProduct.CategoryId,
            
            
              };
            string filePath = "no-image.png";
            if (productModel.ViewProduct.MainImage != null)
            {

                filePath = await UploadFile(productModel.ViewProduct.MainImage);
             }
     
           product. MainImage = filePath;
            productservice.Store(product);
            return View("~/Views/Admin/Products/Form.cshtml");
        }

        private async Task<string>UploadFile(IFormFile file)
        {
            var uniqueFileName = Guid.NewGuid() + "-" + file.FileName;
            var filePath = Path.Combine("wwwroot", "img", "products", uniqueFileName);
            using(var stream=System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return uniqueFileName;
        }
    }
}

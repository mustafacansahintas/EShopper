using EShopper.Business.Abstract;
using EShopper.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        //Dependency Injection
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}

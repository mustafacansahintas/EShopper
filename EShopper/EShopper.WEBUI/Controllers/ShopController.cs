﻿using EShopper.Business.Abstract;
using EShopper.Entities;
using EShopper.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WEBUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        //products/telefon?page=2
        [Route("products/{category?}")]
        public IActionResult List(string category, int page=1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                PageInfo= new PageInfo()
                {
                    TotalItems=_productService.GetCountByCategory(category),
                    CurrentCategory=category,
                    CurrentPage=page,
                    ItemsPerPage=pageSize
                },
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            });
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductDetailsModel()
            {
                Product=product,
                Categories=product.ProductCategories.Select(i => i.Category).ToList()
            });
        }
    }
}

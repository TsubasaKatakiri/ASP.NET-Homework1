using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.BLL.Interfaces;
using WebStore.BLL.Services;
using WebStore.BLL.VMs;
using WebStore.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService { get; set; }

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductCreate> GetAllProducts()
        {
            return _productService.ListProducts(null);
        }

        [HttpGet]
        [Route("{productId?}")]
        public List<ProductCreate> GetProductByID(Guid? productId)
        {
            return _productService.ListProducts(product => product.Id == productId);
        }

        [HttpPost]
        public Guid CreateProduct([FromForm] ProductCreate product)
        {
            return (_productService.CreateProductAsync(product)).Result;
        }
    }
}

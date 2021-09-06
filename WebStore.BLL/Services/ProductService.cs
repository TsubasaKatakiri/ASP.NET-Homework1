using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Interfaces;
using WebStore.BLL.VMs;
using WebStore.DAL.Patterns;
using WebStore.Models;

namespace WebStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _db;

        public ProductService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<Guid> CreateProductAsync(ProductCreate productCreate)
        {
            try
            {
                var product = new Product()
                {
                    Category = productCreate.Category,
                    Name=productCreate.Name,
                    Description=productCreate.Description,
                    Price=productCreate.Price
                };
                product = await _db.Products.CreateAsync(product);
                return product.Id;
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<ProductCreate> ListProducts(Func<Product, bool> expression)
        {
            try
            {
                List<Product> products;
                if (expression == null)
                {
                    products = _db.Products.GetAll().ToList();
                }
                else
                {
                    products = _db.Products.GetAll().Where(expression).ToList();
                }
                return products.Select(p =>
                {
                    return new ProductCreate()
                    {
                        Category = p.Category,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

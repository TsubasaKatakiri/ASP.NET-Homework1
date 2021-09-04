using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Interfaces;
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

        public async Task<bool> GetProductAsync(Guid productId)
        {
            try
            {
                var product = _db.Products.GetAll().Single(p => p.Id.Equals(productId));
                List<Comment> comments = (List<Comment>) _db.Comments.GetAll();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ProductListAsync()
        {
            try
            {
                List<Product> products = (List<Product>)_db.Products.GetAll();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

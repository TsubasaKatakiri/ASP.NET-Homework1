using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.VMs;
using WebStore.Models;

namespace WebStore.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(ProductCreate productCreate);
        List<ProductCreate> ListProducts(Func<Product, bool> expression);
    }
}

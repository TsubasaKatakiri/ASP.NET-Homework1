using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.BLL.Interfaces
{
    public interface IProductService
    {
        Task<bool> ProductListAsync();
        Task<bool> GetProductAsync(Guid productId);
    }
}

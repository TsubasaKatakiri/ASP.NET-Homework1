using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.DAL.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Comment> Comments { get; }

        Task SaveAsync();
    }
}

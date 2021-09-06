using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _db;

        private bool _disposed = false;

        private IRepository<Product> _products;
        private IRepository<Review> _reviews;
        private IRepository<Comment> _comments;

        public UnitOfWork(DbContextOptions<AppDBContext> options)
        {
            _db = new AppDBContext(options);
        }

        public IRepository<Product> Products => _products ?? (_products = new Repository<Product>(_db));
        public IRepository<Review> Reviews => _reviews ?? (_reviews = new Repository<Review>(_db));
        public IRepository<Comment> Comments => _comments ?? (_comments = new Repository<Comment>(_db));

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed){
                return;
            };
            if (disposing)
            {
                _db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

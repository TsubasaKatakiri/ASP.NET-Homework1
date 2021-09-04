using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Interfaces;
using WebStore.DAL.Patterns;
using WebStore.Models;

namespace WebStore.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _db;

        public ReviewService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<bool> CreateReview(int score, string username, string text, string file)
        {
            try
            {
                var review = new Review()
                {
                    Score = score,
                    Username = username,
                    Text = text,
                    File = file,
                    DateCreated = DateTime.Now
                };
                review = await _db.Reviews.CreateAsync(review);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _db;
        private readonly IProductService _productService;

        public ReviewService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<Guid> CreateReviewAsync(ReviewCreate reviewCreate)
        {
            try
            {
                var productId = await _productService.CreateProductAsync(
                    new ProductCreate()
                    {
                        Category = reviewCreate.ProductCategory,
                        Name = reviewCreate.ProductName,
                        Description = reviewCreate.ProductDescription,
                        Price = reviewCreate.ProductPrice
                    });
                var review = new Review()
                {
                    ProductId = productId,
                    Score = reviewCreate.Score,
                    Username = reviewCreate.Username,
                    Text = reviewCreate.Text,
                    File = reviewCreate.File,
                    DateCreated = DateTime.Now
                };
                review = await _db.Reviews.CreateAsync(review);
                return review.Id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ReviewShow> ListReviews(Func<Review, bool> expression)
        {
            try
            {
                List<Review> reviews;
                if (expression == null)
                {
                    reviews = _db.Reviews.GetAll().ToList();
                }
                else
                {
                    reviews = _db.Reviews.GetAll().Where(expression).ToList();
                }
                return reviews.Select(r =>
                {
                    return new ReviewShow()
                    {
                        ProductName = r.Product.Name,
                        Score = r.Score,
                        Username = r.Username,
                        Text = r.Text,
                        File = r.File,
                        DateCreated = r.DateCreated,
                        Comments = r.Comments.Select(c =>
                        {
                            return new CommentShow()
                            {
                                ProductName = c.Review.Product.Name,
                                Username = c.Username,
                                Text = c.Text,
                                DateCreated = c.DateCreated
                            };
                        }).ToList()
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

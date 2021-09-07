using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.BLL.Interfaces;
using WebStore.BLL.VMs;

namespace WebStore.API.Controllers
{
    [Route("api/products/{productId?}")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("reviews")]
        public List<ReviewShow> GetAllReviews(Guid? productId)
        {
            return _reviewService.ListReviews(null, productId);
        }

        [HttpGet]
        [Route("{reviewId?}")]
        public List<ReviewShow> GetReviewByID(Guid? reviewId, Guid? productId)
        {
            return _reviewService.ListReviews(review=>review.Id == reviewId, productId);
        }

        [HttpPost]
        public Guid CreateReview([FromForm]ReviewCreate review, Guid? productId)
        {
            return (_reviewService.CreateReviewAsync(review, productId)).Result;
        }
    }
}

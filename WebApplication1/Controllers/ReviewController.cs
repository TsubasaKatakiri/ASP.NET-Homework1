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
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("reviewall")]
        public List<ReviewShow> GetAllReviews()
        {
            return _reviewService.ListReviews(null);
        }

        [HttpGet]
        [Route("reviewid")]
        public List<ReviewShow> GetReviewByID(Guid guid)
        {
            return _reviewService.ListReviews(review=>review.Id==guid);
        }

        [HttpPost]
        public Guid CreateReview([FromForm]ReviewCreate review)
        {
            return (_reviewService.CreateReviewAsync(review)).Result;
        }
    }
}

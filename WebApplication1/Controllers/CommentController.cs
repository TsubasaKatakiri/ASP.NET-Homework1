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
    [Route("api/products/{productId?}/{reviewId?}")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentsService _commentService { get; set; }

        public CommentController(ICommentsService productService)
        {
            _commentService = productService;
        }

        [Route("commentall")]
        public List<CommentShow> GetAllComments(Guid? reviewId)
        {
            return _commentService.ListComments(null, reviewId);
        }

        [HttpGet]
        [Route("comment")]
        public List<CommentShow> GetCommentByID(Guid? commentId, Guid? reviewId)
        {
            return _commentService.ListComments(product => product.Id == commentId, reviewId);
        }

        [HttpPost]
        public Guid CreateComment([FromForm] CommentCreate comment)
        {
            return (_commentService.CreateCommentAsync(comment)).Result;
        }
    }
}

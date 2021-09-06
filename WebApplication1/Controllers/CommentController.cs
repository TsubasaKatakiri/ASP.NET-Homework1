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
    public class CommentController : ControllerBase
    {
        private ICommentsService _commentService { get; set; }

        public CommentController(ICommentsService productService)
        {
            _commentService = productService;
        }

        [Route("commentall")]
        public List<CommentShow> GetAllComments()
        {
            return _commentService.ListComments(null);
        }

        [HttpGet]
        [Route("commentid")]
        public List<CommentShow> GetCommentByID(Guid guid)
        {
            return _commentService.ListComments(product => product.Id == guid);
        }

        [HttpPost]
        public Guid CreateComment([FromForm] CommentCreate comment)
        {
            return (_commentService.CreateCommentAsync(comment)).Result;
        }
    }
}

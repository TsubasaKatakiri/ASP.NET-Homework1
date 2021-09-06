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
    public class CommentService : ICommentsService
    {
        private readonly IUnitOfWork _db;

        public CommentService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<Guid> CreateComment(CommentCreate commentCreate)
        {
            try
            {
                var comment = new Comment()
                {
                    Username = commentCreate.Username,
                    Text = commentCreate.Text,
                    ReviewId = commentCreate.ReviewId,
                    DateCreated = DateTime.Now
                };
                comment = await _db.Comments.CreateAsync(comment);
                return comment.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CommentShow> ListComments(Func<Comment, bool> expression)
        {
            try
            {
                List<Comment> comments;
                if (expression == null)
                {
                    comments = _db.Comments.GetAll().ToList();
                }
                else
                {
                    comments = _db.Comments.GetAll().Where(expression).ToList();
                }
                return comments.Select(c =>
                {
                    return new CommentShow()
                    {
                        ProductName = c.Review.Product.Name,
                        Username = c.Username,
                        Text = c.Text,
                        DateCreated = c.DateCreated
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

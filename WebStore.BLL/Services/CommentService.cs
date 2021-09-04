using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Interfaces;
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

        public async Task<bool> CreateComment(string username, string text)
        {
            try
            {
                var comment = new Comment()
                {
                    Username = username,
                    Text = text,
                    DateCreated = DateTime.Now
                };
                comment = await _db.Comments.CreateAsync(comment);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

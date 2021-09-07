using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.VMs;
using WebStore.Models;

namespace WebStore.BLL.Interfaces
{
    public interface ICommentsService
    {
        Task<Guid> CreateCommentAsync(CommentCreate commentCreate);
        List<CommentShow> ListComments(Func<Comment, bool> expression, Guid? reviewId);
    }
}

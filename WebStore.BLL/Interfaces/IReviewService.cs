using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.BLL.Interfaces
{
    public interface IReviewService
    {
        Task<bool> CreateReview(int score, string username, string text, string file);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.VMs;
using WebStore.Models;

namespace WebStore.BLL.Interfaces
{
    public interface IReviewService
    {
        Task<Guid> CreateReviewAsync(ReviewCreate reviewCreate);
        List<ReviewShow> ListReviews(Func<Review, bool> expression);
    }
}

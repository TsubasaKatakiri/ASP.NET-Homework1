using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.BLL.Interfaces
{
    public interface ICommentsService
    {
        Task<bool> CreateComment(string username, string text);
    }
}

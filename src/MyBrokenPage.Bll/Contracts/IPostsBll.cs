using MyBrokenPage.Models;
using System.Collections.Generic;

namespace MyBrokenPage.Bll.Contracts
{
    public interface IPostsBll
    {
        IEnumerable<PostModel> GetAll(string search);

        void Delete(int id, string username);

        void Add(PostModel post);
    }
}

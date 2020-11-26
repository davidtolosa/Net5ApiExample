using Net5Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Core.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPost(int id);

        Task InsertPost(Post post);

        Task<bool> UpdatePost(Post post);

        Task<bool> DeletePost(int id);
    }
}
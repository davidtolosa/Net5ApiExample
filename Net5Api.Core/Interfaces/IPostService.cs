using Net5Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Core.Interfaces
{
    public interface IPostService
    {
        public Task<bool> DeletePost(int id);

        public Task<Post> GetPost(int id);

        public Task<IEnumerable<Post>> GetPosts();

        public Task InsertPost(Post post);

        public Task<bool> UpdatePost(Post post);    
    }
}
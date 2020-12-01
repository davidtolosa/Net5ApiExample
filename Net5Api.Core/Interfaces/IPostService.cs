using Net5Api.Core.CustomEntities;
using Net5Api.Core.Entities;
using Net5Api.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Core.Interfaces
{
    public interface IPostService
    {
        public Task<bool> DeletePost(int id);

        public Task<Post> GetPost(int id);

        public PagedList<Post> GetPosts(PostQueryFilter filters);

        public Task InsertPost(Post post);

        public Task<bool> UpdatePost(Post post);    
    }
}
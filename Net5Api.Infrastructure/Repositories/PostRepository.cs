using Microsoft.EntityFrameworkCore;
using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using Net5Api.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Api.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly Net5ApiContext _context;

        public PostRepository(Net5ApiContext net5ApiContext)
        {
            _context = net5ApiContext;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;
        }

        public async Task<Post> GetPost(int id) {

            var post = await _context.Posts.FirstOrDefaultAsync(p => p.UserId == id);

            return post;
        }
    }
}

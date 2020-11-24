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

        public async Task InsertPost(Post post) {

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post) {

            var currentPost = await GetPost(post.PostId);
            currentPost.Date = post.Date;
            currentPost.Description = post.Description;
            currentPost.Image = post.Image;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeletePost(int id) {

            var currentPost = await GetPost(id);

            _context.Posts.Remove(currentPost);

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}

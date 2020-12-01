using Net5Api.Core.CustomEntities;
using Net5Api.Core.Entities;
using Net5Api.Core.Exceptions;
using Net5Api.Core.Interfaces;
using Net5Api.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Api.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public PagedList<Post> GetPosts(PostQueryFilter filters)
        {
            var posts = _unitOfWork.PostRepository.GetAll();

            if (filters.UserId != null) {
                posts = posts.Where(p => p.UserId == filters.UserId);
            }

            if (filters.Date != null) {
                posts = posts.Where(p => p.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }

            if (filters.Description != null) {
                posts = posts.Where(p => p.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            var pagedPosts = PagedList<Post>.Create(posts, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }

        public async Task InsertPost(Post post)
        {
            var user = _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null) {
                throw new BusinessException("User doesn't exist");
            }

            var userPosts = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if (userPosts.Count() < 10)
            {
                var lastPost = userPosts.OrderByDescending(p => p.Date).LastOrDefault();
                if ((lastPost.Date - DateTime.Now).TotalDays < 7) {
                    throw new BusinessException("You are not able to publish the post");
                }
            }


            if (post.Description.Contains("Sexo")) {
                throw new Exception("Content not allowed");
            }

            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}

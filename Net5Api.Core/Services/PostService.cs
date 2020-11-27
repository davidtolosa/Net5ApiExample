using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }

        public async Task InsertPost(Post post)
        {
            var user = _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null) {
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("Sexo")) {
                throw new Exception("Content not allowed");
            }

            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
            return true;
        }
    }
}

﻿using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;

        public PostService(IRepository<Post> postRepository, IRepository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _postRepository.Delete(id);
            return true;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepository.GetAll();
        }

        public async Task InsertPost(Post post)
        {
            var user = await _userRepository.GetById(post.UserId);
            if (user == null) {
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("Sexo")) {
                throw new Exception("Content not allowed");
            }

            await _postRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            await _postRepository.Update(post);
            return true;
        }
    }
}
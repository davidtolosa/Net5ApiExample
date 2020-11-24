using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net5Api.Api.Responses;
using Net5Api.Core.DTOs;
using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using Net5Api.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts() {

            var posts = await _postRepository.GetPosts();

            var postsDtos = _mapper.Map<IEnumerable<PostDTO>>(posts);

            var response = new ApiResponse<IEnumerable<PostDTO>>(postsDtos);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id) {
            var post = await _postRepository.GetPost(id);

            var postDto = _mapper.Map<PostDTO>(post);

            var response = new ApiResponse<PostDTO>(postDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDTO postDTO) {

            var post = _mapper.Map<Post>(postDTO);

            await _postRepository.InsertPost(post);

            postDTO = _mapper.Map<PostDTO>(post);
            var reponse = new ApiResponse<PostDTO>(postDTO);

            return Ok(reponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PostDTO postDTO) {
            var post = _mapper.Map<Post>(postDTO);

            post.PostId = id;

            var result = await _postRepository.UpdatePost(post);

            var response = new ApiResponse<bool>(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var result = await _postRepository.DeletePost(id);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}

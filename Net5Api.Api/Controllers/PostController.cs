using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

            return Ok(_mapper.Map<IEnumerable<PostDTO>>(posts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id) {
            var post = await _postRepository.GetPost(id);

            return Ok(_mapper.Map<PostDTO>(post));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDTO post) {
            await _postRepository.InsertPost(_mapper.Map<Post>(post));

            return Ok(post);
        }
    }
}

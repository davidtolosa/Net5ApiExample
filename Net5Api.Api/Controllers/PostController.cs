using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net5Api.Api.Responses;
using Net5Api.Core.DTOs;
using Net5Api.Core.Entities;
using Net5Api.Core.Interfaces;
using Net5Api.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Net5Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PostDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PostDTO>>))]
        public IActionResult GetPosts([FromQuery] PostQueryFilter filters) {

           var posts = _postService.GetPosts(filters);

             var postsDtos = _mapper.Map<IEnumerable<PostDTO>>(posts);

             var response = new ApiResponse<IEnumerable<PostDTO>>(postsDtos);
      
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id) {
            var post = await _postService.GetPost(id);

            var postDto = _mapper.Map<PostDTO>(post);

            var response = new ApiResponse<PostDTO>(postDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDTO postDTO) {

            var post = _mapper.Map<Post>(postDTO);

            await _postService.InsertPost(post);

            postDTO = _mapper.Map<PostDTO>(post);
            var reponse = new ApiResponse<PostDTO>(postDTO);

            return Ok(reponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PostDTO postDTO) {
            var post = _mapper.Map<Post>(postDTO);

            post.Id = id;

            var result = await _postService.UpdatePost(post);

            var response = new ApiResponse<bool>(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var result = await _postService.DeletePost(id);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Net5Api.Core.Interfaces;
using Net5Api.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Net5Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts() {

            var posts = await _postRepository.GetPosts();

            return Ok(posts);
        }
    }
}

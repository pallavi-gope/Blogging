using Blogging.Web.Models.Domain;
using Blogging.Web.Models.ViewModels;
using Blogging.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostLikeController : ControllerBase
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
        {
            var model = new BlogPostLike
            {
                BlogPostId = addLikeRequest.BlogPostId,
                UserId = addLikeRequest.UserId
            };

            var result = await blogPostLikeRepository.AddLikeForBlog(model);

            return Ok(result);
        }
        [HttpGet]
        [Route("{blogPostId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikesForBlog([FromRoute] Guid blogPostId)
        {
           var totalLikes = await blogPostLikeRepository.GetTotalLikes(blogPostId);
            return Ok(totalLikes);
        }
    }
}
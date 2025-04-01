using BlogPlatform.Application.Interfaces;
using BlogPlatform.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _postService.GetPostsWithCommentsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetUserPosts(string userId)
        {
            var posts = await _postService.GetPostsByUserIdAsync(userId);
            return Ok(posts);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByCategory(int categoryId)
        {
            var posts = await _postService.GetPostsByCategoryAsync(categoryId);
            return Ok(posts);
        }

        [HttpGet("tag/{tagId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByTag(int tagId)
        {
            var posts = await _postService.GetPostsByTagAsync(tagId);
            return Ok(posts);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost([FromBody] CreatePostDto model)
        {
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
            };

            var createdPost = await _postService.CreatePostAsync(post);
            return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostDto model)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            // Check if the user owns the post
            if (post.UserId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return Forbid();
            }

            post.Title = model.Title;
            post.Content = model.Content;
            post.UpdatedAt = DateTime.UtcNow;

            await _postService.UpdatePostAsync(post);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            // Check if the user owns the post
            if (post.UserId != User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return Forbid();
            }

            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }

    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class UpdatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
} 
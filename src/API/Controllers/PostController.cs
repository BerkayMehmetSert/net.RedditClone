using Application.Contracts.Requests.Post;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _service;

    public PostController(IPostService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    public IActionResult CreatePost([FromBody] CreatePostRequest request)
    {
        _service.CreatePost(request);
        return Ok();
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetPostById([FromRoute] Guid id)
    {
        var post = _service.GetPostById(id);
        return Ok(post);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPosts()
    {
        var posts = _service.GetAllPosts();
        return Ok(posts);
    }
    
    [HttpGet("user/{username}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPostsByUsername([FromRoute] string username)
    {
        var posts = _service.GetAllPostsByUsername(username);
        return Ok(posts);
    }
    
    [HttpGet("subreddit/{subredditId}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllPostsBySubredditId([FromRoute] Guid subredditId)
    {
        var posts = _service.GetAllPostsBySubredditId(subredditId);
        return Ok(posts);
    }
}
using Application.Contracts.Requests.Subreddit;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SubredditController : ControllerBase
{
    private readonly ISubredditService _service;

    public SubredditController(ISubredditService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateSubreddit([FromBody] CreateSubredditRequest request)
    {
        _service.CreateSubreddit(request);
        return Ok();
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetSubredditById([FromRoute] Guid id)
    {
        var subreddit = _service.GetSubredditById(id);
        return Ok(subreddit);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllSubreddits()
    {
        var subreddits = _service.GetAllSubreddits();
        return Ok(subreddits);
    }
}
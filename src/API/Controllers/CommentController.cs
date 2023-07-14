using Application.Contracts.Requests.Comment;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _service;

    public CommentController(ICommentService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    public IActionResult CreateComment([FromBody] CreateCommentRequest request)
    {
        _service.CreateComment(request);
        return Ok();
    }

    [HttpGet("post/{postId}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllCommentsByPostId([FromRoute] Guid postId)
    {
        var comments = _service.GetAllCommentsByPostId(postId);
        return Ok(comments);
    }

    [HttpGet("user/{userId?}")]
    [Authorize(Roles = "Admin, User")]
    public IActionResult GetAllCommentsByUserId([FromRoute] Guid? userId = null)
    {
        var comments = _service.GetAllCommentsByUserId(userId);
        return Ok(comments);
    }
}
using Application.Contracts.Requests.Vote;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VoteController : ControllerBase
{
    private readonly IVoteService _service;

    public VoteController(IVoteService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    public IActionResult VotePost([FromBody] CreateVoteRequest request)
    {
        _service.VotePost(request);
        return Ok();
    }
}
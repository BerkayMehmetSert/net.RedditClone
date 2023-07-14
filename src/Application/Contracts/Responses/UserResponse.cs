using Core.Application.Response;

namespace Application.Contracts.Responses;

public class UserResponse : BaseResponse
{
    public string Username { get; set; } 
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
    public List<CommentResponse>? Comments { get; set; }
    public List<PostResponse>? Posts { get; set; }
    public List<SubredditResponse>? Subreddits { get; set; }
    public List<VoteResponse>? Votes { get; set; }
}
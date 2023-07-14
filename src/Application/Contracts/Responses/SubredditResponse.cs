using Core.Application.Response;

namespace Application.Contracts.Responses;

public class SubredditResponse : BaseResponse
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<PostResponse>? Posts { get; set; }
}
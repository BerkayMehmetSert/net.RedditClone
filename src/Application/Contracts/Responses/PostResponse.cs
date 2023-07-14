using Core.Application.Response;

namespace Application.Contracts.Responses;

public class PostResponse : BaseResponse
{
    public Guid UserId { get; set; }
    public Guid SubredditId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public int VoteCount { get; set; } = 0;
    public DateTime PostedDate { get; set; }
    public List<CommentResponse>? Comments { get; set; }
    public List<VoteResponse>? Votes { get; set; }
}
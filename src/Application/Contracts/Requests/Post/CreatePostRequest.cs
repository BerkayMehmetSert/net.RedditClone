using Core.Application.Request;

namespace Application.Contracts.Requests.Post;

public class CreatePostRequest : BaseRequest
{
    public Guid SubredditId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
}
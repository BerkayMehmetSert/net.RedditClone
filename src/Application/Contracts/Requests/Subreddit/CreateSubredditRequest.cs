using Core.Application.Request;

namespace Application.Contracts.Requests.Subreddit;

public class CreateSubredditRequest : BaseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
}
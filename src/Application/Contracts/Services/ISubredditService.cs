using Application.Contracts.Requests.Subreddit;
using Application.Contracts.Responses;
using Domain.Entities;

namespace Application.Contracts.Services;

public interface ISubredditService
{
    void CreateSubreddit(CreateSubredditRequest request);
    SubredditResponse GetSubredditById(Guid id);
    List<SubredditResponse> GetAllSubreddits();
    Subreddit GetSubredditEntityById(Guid id);
}
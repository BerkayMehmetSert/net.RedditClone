using Application.Contracts.Requests.Subreddit;
using Application.Contracts.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Mappers;

public class SubredditMapper : Profile
{
    public SubredditMapper()
    {
        CreateMap<CreateSubredditRequest, Subreddit>();
        CreateMap<Subreddit, SubredditResponse>();
    }
}
using Application.Contracts.Repositories;
using Core.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Persistence.Context;

namespace Persistence.Repositories;

public class SubredditRepository : BaseRepository<Subreddit, BaseDbContext>, ISubredditRepository
{
    public SubredditRepository(BaseDbContext context, IHttpContextAccessor contextAccessor) : base(context,
        contextAccessor)
    {
    }
}
using Application.Contracts.Repositories;
using Core.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Persistence.Context;

namespace Persistence.Repositories;

public class VoteRepository : BaseRepository<Vote, BaseDbContext>, IVoteRepository
{
    public VoteRepository(BaseDbContext context, IHttpContextAccessor contextAccessor) : base(context,
        contextAccessor)
    {
    }
}
using Application.Contracts.Repositories;
using Core.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Persistence.Context;

namespace Persistence.Repositories;

public class PostRepository : BaseRepository<Post, BaseDbContext>, IPostRepository
{
    public PostRepository(BaseDbContext context, IHttpContextAccessor contextAccessor) : base(context,
        contextAccessor)
    {
    }
}
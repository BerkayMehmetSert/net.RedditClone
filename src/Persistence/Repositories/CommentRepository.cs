using Application.Contracts.Repositories;
using Core.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Persistence.Context;

namespace Persistence.Repositories;

public class CommentRepository : BaseRepository<Comment, BaseDbContext>, ICommentRepository
{
    public CommentRepository(BaseDbContext context, IHttpContextAccessor contextAccessor) : base(context,
        contextAccessor)
    {
    }
}
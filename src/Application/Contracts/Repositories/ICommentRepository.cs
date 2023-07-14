using Core.Persistence;
using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
}
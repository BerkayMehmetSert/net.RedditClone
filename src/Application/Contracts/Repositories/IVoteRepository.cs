using Core.Persistence;
using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IVoteRepository : IBaseRepository<Vote>
{
}
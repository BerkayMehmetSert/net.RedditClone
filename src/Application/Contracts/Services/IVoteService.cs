using Application.Contracts.Requests.Vote;

namespace Application.Contracts.Services;

public interface IVoteService
{
    void VotePost(CreateVoteRequest request); 
}
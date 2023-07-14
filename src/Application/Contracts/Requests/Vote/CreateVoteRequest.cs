using Core.Application.Request;
using Domain.Enums;

namespace Application.Contracts.Requests.Vote;

public class CreateVoteRequest : BaseRequest
{
    public Guid PostId { get; set; }
    public VoteType VoteType { get; set; }
}
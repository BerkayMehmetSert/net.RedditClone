using Core.Application.Response;
using Domain.Enums;

namespace Application.Contracts.Responses;

public class VoteResponse : BaseResponse
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
    public VoteType VoteType { get; set; }
}
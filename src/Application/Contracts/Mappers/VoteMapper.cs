using Application.Contracts.Requests.Vote;
using Application.Contracts.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Mappers;

public class VoteMapper : Profile
{
    public VoteMapper()
    {
        CreateMap<CreateVoteRequest, Vote>();
        CreateMap<Vote, VoteResponse>();
    }
}
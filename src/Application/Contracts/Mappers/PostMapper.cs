using Application.Contracts.Requests.Post;
using Application.Contracts.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Mappers;

public class PostMapper : Profile
{
    public PostMapper()
    {
        CreateMap<CreatePostRequest, Post>();
        CreateMap<Post, PostResponse>();
    }
}
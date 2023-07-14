using Application.Contracts.Requests.Comment;
using Application.Contracts.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Mappers;

public class CommentMapper : Profile
{
    public CommentMapper()
    {
        CreateMap<CreateCommentRequest, Comment>();
        CreateMap<Comment, CommentResponse>();
    }
}
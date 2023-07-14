using Application.Contracts.Constants.Vote;
using Application.Contracts.Repositories;
using Application.Contracts.Requests.Vote;
using Application.Contracts.Services;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services;

public class VoteService : IVoteService
{
    private readonly IVoteRepository _voteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPostService _postService;
    private readonly IUserService _userService;

    public VoteService(
        IVoteRepository voteRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IPostService postService,
        IUserService userService
    )
    {
        _voteRepository = voteRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _postService = postService;
        _userService = userService;
    }

    public void VotePost(CreateVoteRequest request)
    {
        var userId = _userService.GetUserIdFromToken();
        var post = _postService.GetPostEntityById(request.PostId);
        CheckIfUserAlreadyVoted(userId, post.Id, request.VoteType);

        var vote = _mapper.Map<Vote>(request);
        vote.UserId = userId;
        vote.Post = post;
        
        var count = request.VoteType.Equals(VoteType.Upvote) ? 1 : -1;
        _postService.UpdatePostVoteCount(request.PostId, count);
        _voteRepository.Add(vote);
        _unitOfWork.SaveChanges();
    }

    private void CheckIfUserAlreadyVoted(Guid userId, Guid postId, VoteType voteType)
    {
        var vote = _voteRepository.Get(x => x.UserId.Equals(userId) && x.PostId.Equals(postId));
        if (vote is not null && vote.VoteType.Equals(voteType))
            throw new BusinessException(VoteBusinessMessages.UserAlreadyVoted);
    }
}
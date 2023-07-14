using Application.Contracts.Constants.Subreddit;
using Application.Contracts.Repositories;
using Application.Contracts.Requests.Subreddit;
using Application.Contracts.Responses;
using Application.Contracts.Services;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence;
using Core.Utilities.Filter;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class SubredditService : ISubredditService
{
    private readonly ISubredditRepository _subredditRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public SubredditService(
        ISubredditRepository subredditRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper, 
        IUserService userService
        )
    {
        _subredditRepository = subredditRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userService = userService;
    }

    public void CreateSubreddit(CreateSubredditRequest request)
    {
        var userId = _userService.GetUserIdFromToken();
        CheckIfSubredditExistsByName(request.Name);
        FilterHelper.FilteredText(request.Name + request.Description);
        
        var subreddit = _mapper.Map<Subreddit>(request);
        subreddit.UserId = userId;
        _subredditRepository.Add(subreddit);
        _unitOfWork.SaveChanges();
    }

    public SubredditResponse GetSubredditById(Guid id)
    {
        var subreddit = GetSubredditEntityById(id);
        return _mapper.Map<SubredditResponse>(subreddit);
    }

    public List<SubredditResponse> GetAllSubreddits()
    {
        var subreddits = _subredditRepository.GetAll();
        return _mapper.Map<List<SubredditResponse>>(subreddits);
    }

    public Subreddit GetSubredditEntityById(Guid id)
    {
        var subreddit = _subredditRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.Posts)
        );
        if (subreddit is null)
            throw new NotFoundException(SubredditBusinessMessages.SubredditNotFound);
        return subreddit;
    }

    private void CheckIfSubredditExistsByName(string name)
    {
        var subreddit = _subredditRepository.Get(x => x.Name.Equals(name));
        if (subreddit is not null)
            throw new BusinessException(SubredditBusinessMessages.SubredditAlreadyExists);
    }
}
using Application.Contracts.Constants.Post;
using Application.Contracts.Repositories;
using Application.Contracts.Requests.Post;
using Application.Contracts.Responses;
using Application.Contracts.Services;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence;
using Core.Utilities.Filter;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ISubredditService _subredditService;
    private readonly IUserService _userService;

    public PostService(
        IPostRepository postRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ISubredditService subredditService,
        IUserService userService
    )
    {
        _postRepository = postRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _subredditService = subredditService;
        _userService = userService;
    }

    public void CreatePost(CreatePostRequest request)
    {
        var userId = _userService.GetUserIdFromToken();
        var subreddit = _subredditService.GetSubredditEntityById(request.SubredditId);
        FilterHelper.FilteredText(request.Name + request.Url + request.Description);
        var post = _mapper.Map<Post>(request);
        post.UserId = userId;
        post.Subreddit = subreddit;
        _postRepository.Add(post);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePostVoteCount(Guid postId, int voteCount)
    {
        var post = GetPostEntityById(postId);
        post.VoteCount += voteCount;
        _postRepository.Update(post);
        _unitOfWork.SaveChanges();
    }

    public PostResponse GetPostById(Guid id)
    {
        var post = GetPostEntityById(id);
        return _mapper.Map<PostResponse>(post);
    }

    public List<PostResponse> GetAllPosts()
    {
        var posts = _postRepository.GetAll(
            include: source => source
                .Include(x => x.Comments)
                .Include(x => x.Votes)
        );
        return _mapper.Map<List<PostResponse>>(posts);
    }

    public List<PostResponse> GetAllPostsByUsername(string username)
    {
        var user = _userService.GetUserEntityByUsername(username);
        var posts = _postRepository.GetAll(
            predicate: x => x.User.Equals(user),
            include: source => source
                .Include(x => x.Comments)
                .Include(x => x.Votes)
        );
        return _mapper.Map<List<PostResponse>>(posts);
    }

    public List<PostResponse> GetAllPostsBySubredditId(Guid subredditId)
    {
        var subreddit = _subredditService.GetSubredditEntityById(subredditId);
        var posts = _postRepository.GetAll(
            predicate: x => x.Subreddit.Equals(subreddit),
            include: source => source
                .Include(x => x.Comments)
                .Include(x => x.Votes)
        );
        return _mapper.Map<List<PostResponse>>(posts);
    }

    public Post GetPostEntityById(Guid id)
    {
        var post = _postRepository.Get(
            predicate: x => x.Id.Equals(id),
            include: source => source
                .Include(x => x.Comments)
                .Include(x => x.Votes)
        );
        if (post is null)
            throw new NotFoundException(PostBusinessMessages.PostNotFound);
        return post;
    }
}
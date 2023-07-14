using Application.Contracts.Constants.Comment;
using Application.Contracts.Repositories;
using Application.Contracts.Requests.Comment;
using Application.Contracts.Responses;
using Application.Contracts.Services;
using AutoMapper;
using Core.Persistence;
using Core.Utilities.Date;
using Core.Utilities.Filter;
using Domain.Entities;
using Infrastructure.EmailService;
using Infrastructure.EmailService.Model;

namespace Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPostService _postService;
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    public CommentService(
        ICommentRepository commentRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IPostService postService,
        IUserService userService,
        IEmailService emailService
    )
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _postService = postService;
        _userService = userService;
        _emailService = emailService;
    }

    public void CreateComment(CreateCommentRequest request)
    {
        var userId = _userService.GetUserIdFromToken();
        var post = _postService.GetPostEntityById(request.PostId);
        FilterHelper.FilteredText(request.Text);

        var comment = _mapper.Map<Comment>(request);
        comment.UserId = userId;
        comment.Post = post;
        comment.CommentDate = DateHelper.GetCurrentDate();
        
        var emailMessage = new EmailMessage(
            post.User.Email,
            CommentBusinessMessages.CommentSubject,
            CommentBusinessMessages.CommentContent
        );
        _emailService.SendEmail(emailMessage);
        _commentRepository.Add(comment);
        _unitOfWork.SaveChanges();
    }

    public List<CommentResponse> GetAllCommentsByPostId(Guid postId)
    {
        var comments = _commentRepository.GetAll(predicate: x => x.PostId.Equals(postId));
        return _mapper.Map<List<CommentResponse>>(comments);
    }

    public List<CommentResponse> GetAllCommentsByUserId(Guid? userId = null)
    {
        var id = userId ?? _userService.GetUserIdFromToken();
        var comments = _commentRepository.GetAll(predicate: x => x.UserId.Equals(id));
        return _mapper.Map<List<CommentResponse>>(comments);
    }
}
using Application.Contracts.Requests.Comment;
using Application.Contracts.Responses;

namespace Application.Contracts.Services;

public interface ICommentService
{
    void CreateComment(CreateCommentRequest request);
    List<CommentResponse> GetAllCommentsByPostId(Guid postId);
    List<CommentResponse> GetAllCommentsByUserId(Guid? userId = null);
}
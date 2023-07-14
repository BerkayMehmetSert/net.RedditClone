using Core.Application.Response;

namespace Application.Contracts.Responses;

public class CommentResponse : BaseResponse
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
    public string Text { get; set; }
    public DateTime CommentDate { get; set; }
}
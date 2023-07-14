using Core.Application.Request;

namespace Application.Contracts.Requests.Comment;

public class CreateCommentRequest : BaseRequest
{
    public Guid PostId { get; set; }
    public string Text { get; set; }
}
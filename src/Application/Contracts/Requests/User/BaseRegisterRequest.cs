using Core.Application.Request;

namespace Application.Contracts.Requests.User;

public abstract class BaseRegisterRequest : BaseRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
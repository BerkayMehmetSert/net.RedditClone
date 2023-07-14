using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Entities;

[Table(name: "Users", Schema = "dbo")]
public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
    public virtual List<Comment>? Comments { get; set; }
    public virtual List<Post>? Posts { get; set; }
    public virtual List<Subreddit>? Subreddits { get; set; }
    public virtual List<Vote>? Votes { get; set; }
}
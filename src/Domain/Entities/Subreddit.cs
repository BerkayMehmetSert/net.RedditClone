using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Entities;

[Table(name: "Subreddits", Schema = "dbo")]
public class Subreddit : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Post>? Posts { get; set; }
}
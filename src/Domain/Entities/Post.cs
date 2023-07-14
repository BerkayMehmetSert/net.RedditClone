using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Entities;

[Table(name: "Posts", Schema = "dbo")]
public class Post : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid SubredditId { get; set; }
    public virtual Subreddit Subreddit { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public int VoteCount { get; set; } = 0;
    public DateTime PostedDate { get; set; }
    public virtual List<Comment>? Comments { get; set; }
    public virtual List<Vote>? Votes { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;

namespace Domain.Entities;

[Table(name: "Comments", Schema = "dbo")]
public class Comment : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid PostId { get; set; }
    public virtual Post Post { get; set; }
    public string Text { get; set; }
    public DateTime CommentDate { get; set; }
}
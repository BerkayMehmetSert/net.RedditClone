using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain;
using Domain.Enums;

namespace Domain.Entities;

[Table(name: "Votes", Schema = "dbo")]
public class Vote : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid PostId { get; set; }
    public virtual Post Post { get; set; }
    public VoteType VoteType { get; set; }
}
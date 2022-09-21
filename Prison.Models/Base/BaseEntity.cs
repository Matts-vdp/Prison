using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prison.Models.Base;

public abstract class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public Guid Id { get; set; }
}

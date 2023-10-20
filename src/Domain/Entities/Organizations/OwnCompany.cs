using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities.Organizations;

[Table("OwnCompany", Schema = "Organization")]
public class OwnCompany : Company
{
    public virtual ICollection<User> Users { get; init; } = new List<User>();
}
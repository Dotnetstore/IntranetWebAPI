using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Contacts;

public class EmailInformation : BaseAuditableEntity
{
    public required EmailType EmailType { get; set; }
    
    public required string Text { get; set; }
}
using Domain.Resources;
using Domain.Services;

namespace Domain.Enums;

public abstract class EmailType : Enumeration<EmailType>
{
    public static readonly EmailType RegistrationEmail = new RegistrationEmailType();

    private EmailType(Guid value, string name) : base(value, name)
    {
    }

    public abstract string Text { get; }
    
    private sealed class RegistrationEmailType : EmailType
    {
        public RegistrationEmailType() : base(
            new Guid("2899BED0-BC4D-4773-9279-493D9C17A033"), "RegistrationEmail")
        {
        }

        public override string Text => ContactInformationTypeText.RegistrationEmailAddress;
    }
}
using Domain.Resources;
using Domain.Services;

namespace Domain.Enums;

public abstract class ContactInformationType : Enumeration<ContactInformationType>
{
    public static readonly ContactInformationType RegisterEmailAddress = new RegisterEmailAddressContactInformationType();

    private ContactInformationType(Guid value, string name) : base(value, name)
    {
    }

    public abstract string Text { get; }

    private sealed class RegisterEmailAddressContactInformationType : ContactInformationType
    {
        internal RegisterEmailAddressContactInformationType() :
            base(new Guid("2899BED0-BC4D-4773-9279-493D9C17A033"), "RegisterEmailAddress")
        {
        }

        public override string Text => ContactInformationTypeText.RegisterEmailAddress;
    }
}
namespace Domain.Exceptions;

public sealed class SwedishSocialSecurityNumberException : Exception
{
    public SwedishSocialSecurityNumberException()
    {
    }

    public SwedishSocialSecurityNumberException(string message) : base(message)
    {
    }

    public SwedishSocialSecurityNumberException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
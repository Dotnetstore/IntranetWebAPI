namespace Domain.Exceptions;

public sealed class SwedishCorporateNumberException : Exception
{
    public SwedishCorporateNumberException()
    {
    }

    public SwedishCorporateNumberException(string message) : base(message)
    {
    }

    public SwedishCorporateNumberException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
namespace Domain.Validations;

public static class LuhnAlgorithm
{
    private static readonly int[] DoubledValues = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

    public static bool ValidateCheckDigit(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length < 2)
        {
            return false;
        }

        var sum = 0;
        var shouldApplyDouble = true;

        for (var index = value.Length - 2; index >= 0; index--)
        {
            var currentDigit = value[index] - '0';

            if (currentDigit is < 0 or > 9)
            {
                return false;
            }

            sum += shouldApplyDouble ? DoubledValues[currentDigit] : currentDigit;
            shouldApplyDouble = !shouldApplyDouble;
        }

        var checkDigit = (10 - (sum % 10)) % 10;

        return value[^1] - '0' == checkDigit;
    }
}
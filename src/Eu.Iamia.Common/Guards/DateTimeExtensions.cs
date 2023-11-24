namespace Eu.Iamia.Common.Guards;

public static class DateTimeExtensions
{
    public static DateTime GuardIsUtcKind(this DateTime value)
    {
        const DateTimeKind expected = DateTimeKind.Utc;
        if (value.Kind == expected)
        {
            return value;
        }

        throw new ArgumentException($"Expected {expected} actual: {value.Kind}", nameof(value));
    }

    public static DateTime GuardIsLocalKind(this DateTime value)
    {
        const DateTimeKind expected = DateTimeKind.Local;
        if (value.Kind == expected)
        {
            return value;
        }

        throw new ArgumentException($"Expected {expected} actual: {value.Kind}", nameof(value));
    }

    public static DateTime GuardIsUnspecifiedKind(this DateTime value)
    {
        const DateTimeKind expected = DateTimeKind.Unspecified;
        if (value.Kind == expected)
        {
            return value;
        }

        throw new ArgumentException($"Expected {expected} actual: {value.Kind}", nameof(value));
    }
}
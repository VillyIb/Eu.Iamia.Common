using System.Text.Json.Serialization;

namespace Eu.Iamia.Common.StrongTypes;

public interface IStrong<in T, out TV> : IComparable<T> where TV : notnull
{
    TV Value { get; }
}

[Obsolete("Needs to be verified")]
public abstract record Strong<T, TV>([property: JsonPropertyName("v")] TV Value) : IStrong<T, TV> where T : IStrong<T, TV> where TV : notnull
{
    public int CompareTo(T? other)
    {
        throw new NotImplementedException();
    }

    public static implicit operator TV(Strong<T, TV> s) => s.Value;

    public static bool operator <(Strong<T, TV> left, Strong<T, TV> right)
    {
        return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
    }

    private int CompareTo(Strong<T, TV> right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Strong<T, TV> left, Strong<T, TV> right)
    {
        return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
    }

    public static bool operator >(Strong<T, TV> left, Strong<T, TV> right)
    {
        return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
    }

    public static bool operator >=(Strong<T, TV> left, Strong<T, TV> right)
    {
        return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
    }
}
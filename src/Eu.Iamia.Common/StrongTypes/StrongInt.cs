using System.Text.Json.Serialization;

namespace Eu.Iamia.Common.StrongTypes;

public interface IStrongInt<in T> : IComparable<T>
{
    int Value { get; }
}

public abstract record StrongInt<T>([property: JsonPropertyName("v")] int Value) : IStrongInt<T> where T : IStrongInt<T>
{
    public int CompareTo(T? other) => Value.CompareTo(other?.Value);

    public sealed override string ToString() => Value.ToString();

    public static implicit operator int(StrongInt<T> s) => s.Value;

    public static implicit operator string(StrongInt<T> s) => s.Value.ToString();
}
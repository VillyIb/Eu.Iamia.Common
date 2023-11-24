using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Eu.Iamia.Common.Guards;

namespace Eu.Iamia.Common.StrongTypes;

public interface IStrongDateTime<in T> : IComparable<T>
{
    DateTime Value { get; }
}

public abstract record StrongDateTime<T>(DateTime Value) : IStrongDateTime<T> where T : IStrongDateTime<T>
{
    public DateTime Value { get; protected set; } = Value;

    public int CompareTo(T? other) => Value.CompareTo(other?.Value);

    /// <summary>
    /// Uses Invariant Culture.
    /// </summary>
    /// <returns></returns>
    public sealed override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

    public string ToString(IFormatProvider provider) => Value.ToString(provider);

    public string ToString([StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string? format) => Value.ToString(format);

    public string ToString([StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string? format, IFormatProvider? provider) => Value.ToString(format, provider);
}

public abstract record DateTimeLocal<T>(DateTime Value) : StrongDateTime<T>(Value.GuardIsLocalKind()) where T : IStrongDateTime<T>;


public abstract record DateTimeUtc<T>(DateTime Value) : StrongDateTime<T>(Value.GuardIsUtcKind()) where T : IStrongDateTime<T>;


public abstract record DateTimeUnspecified<T>(DateTime Value) : StrongDateTime<T>(Value.GuardIsUnspecifiedKind()) where T : IStrongDateTime<T>;
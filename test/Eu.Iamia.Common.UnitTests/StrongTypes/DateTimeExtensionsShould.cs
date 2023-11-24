using System.Globalization;
using Eu.Iamia.Common.StrongTypes;

// ReSharper disable StringLiteralTypo

namespace Eu.Iamia.Common.UnitTests.StrongTypes;

public sealed record MyDateTimeUtc(DateTime Value) : DateTimeUtc<MyDateTimeUtc>(Value);

public sealed record MyDateTimeLocal(DateTime Value) : DateTimeLocal<MyDateTimeLocal>(Value);

public sealed record MyDateTimeUnspecified(DateTime Value) : DateTimeUnspecified<MyDateTimeUnspecified>(Value);

public class DateTimeExtensionsShould
{
    [Fact]
    public void MyDateTimeUtc_AcceptsUtcKind()
    {
        _ = new MyDateTimeUtc(DateTime.UtcNow);
    }

    [Fact]
    public void MyDateTimeUtc_RejectsLocalKind()
    {
        _ = Assert.Throws<ArgumentException>(() => new MyDateTimeUtc(DateTime.Now));
    }


    [Fact]
    public void MyDateTimeLocal_AcceptsLocalKind()
    {
        _ = new MyDateTimeLocal(DateTime.Now);
    }

    [Fact]
    public void MyDateTimeLocal_RejectsUtcKind()
    {
        _ = Assert.Throws<ArgumentException>(() => new MyDateTimeLocal(DateTime.UtcNow));
    }


    [Fact]
    public void MyDateTimeUnspecified_AcceptsUnspecifiedKind()
    {
        _ = new MyDateTimeUnspecified(new DateTime(DateTime.UtcNow.Ticks));
    }

    [Fact]
    public void MyDateTimeUnspecified_RejectsUtcKind()
    {
        _ = Assert.Throws<ArgumentException>(() => new MyDateTimeUnspecified(DateTime.UtcNow));
    }

    [Fact]
    public void StrongDateTime_ToString_OK()
    {
        var sut = new MyDateTimeLocal(new DateTime(2023, 11, 22, 23, 0, 0).ToLocalTime());
        var actual = sut.ToString();
        Assert.Equal("11/23/2023 00:00:00", actual);
    }

    [Fact]
    public void StrongDateTime_ToString_F1_OK()
    {
        var sut = new MyDateTimeLocal(new DateTime(2023, 11, 22, 23, 0, 0).ToLocalTime());
        var actual = sut.ToString("yyyy-MMMM-dd HH:mm:ss", CultureInfo.GetCultureInfo("da-DK"));
        Assert.Equal("2023-november-23 00.00.00", actual);
    }

    [Fact]
    public void StrongDateTime_ToString_F2_OK()
    {
        var sut = new MyDateTimeLocal(new DateTime(2023, 11, 22, 23, 0, 0).ToLocalTime());
        var actual = sut.ToString("yyyy-MMM-dd HH:mm:ss", CultureInfo.GetCultureInfo("mk-MK"));
        Assert.Equal("2023-ноем.-23 00:00:00", actual);
    }

    [Fact]
    public void StrongDateTime_ToString_F3_OK()
    {
        var sut = new MyDateTimeLocal(new DateTime(2023, 11, 22, 23, 0, 0).ToLocalTime());
        var actual = sut.ToString(CultureInfo.GetCultureInfo("da-DK"));
        Assert.Equal("23.11.2023 00.00.00", actual);
    }

    [Fact]
    public void StrongDateTime_ToString_F4_OK()
    {
        var sut = new MyDateTimeLocal(new DateTime(2023, 11, 22, 23, 0, 0).ToLocalTime());
        var actual = sut.ToString(CultureInfo.GetCultureInfo("mk-MK"));
        Assert.Equal("23.11.2023 00:00:00", actual);
    }

    [Fact]
    public void StrongDateTime_ToString_F5_OK()
    {
        var sut = new MyDateTimeLocal(new DateTime(2023, 11, 22, 23, 0, 0).ToLocalTime());
        var actual = sut.ToString("yyyy-MMMM-dd HH:mm:ss");
        Assert.Equal("2023-november-23 00:00:00", actual);
    }

}
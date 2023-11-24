using Eu.Iamia.Common.StrongTypes;

namespace Eu.Iamia.Common.UnitTests.StrongTypes;

public sealed record PipelineId(int Value) : StrongInt<PipelineId>(Value)
{
    // Needs to be on each non abstract class.
    public static explicit operator PipelineId(int s) => new(s);
}

public sealed record RuntimeId(int Value) : StrongInt<PipelineId>(Value)
{ }

public class StrongIntShould
{
    private static void Alfa(PipelineId pipelineId, RuntimeId runtimeId)
    { }

    [Fact]
    public void Test1()
    {
        var pipelineId = new PipelineId(10);

        var runtimeId = new RuntimeId(20);

        //pipelineId = runtimeId;

        pipelineId = new PipelineId(runtimeId.Value);

        pipelineId = new PipelineId(runtimeId); // Implicit operator on StrongInt<T>

        pipelineId = (PipelineId)30; // Explicit operator on PipelineId

        pipelineId = new(30);
        pipelineId = new(runtimeId);

        Alfa(pipelineId, runtimeId);

        //Alfa(pipelineId.Value, runtimeId.Value);

        //Alfa(runtimeId,pipelineId);

        var @string1 = (string)pipelineId;
        var @string2 = pipelineId.ToString();

        var same = pipelineId.Equals(runtimeId);
    }

    [Theory]
    [InlineData(0, 10, 10)]
    [InlineData(-1, 10, 20)]
    [InlineData(1, 20, 10)]
    public void CompareTo_SameType(int expected, int aValue, int bValue)
    {
        var a = new PipelineId(aValue);
        var b = new PipelineId(bValue);

        var actual = a.CompareTo(b);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 10, 10)]
    [InlineData(-1, 10, 20)]
    [InlineData(1, 20, 10)]
    public void CompareTo_DifferentType(int expected, int aValue, int bValue)
    {
        var a = new PipelineId(aValue);
        var b = new RuntimeId(bValue);

        // illegal
        //_ = a.CompareTo(b);

        var actual = a.Value.CompareTo(b);
        Assert.Equal(expected, actual);
    }
}
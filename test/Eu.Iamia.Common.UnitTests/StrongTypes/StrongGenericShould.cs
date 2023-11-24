using System.Text.Json;
using Eu.Iamia.Common.StrongTypes;

namespace Eu.Iamia.Common.UnitTests.StrongTypes;

public sealed record Alfa1(string Value) : Strong<Alfa1, string>(Value);

public sealed record Alfa2(string Value) : Strong<Alfa2, string>(Value);

public sealed record Bravo(float Value) : Strong<Bravo, float>(Value);

public sealed record Charlie(DateTime Value) : Strong<Charlie, DateTime>(Value);

public sealed record SomeInt1(int Value) : StrongInt<SomeInt1>(Value);

public sealed record SomeInt2(int Value) : Strong<SomeInt2, int>(Value);

// DateTime -> DateTimeLocal, DateTimeUtc, DateTimeUndefined, Date.

// 



public sealed record Hotel(int value);

public record India
{


    public India(int xx)
    {
        Value = xx;
    }

    public required int Value { get; set; }
}
public class StrongGenericShould
{


    [Fact]
    public void Test2()
    {
        var X1 = new Alfa1("Hello");

        var X2 = new Alfa2("Hello");

        //X1 = X2;

        X1 = new Alfa1(X2);
    }



    [Fact]
    public void Serialize1()
    {
        var delta = new Echo(new PipelineId(10), new RuntimeId(20));

        var jsonString = JsonSerializer.Serialize(delta);

        var actual = JsonSerializer.Deserialize<Echo>(jsonString);
    }

    [Fact]
    public void Serialize2()
    {
        var delta = new Foxtrot(new Alfa1("alfa"), new Bravo(1.234f));

        var jsonString = JsonSerializer.Serialize(delta);

        var actual = JsonSerializer.Deserialize<Echo>(jsonString);
    }

    [Fact]
    public void SimpleRecords()
    {
        Hotel hotel = new Hotel(27);
        Hotel h2 = new Hotel(18) { value = 12 };
    }

    [Fact]
    public void ImplicitStrongAny()
    {
        Alfa1 alfa1 = new Alfa1("alfa1");

        string iAlfa = alfa1;

    }
}

public sealed record Echo(PipelineId pipelineId, RuntimeId runtimeId);

public sealed record Foxtrot(Alfa1 Alfa, Bravo Bravo);
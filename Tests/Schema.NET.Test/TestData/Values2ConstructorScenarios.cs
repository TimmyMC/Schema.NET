namespace Schema.NET.Test.TestData;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[SuppressMessage("Style", "IDE0004:Remove Unnecessary Cast")]
public class Values2ConstructorScenarios : TheoryData<Values2TestScenario>
{
    public Values2ConstructorScenarios()
    {
        this.Add(new Values2TestScenario(
            "OneOrMany<T1> with empty values",
            () => new Values<int, string>(new OneOrMany<int>()),
            [],
            false,
            false,
            0,
            0));

        this.Add(new Values2TestScenario(
            "OneOrMany<T1> with single value",
            () => new Values<int, string>(new OneOrMany<int>(42)),
            [42],
            true,
            false,
            1,
            0));

        this.Add(new Values2TestScenario(
            "OneOrMany<T1> with multiple values",
            () => new Values<int, string>(new OneOrMany<int>(1, 2, 3)),
            [1, 2, 3],
            true,
            false,
            3,
            0));

        this.Add(new Values2TestScenario(
            "OneOrMany<T2> with empty values",
            () => new Values<int, string>(new OneOrMany<string>()),
            [],
            false,
            false,
            0,
            0));

        this.Add(new Values2TestScenario(
            "OneOrMany<T2> with single value",
            () => new Values<int, string>(new OneOrMany<string>("hello")),
            ["hello"],
            false,
            true,
            0,
            1));

        this.Add(new Values2TestScenario(
            "OneOrMany<T2> with multiple values",
            () => new Values<int, string>(new OneOrMany<string>("a", "b", "c")),
            ["a", "b", "c"],
            false,
            true,
            0,
            3));

        this.Add(new Values2TestScenario(
            "IEnumerable<object> with empty collection",
            () => new Values<int, string>(new List<object?>()),
            [],
            false,
            false,
            0,
            0));

        this.Add(new Values2TestScenario(
            "IEnumerable<object> with only T1 item",
            () => new Values<int, string>((IEnumerable<object?>)[10]),
            [10],
            true,
            false,
            1,
            0));

        this.Add(new Values2TestScenario(
            "IEnumerable<object> with only T2 item",
            () => new Values<int, string>((IEnumerable<object?>)["x"]),
            ["x"],
            false,
            true,
            0,
            1));

        this.Add(new Values2TestScenario(
            "IEnumerable<object> with mixed T1 and T2 items",
            () => new Values<int, string>((IEnumerable<object?>)[5, "test"]),
            [5, "test"],
            true,
            true,
            1,
            1));

        this.Add(new Values2TestScenario(
            "IEnumerable<object> string values null and whitespace are removed",
            () => new Values<int, string>((IEnumerable<object?>)[string.Empty, null!, "\u2028 \u2029 \u0009 \u000A \u000B \u000C \u000D \u0085"]),
            [],
            false,
            false,
            0,
            0));

        this.Add(new Values2TestScenario(
            "ReadOnlySpan<object> with no arguments (empty)",
            () => new Values<int, string>(ReadOnlySpan<object>.Empty),
            [],
            false,
            false,
            0,
            0));

        this.Add(new Values2TestScenario(
            "ReadOnlySpan<object> with T1 item",
            () => new Values<int, string>((ReadOnlySpan<object>)[999]),
            [999],
            true,
            false,
            1,
            0));

        this.Add(new Values2TestScenario(
            "ReadOnlySpan<object> with T2 item",
            () => new Values<int, string>((ReadOnlySpan<object>)["single"]),
            ["single"],
            false,
            true,
            0,
            1));

        this.Add(new Values2TestScenario(
            "ReadOnlySpan<object> with mixed T1 and T2 items",
            () => new Values<int, string>((ReadOnlySpan<object>)[123, "mixed"]),
            [123, "mixed"],
            true,
            true,
            1,
            1));

        this.Add(new Values2TestScenario(
            "ReadOnlySpan<object> string values null and whitespace are removed",
            () => new Values<int, string>((ReadOnlySpan<object>)[string.Empty, null!, "\u2028 \u2029 \u0009 \u000A \u000B \u000C \u000D \u0085"]),
            [],
            false,
            false,
            0,
            0));

        this.Add(new Values2TestScenario(
            "Collection expression with no arguments (empty)",
            () => [],
            [],
            false,
            false,
            0,
            0));

        this.Add(new Values2TestScenario(
            "Collection expression with T1 item",
            () => [42],
            [42],
            true,
            false,
            1,
            0));

        this.Add(new Values2TestScenario(
            "Collection expression with T2 item",
            () => ["hello"],
            ["hello"],
            false,
            true,
            0,
            1));

        this.Add(new Values2TestScenario(
            "Collection expression with mixed items (T1, T2)",
            () => [99, "single"],
            [99, "single"],
            true,
            true,
            1,
            1));
    }
}

public record Values2TestScenario(
    string Name,
    Func<Values<int, string>> ConstructorCall,
    IReadOnlyCollection<object> ExpectedValues,
    bool ExpectedHasValue1,
    bool ExpectedHasValue2,
    int ExpectedCountValue1,
    int ExpectedCountValue2)
{
    public override string ToString() => this.Name;
}

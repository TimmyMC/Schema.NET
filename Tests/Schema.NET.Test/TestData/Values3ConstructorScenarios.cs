namespace Schema.NET.Test.TestData;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[SuppressMessage("Style", "IDE0004:Remove Unnecessary Cast")]
public class Values3ConstructorScenarios : TheoryData<Values3TestScenario>
{
    public Values3ConstructorScenarios()
    {
        this.Add(new Values3TestScenario(
            "OneOrMany<T1> with empty values",
            () => new Values<int, string, bool>(new OneOrMany<int>()),
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "OneOrMany<T1> with single value",
            () => new Values<int, string, bool>(new OneOrMany<int>(42)),
            [42],
            true,
            false,
            false,
            1,
            0,
            0));

        this.Add(new Values3TestScenario(
            "OneOrMany<T1> with multiple values",
            () => new Values<int, string, bool>(new OneOrMany<int>(1, 2, 3)),
            [1, 2, 3],
            true,
            false,
            false,
            3,
            0,
            0));

        this.Add(new Values3TestScenario(
            "OneOrMany<T2> with empty values",
            () => new Values<int, string, bool>(new OneOrMany<string>()),
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "OneOrMany<T2> with single value",
            () => new Values<int, string, bool>(new OneOrMany<string>("hello")),
            ["hello"],
            false,
            true,
            false,
            0,
            1,
            0));

        this.Add(new Values3TestScenario(
            "OneOrMany<T2> with multiple values",
            () => new Values<int, string, bool>(new OneOrMany<string>("a", "b", "c")),
            ["a", "b", "c"],
            false,
            true,
            false,
            0,
            3,
            0));

        this.Add(new Values3TestScenario(
            "OneOrMany<T3> with empty values",
            () => new Values<int, string, bool>(new OneOrMany<bool>()),
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "OneOrMany<T3> with single value",
            () => new Values<int, string, bool>(new OneOrMany<bool>(true)),
            [true],
            false,
            false,
            true,
            0,
            0,
            1));

        this.Add(new Values3TestScenario(
            "OneOrMany<T3> with multiple values",
            () => new Values<int, string, bool>(new OneOrMany<bool>(true, false)),
            [true, false],
            false,
            false,
            true,
            0,
            0,
            2));

        this.Add(new Values3TestScenario(
            "IEnumerable<object> with empty collection",
            () => new Values<int, string, bool>(new List<object?>()),
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "IEnumerable<object> with only T1 item",
            () => new Values<int, string, bool>((IEnumerable<object?>)[10]),
            [10],
            true,
            false,
            false,
            1,
            0,
            0));

        this.Add(new Values3TestScenario(
            "IEnumerable<object> with only T2 item",
            () => new Values<int, string, bool>((IEnumerable<object?>)["x"]),
            ["x"],
            false,
            true,
            false,
            0,
            1,
            0));

        this.Add(new Values3TestScenario(
            "IEnumerable<object> with only T3 item",
            () => new Values<int, string, bool>((IEnumerable<object?>)[false]),
            [false],
            false,
            false,
            true,
            0,
            0,
            1));

        this.Add(new Values3TestScenario(
            "IEnumerable<object> with mixed T1 and T2 items",
            () => new Values<int, string, bool>((IEnumerable<object?>)[5, "test"]),
            [5, "test"],
            true,
            true,
            false,
            1,
            1,
            0));

        this.Add(new Values3TestScenario(
            "IEnumerable<object> with mixed T1, T2 and T3 items",
            () => new Values<int, string, bool>((IEnumerable<object?>)[5, "test", true]),
            [5, "test", true],
            true,
            true,
            true,
            1,
            1,
            1));

        this.Add(new Values3TestScenario(
            "IEnumerable<object> string values null and whitespace are removed",
            () => new Values<int, string, bool>((IEnumerable<object?>)[string.Empty, null!, "\u2028 \u2029 \u0009 \u000A \u000B \u000C \u000D \u0085"]),
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "ReadOnlySpan<object> with no arguments (empty)",
            () => new Values<int, string, bool>(ReadOnlySpan<object>.Empty),
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "ReadOnlySpan<object> with T1 item",
            () => new Values<int, string, bool>((ReadOnlySpan<object>)[999]),
            [999],
            true,
            false,
            false,
            1,
            0,
            0));

        this.Add(new Values3TestScenario(
            "ReadOnlySpan<object> with T2 item",
            () => new Values<int, string, bool>((ReadOnlySpan<object>)["single"]),
            ["single"],
            false,
            true,
            false,
            0,
            1,
            0));

        this.Add(new Values3TestScenario(
            "ReadOnlySpan<object> with T3 item",
            () => new Values<int, string, bool>((ReadOnlySpan<object>)[true]),
            [true],
            false,
            false,
            true,
            0,
            0,
            1));

        this.Add(new Values3TestScenario(
            "ReadOnlySpan<object> with mixed T1 and T2 items",
            () => new Values<int, string, bool>((ReadOnlySpan<object>)[123, "mixed"]),
            [123, "mixed"],
            true,
            true,
            false,
            1,
            1,
            0));

        this.Add(new Values3TestScenario(
            "ReadOnlySpan<object> with mixed T1, T2 and T3 items",
            () => new Values<int, string, bool>((ReadOnlySpan<object>)[123, "mixed", false]),
            [123, "mixed", false],
            true,
            true,
            true,
            1,
            1,
            1));

        this.Add(new Values3TestScenario(
            "ReadOnlySpan<object> string values null and whitespace are removed",
            () => new Values<int, string, bool>((ReadOnlySpan<object>)[string.Empty, null!, "\u2028 \u2029 \u0009 \u000A \u000B \u000C \u000D \u0085"]),
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "Collection expression with no arguments (empty)",
            () => [],
            [],
            false,
            false,
            false,
            0,
            0,
            0));

        this.Add(new Values3TestScenario(
            "Collection expression with T1 item",
            () => [42],
            [42],
            true,
            false,
            false,
            1,
            0,
            0));

        this.Add(new Values3TestScenario(
            "Collection expression with T2 item",
            () => ["hello"],
            ["hello"],
            false,
            true,
            false,
            0,
            1,
            0));

        this.Add(new Values3TestScenario(
            "Collection expression with T3 item",
            () => [true],
            [true],
            false,
            false,
            true,
            0,
            0,
            1));

        this.Add(new Values3TestScenario(
            "Collection expression with mixed items (T1, T2, T3)",
            () => [99, "single", false],
            [99, "single", false],
            true,
            true,
            true,
            1,
            1,
            1));
    }
}

public record Values3TestScenario(
    string Name,
    Func<Values<int, string, bool>> ConstructorCall,
    IReadOnlyCollection<object> ExpectedValues,
    bool ExpectedHasValue1,
    bool ExpectedHasValue2,
    bool ExpectedHasValue3,
    int ExpectedCountValue1,
    int ExpectedCountValue2,
    int ExpectedCountValue3)
{
    public override string ToString() => this.Name;
}


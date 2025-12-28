namespace Schema.NET.Test.TestData;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[SuppressMessage("Style", "IDE0004:Remove Unnecessary Cast")]
public class Values6ConstructorScenarios : TheoryData<Values6TestScenario>
{
    public Values6ConstructorScenarios()
    {
        this.Add(new Values6TestScenario(
            "OneOrMany<T1> with empty values",
            () => new Values<int, string, bool, double, long, decimal>(new OneOrMany<int>()),
            [],
            false,
            false,
            false,
            false,
            false,
            false,
            0,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "OneOrMany<T1> with single value",
            () => new Values<int, string, bool, double, long, decimal>(new OneOrMany<int>(42)),
            [42],
            true,
            false,
            false,
            false,
            false,
            false,
            1,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "OneOrMany<T2> with single value",
            () => new Values<int, string, bool, double, long, decimal>(new OneOrMany<string>("hello")),
            ["hello"],
            false,
            true,
            false,
            false,
            false,
            false,
            0,
            1,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "OneOrMany<T3> with single value",
            () => new Values<int, string, bool, double, long, decimal>(new OneOrMany<bool>(true)),
            [true],
            false,
            false,
            true,
            false,
            false,
            false,
            0,
            0,
            1,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "OneOrMany<T4> with single value",
            () => new Values<int, string, bool, double, long, decimal>(new OneOrMany<double>(3.14)),
            [3.14],
            false,
            false,
            false,
            true,
            false,
            false,
            0,
            0,
            0,
            1,
            0,
            0));

        this.Add(new Values6TestScenario(
            "OneOrMany<T5> with single value",
            () => new Values<int, string, bool, double, long, decimal>(new OneOrMany<long>(999L)),
            [999L],
            false,
            false,
            false,
            false,
            true,
            false,
            0,
            0,
            0,
            0,
            1,
            0));

        this.Add(new Values6TestScenario(
            "OneOrMany<T6> with single value",
            () => new Values<int, string, bool, double, long, decimal>(new OneOrMany<decimal>(12.34m)),
            [12.34m],
            false,
            false,
            false,
            false,
            false,
            true,
            0,
            0,
            0,
            0,
            0,
            1));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with empty collection",
            () => new Values<int, string, bool, double, long, decimal>(new List<object?>()),
            [],
            false,
            false,
            false,
            false,
            false,
            false,
            0,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with only T1 item",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)[10]),
            [10],
            true,
            false,
            false,
            false,
            false,
            false,
            1,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with only T2 item",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)["x"]),
            ["x"],
            false,
            true,
            false,
            false,
            false,
            false,
            0,
            1,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with only T3 item",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)[false]),
            [false],
            false,
            false,
            true,
            false,
            false,
            false,
            0,
            0,
            1,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with only T4 item",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)[2.71]),
            [2.71],
            false,
            false,
            false,
            true,
            false,
            false,
            0,
            0,
            0,
            1,
            0,
            0));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with only T5 item",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)[777L]),
            [777L],
            false,
            false,
            false,
            false,
            true,
            false,
            0,
            0,
            0,
            0,
            1,
            0));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with only T6 item",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)[56.78m]),
            [56.78m],
            false,
            false,
            false,
            false,
            false,
            true,
            0,
            0,
            0,
            0,
            0,
            1));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> with mixed items",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)[5, "test", true, 1.5, 100L, 99.99m]),
            [5, "test", true, 1.5, 100L, 99.99m],
            true,
            true,
            true,
            true,
            true,
            true,
            1,
            1,
            1,
            1,
            1,
            1));

        this.Add(new Values6TestScenario(
            "IEnumerable<object> string values null and whitespace are removed",
            () => new Values<int, string, bool, double, long, decimal>((IEnumerable<object?>)[string.Empty, null!, "\u2028 \u2029 \u0009 \u000A \u000B \u000C \u000D \u0085"]),
            [],
            false,
            false,
            false,
            false,
            false,
            false,
            0,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "ReadOnlySpan<object> with no arguments (empty)",
            () => new Values<int, string, bool, double, long, decimal>(ReadOnlySpan<object>.Empty),
            [],
            false,
            false,
            false,
            false,
            false,
            false,
            0,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "ReadOnlySpan<object> with mixed items",
            () => new Values<int, string, bool, double, long, decimal>((ReadOnlySpan<object>)[123, "mixed", false, 9.99, 555L, 11.22m]),
            [123, "mixed", false, 9.99, 555L, 11.22m],
            true,
            true,
            true,
            true,
            true,
            true,
            1,
            1,
            1,
            1,
            1,
            1));

        this.Add(new Values6TestScenario(
            "Collection expression with no arguments (empty)",
            () => [],
            [],
            false,
            false,
            false,
            false,
            false,
            false,
            0,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "Collection expression with T1 item",
            () => [42],
            [42],
            true,
            false,
            false,
            false,
            false,
            false,
            1,
            0,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "Collection expression with T2 item",
            () => ["hello"],
            ["hello"],
            false,
            true,
            false,
            false,
            false,
            false,
            0,
            1,
            0,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "Collection expression with T3 item",
            () => [true],
            [true],
            false,
            false,
            true,
            false,
            false,
            false,
            0,
            0,
            1,
            0,
            0,
            0));

        this.Add(new Values6TestScenario(
            "Collection expression with T4 item",
            () => [3.14],
            [3.14],
            false,
            false,
            false,
            true,
            false,
            false,
            0,
            0,
            0,
            1,
            0,
            0));

        this.Add(new Values6TestScenario(
            "Collection expression with T5 item",
            () => [123L],
            [123L],
            false,
            false,
            false,
            false,
            true,
            false,
            0,
            0,
            0,
            0,
            1,
            0));

        this.Add(new Values6TestScenario(
            "Collection expression with T6 item",
            () => [9.99m],
            [9.99m],
            false,
            false,
            false,
            false,
            false,
            true,
            0,
            0,
            0,
            0,
            0,
            1));

        this.Add(new Values6TestScenario(
            "Collection expression with mixed items (T1, T2, T3, T4, T5, T6)",
            () => [99, "single", false, 2.71, 456L, 7.88m],
            [99, "single", false, 2.71, 456L, 7.88m],
            true,
            true,
            true,
            true,
            true,
            true,
            1,
            1,
            1,
            1,
            1,
            1));
    }
}

public record Values6TestScenario(
    string Name,
    Func<Values<int, string, bool, double, long, decimal>> ConstructorCall,
    IReadOnlyCollection<object> ExpectedValues,
    bool ExpectedHasValue1,
    bool ExpectedHasValue2,
    bool ExpectedHasValue3,
    bool ExpectedHasValue4,
    bool ExpectedHasValue5,
    bool ExpectedHasValue6,
    int ExpectedCountValue1,
    int ExpectedCountValue2,
    int ExpectedCountValue3,
    int ExpectedCountValue4,
    int ExpectedCountValue5,
    int ExpectedCountValue6)
{
    public override string ToString() => this.Name;
}


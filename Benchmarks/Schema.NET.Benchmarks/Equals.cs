namespace Schema.NET.Benchmarks;

using System.Collections.Generic;

[MemoryDiagnoser]
public class Equals
{
    public static IEnumerable<OneOrMany<int>> ThisValues() => [new(10, 13)]
    ;
    public static IEnumerable<OneOrMany<int>> OtherValues() => [new(10, 13)]
    ;
    [ParamsSource(nameof(ThisValues))]
    public OneOrMany<int> This { get; set; }

    [ParamsSource(nameof(OtherValues))]
    public OneOrMany<int> Other { get; set; }

    [Benchmark(Baseline = true)]
    public bool CurrentEquals() => this.This.Equals(this.Other);

}

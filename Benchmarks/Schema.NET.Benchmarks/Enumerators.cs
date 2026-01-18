namespace Schema.NET.Benchmarks;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

[MemoryDiagnoser]
//[CPUUsageDiagnoser]
// [DotNetObjectAllocDiagnoser]
// [DotNetObjectAllocJobConfiguration]
//[ShortRunJob(RuntimeMoniker.Net80)]
//[ShortRunJob(RuntimeMoniker.Net90)]
//[ShortRunJob(RuntimeMoniker.Net10_0)]
[ShortRunJob(RuntimeMoniker.Net10_0)]
public class Enumerators
{
    private static readonly ImmutableArray<string> ImmutableArray = ["item"];
    private static readonly OneOrMany<string> OneOrMany = ["item"];
    private static readonly Values<string, int> Values2 = ["item", 4];
    // | Values2_GetEnumerator   | ShortRun-.NET 10.0 | .NET 10.0 | 19.009 ns | 3.7228 ns | 0.2041 ns | 0.0086 |     144 B |


    // ShortRunJob
    // | Method                  | Job                | Runtime   | Mean      | Error     | StdDev    | Gen0   | Allocated |
    // |------------------------ |------------------- |---------- |----------:|----------:|----------:|-------:|----------:|
    // | OneOrMany_GetEnumerator | ShortRun-.NET 10.0 | .NET 10.0 |  1.666 ns | 2.7906 ns | 0.1530 ns |      - |         - |
    // | OneOrMany_GetEnumerator | ShortRun-.NET 8.0  | .NET 8.0  |  7.085 ns | 0.7705 ns | 0.0422 ns | 0.0033 |      56 B |


    //Default job //.NET 10
    // | Method                       | Mean      | Error     | StdDev    | Gen0   | Allocated |
    // |----------------------------- |----------:|----------:|----------:|-------:|----------:|
    // | ImmutableArray_GetEnumerator | 0.9308 ns | 0.0075 ns | 0.0070 ns |      - |         - |
    // | OneOrMany_GetEnumerator      | 1.4922 ns | 0.0119 ns | 0.0093 ns |      - |         - |
    // | Values2_GetEnumerator        | 5.8362 ns | 0.1029 ns | 0.0962 ns | 0.0006 |      32 B |
    //
    [Benchmark(Baseline = true)]
    public void ImmutableArray_GetEnumerator()
    {
        foreach (var input in ImmutableArray)
        {
            Use(input);
        }
    }
    [Benchmark]
    public void OneOrMany_GetEnumerator()
    {
        foreach (var input in OneOrMany)
        {
            Use(input);
        }
    }

    // | Method                | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
    // |---------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
    // | Values2_Foreach       |  1.049 ns | 0.0401 ns | 0.0772 ns |  1.030 ns |      - |         - |
    // | Values2_GetEnumerator | 27.918 ns | 1.7453 ns | 5.1460 ns | 29.507 ns | 0.0178 |     144 B |

    // | Method                | Mean      | Error     | StdDev    | Gen0   | Allocated |
    // |---------------------- |----------:|----------:|----------:|-------:|----------:|
    // | Values2_Foreach       |  2.898 ns | 0.2087 ns | 0.0114 ns |      - |         - |
    // | Values2_GetEnumerator | 39.885 ns | 5.8700 ns | 0.3218 ns | 0.0039 |     224 B |


    [Benchmark]
    public void Values2_Foreach()
    {
        foreach (var value in Values2)
        {
            Use(value);
        }
    }

    [Benchmark]
    public void Values2_GetEnumerator()
    {
        var enumerator = ((IEnumerable<object>)Values2).GetEnumerator();

        while (enumerator.MoveNext())
            Use(enumerator.Current);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Use<T>(T input) { }
}

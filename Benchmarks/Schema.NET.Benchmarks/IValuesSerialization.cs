namespace Schema.NET.Benchmarks;

using System.Collections.Generic;
using System.Collections.Immutable;

[MemoryDiagnoser]
[ShortRunJob]
public class IValuesSerialization
{
    public static IEnumerable<IValues> ValuesSource() => [new OneOrMany<int>(10), new Values<int, string>(10)];
    public static IEnumerable<ImmutableArray<int>> ImmutableArraySource() => [[10]];

    [ParamsSource(nameof(ValuesSource))]
    public IValues Values { get; set; } = null!;

    [ParamsSource(nameof(ImmutableArraySource))]
    public ImmutableArray<int> Arrays { get; set; }

    [Benchmark(Baseline = true)]
    public string ImmutableArray_Serialize() => SchemaSerializer.SerializeObject(this.Arrays);
}

// | Method    | Values               | Mean     | Error   | StdDev  | Gen0   | Allocated |
// |---------- |--------------------- |---------:|--------:|--------:|-------:|----------:|
// | Serialize | Schem(...)nt32] [36] | 124.2 ns | 2.44 ns | 2.90 ns | 0.0031 |     184 B |
// | Serialize | Schem(...)ring] [47] | 147.1 ns | 2.07 ns | 1.94 ns | 0.0048 |     272 B |

// | Method    | Values               | Mean     | Error   | StdDev  | Gen0   | Allocated |
// |---------- |--------------------- |---------:|--------:|--------:|-------:|----------:|
// | Serialize | Schem(...)nt32] [36] | 122.8 ns | 0.87 ns | 0.81 ns | 0.0031 |     184 B |
// | Serialize | Schem(...)ring] [47] | 136.5 ns | 0.64 ns | 0.60 ns | 0.0048 |     272 B |

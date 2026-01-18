namespace Schema.NET.Benchmarks;

using System.Runtime.CompilerServices;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Core;

[MemoryDiagnoser]
public class Book
{
    // [Benchmark(Baseline = true)]
    // public string Serialize_Poco() => SerializePoco();

    [Benchmark]
    public string? Serialize_Nuget() => SerializeNuget();

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string? SerializePoco() => JsonSerializer.Serialize(BookBenchmarkPoco.BookPoco, BookBenchmarkPoco.DefaultSerializationSettings);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string? SerializeNuget() => BookBenchmark.BookThing.ToString();
}
// | Method          | Job               | Arguments             | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
// |---------------- |------------------ |---------------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
// | Serialize_Poco  | Schema.NET-13.0.0 | Default               |  1.850 us | 0.1423 us | 0.0078 us |  1.00 |    0.01 | 0.0648 |   3.58 KB |        1.00 |
// | Serialize_Nuget | Schema.NET-13.0.0 | Default               | 14.215 us | 1.3018 us | 0.0714 us |  7.68 |    0.04 | 0.2289 |  13.31 KB |        3.72 |
// | Serialize_Poco  | v14.0.0           | /p:ForkVersion=14.0.0 |  1.760 us | 0.0593 us | 0.0033 us |  0.95 |    0.00 | 0.0648 |   3.58 KB |        1.00 |
// | Serialize_Nuget | v14.0.0           | /p:ForkVersion=14.0.0 | 14.032 us | 0.3625 us | 0.0199 us |  7.58 |    0.03 | 0.1678 |   10.1 KB |        2.82 |


// | Method          | Job               | Arguments             | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Gen2   | Allocated | Alloc Ratio |
// |---------------- |------------------ |---------------------- |----------:|----------:|----------:|------:|--------:|-------:|-------:|-------:|----------:|------------:|
// | Serialize_Poco  | Schema.NET-13.0.0 | Default               |  1.774 us | 0.1294 us | 0.0071 us |  1.00 |    0.00 | 0.0725 | 0.0019 | 0.0019 |         - |          NA |
// | Serialize_Nuget | Schema.NET-13.0.0 | Default               | 14.514 us | 1.2584 us | 0.0690 us |  8.18 |    0.04 | 0.2289 |      - |      - |   13632 B |          NA |
// | Serialize_Poco  | v14.0.0           | /p:ForkVersion=14.0.0 |  1.781 us | 0.1585 us | 0.0087 us |  1.00 |    0.01 | 0.0744 | 0.0019 | 0.0019 |         - |          NA |
// | Serialize_Nuget | v14.0.0           | /p:ForkVersion=14.0.0 | 13.949 us | 0.6601 us | 0.0362 us |  7.86 |    0.03 | 0.1678 |      - |      - |   10344 B |          NA |


// | Method          | Job               | Arguments             | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
// |---------------- |------------------ |---------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
// | Serialize_Nuget | Schema.NET-13.0.0 | Default               | 14.34 us | 0.148 us | 0.207 us |  1.00 |    0.02 | 0.2289 |  13.31 KB |        1.00 |
// | Serialize_Nuget | v14.0.0           | /p:ForkVersion=14.0.0 | 14.56 us | 0.254 us | 0.364 us |  1.02 |    0.03 | 0.1678 |   10.1 KB |        0.76 |

namespace Schema.NET.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net10_0)]
public abstract class SchemaBenchmarkBase
{
    public Thing Thing { get; set; } = default!;

    public abstract Thing InitialiseThing();

    [GlobalSetup]
    public virtual void Setup() => this.Thing = this.InitialiseThing();

    [Benchmark]
    public string Serialize() => this.Thing.ToString();
}

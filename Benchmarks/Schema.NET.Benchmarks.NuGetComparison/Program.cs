using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Schema.NET.Benchmarks;

var config = DefaultConfig.Instance
    // .AddJob(Job.MediumRun
    //     .WithId("Schema.NET-13.0.0")
    //     .AsBaseline()
    // )
    .AddJob(Job.MediumRun
        .WithMsBuildArguments("/p:ForkVersion=14.0.0")
        .WithId("v14.0.0")
    )
    .AddJob(Job.MediumRun
        .WithMsBuildArguments("/p:ForkVersion=14.0.1-preview.0.20251231090826.1")
        .WithId("v14.0.1-preview.0.20251231090826.1")
    );

BenchmarkRunner.Run<Book>(config);

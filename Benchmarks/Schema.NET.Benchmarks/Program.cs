using Schema.NET.Benchmarks;
using Schema.NET.Benchmarks.Core;

//var debugConfig = DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator);

 // BenchmarkRunner.Run<Enumerators>();
// BenchmarkRunner.Run<Equals>();
// BenchmarkRunner.Run<BookBenchmark>();
BenchmarkRunner.Run<IValuesSerialization>();
// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

//Collection Expressions + implicit struct enumerators
    // | Method    | Mean     | Error    | StdDev   | Min      | Max      | Gen0   | Allocated |
    // |---------- |---------:|---------:|---------:|---------:|---------:|-------:|----------:|
    // | Serialize | 14.89 us | 0.521 us | 0.029 us | 14.85 us | 14.91 us | 0.1678 |   10.1 KB |

//Explicit struct enumerators + typed collection expressions
    // | Method    | Mean     | Error    | StdDev   | Gen0   | Allocated |
    // |---------- |---------:|---------:|---------:|-------:|----------:|
    // | Serialize | 14.25 us | 0.363 us | 0.020 us | 0.1678 |   9.73 KB |


    // | Method    | Mean     | Error    | StdDev   | Gen0   | Allocated |
    // |---------- |---------:|---------:|---------:|-------:|----------:|
    // | Serialize | 14.09 us | 0.780 us | 0.043 us | 0.1678 |   9.67 KB |

//Generic ValuesJsonConverter
    // | Method    | Mean     | Error    | StdDev   | Gen0   | Allocated |
    // |---------- |---------:|---------:|---------:|-------:|----------:|
    // | Serialize | 13.69 us | 0.617 us | 0.034 us | 0.1373 |    8.3 KB |

//decimal/double TryParse span
    // | Method    | Mean     | Error    | StdDev   | Gen0   | Allocated |
    // |---------- |---------:|---------:|---------:|-------:|----------:|
    // | Serialize | 14.59 us | 1.249 us | 0.068 us | 0.1373 |   8.24 KB |


# LinqPerf
Some linq benchmarks

## Current Results

```
// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22489
Unknown processor
.NET SDK=5.0.401
  [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  DefaultJob : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT


|                 Method |         Mean |       Error |      StdDev |       Median |
|----------------------- |-------------:|------------:|------------:|-------------:|
|  UsingLinqFirstElement |    28.576 ns |   0.6163 ns |   0.5463 ns |    28.515 ns |
|   UsingLinqLastElement | 8,771.920 ns | 327.2831 ns | 928.4476 ns | 8,496.361 ns |
| UsingArrayFirstElement |     4.768 ns |   0.1308 ns |   0.1453 ns |     4.734 ns |
|  UsingArrayLastElement | 2,365.606 ns | 112.6120 ns | 326.7078 ns | 2,203.297 ns |
|  UsingLoopFirstElement |     2.481 ns |   0.0897 ns |   0.2316 ns |     2.451 ns |
|   UsingLoopLastElement | 1,053.930 ns |  21.0253 ns |  53.8958 ns | 1,042.778 ns |

// * Warnings *
MultimodalDistribution
  Benchmarks.UsingLinqLastElement: Default  -> It seems that the distribution can have several modes (mValue = 2.97)
  Benchmarks.UsingLoopFirstElement: Default -> It seems that the distribution is bimodal (mValue = 3.37)

// * Hints *
Outliers
  Benchmarks.UsingLinqFirstElement: Default  -> 1 outlier  was  removed (40.00 ns)
  Benchmarks.UsingLinqLastElement: Default   -> 7 outliers were removed (12.07 us..14.82 us)
  Benchmarks.UsingArrayFirstElement: Default -> 1 outlier  was  removed (8.41 ns)
  Benchmarks.UsingArrayLastElement: Default  -> 3 outliers were removed (3.35 us..3.90 us)
  Benchmarks.UsingLoopFirstElement: Default  -> 8 outliers were removed (5.38 ns..6.90 ns)
  Benchmarks.UsingLoopLastElement: Default   -> 11 outliers were removed, 12 outliers were detected (921.94 ns, 1.22 us..1.53 us)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  1 ns   : 1 Nanosecond (0.000000001 sec)

// ***** BenchmarkRunner: End *****
// ** Remained 0 benchmark(s) to run **
Run time: 00:05:15 (315.69 sec), executed benchmarks: 6

Global total time: 00:05:27 (327.85 sec), executed benchmarks: 6
// * Artifacts cleanup *
```

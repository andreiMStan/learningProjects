```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4529/22H2/2022Update)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
| Method                 | NumberOfElements | Mean      | Error     | StdDev    | Median    |
|----------------------- |----------------- |----------:|----------:|----------:|----------:|
| **With_AutoMapper**        | **10**               |  **2.055 μs** | **0.0314 μs** | **0.0293 μs** |  **2.048 μs** |
| With_Direct_Assignemet | 10               |  1.087 μs | 0.0652 μs | 0.1902 μs |  1.005 μs |
| **With_AutoMapper**        | **100**              | **20.663 μs** | **0.4073 μs** | **0.4182 μs** | **20.598 μs** |
| With_AutoMapper        | 100              | 24.801 μs | 1.0530 μs | 3.0381 μs | 24.401 μs |
| With_Direct_Assignemet | 100              | 11.205 μs | 0.2069 μs | 0.2463 μs | 11.232 μs |
| With_Direct_Assignemet | 100              | 11.288 μs | 0.2161 μs | 0.2402 μs | 11.272 μs |

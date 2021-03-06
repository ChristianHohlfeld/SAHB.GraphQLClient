﻿using System.Reflection;
using BenchmarkDotNet.Running;
using Xunit;

namespace SAHB.GraphQLClient.Tests.Benchmarks
{
    public class Runner
    {
        [Fact(Skip = "Run without any other unit tests")]
        public void RunBenchmarks()
        {
            new BenchmarkSwitcher(typeof(Runner).GetTypeInfo().Assembly).RunAll();
        }
    }
}

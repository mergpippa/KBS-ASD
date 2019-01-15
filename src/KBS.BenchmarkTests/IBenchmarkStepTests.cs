using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KBS.Benchmark.States;
using Xunit;

namespace KBS.BenchmarkTests
{
    public class IBenchmarkStepTests
    {
        private readonly List<System.Reflection.TypeInfo> states;

        public IBenchmarkStepTests()
        {
            states = System.Reflection.Assembly.GetAssembly(typeof(IBenchmarkStep)).DefinedTypes
                   .Where(t => t.Namespace == "KBS.Benchmark.States" && t.IsClass && !t.IsNested).ToList();
        }

        [Fact]
        public void AllStatesShouldExtendIBenchmarkStep()
        {
            states.ForEach(state => Assert.Contains(typeof(IBenchmarkStep), state.ImplementedInterfaces));
        }
    }
}

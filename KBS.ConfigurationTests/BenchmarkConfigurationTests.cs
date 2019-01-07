using System;
using KBS.Configuration;
using Xunit;

namespace KBS.ConfigurationTests
{
    public class BenchmarkConfigurationTests
    {
        [Fact]
        public void Should_GetMessagesCount()
        {
            var value = BenchmarkConfiguration.MessagesCount;

            Assert.Equal(100, value);
            Assert.IsType<int>(value);
        }

        [Fact]
        public void Should_GetFillerSize()
        {
            var value = BenchmarkConfiguration.FillerSize;

            Assert.Equal(default(int), value);
            Assert.IsType<int>(value);
        }

        [Fact]
        public void Should_GetClients()
        {
            var value = BenchmarkConfiguration.Clients;

            Assert.Equal(2, value);
            Assert.IsType<int>(value);
        }

        [Fact]
        public void Should_GetBenchmarkTimeout()
        {
            var value = BenchmarkConfiguration.BenchmarkTimeout;

            Assert.Equal(TimeSpan.FromMinutes(1), value);
            Assert.IsType<TimeSpan>(value);
        }
    }
}

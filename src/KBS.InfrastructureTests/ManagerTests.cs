using System;
using KBS.Infrastructure;
using KBS.Infrastructure.Models;
using Xunit;

namespace KBS.InfrastructureTests
{
    public class ManagerTests
    {
        [Fact]
        public void Should_CreateTestEnvironmentWithGivenConfiguration()
        {
            var endingAtUTC = DateTime.UtcNow.AddHours(1.5);

            var manager = new Manager();
            var configuration = new TestConfiguration
            {
                Name = "myName",
                BatchSize = 10,
                EndingAtUTC = endingAtUTC,
                Frequency = 100,
            };

            var testEnvironment = manager.CreateTestEnvironment(configuration);

            Assert.NotNull(testEnvironment);
            Assert.Equal(endingAtUTC, testEnvironment.Configuration.EndingAtUTC);
        }
    }
}

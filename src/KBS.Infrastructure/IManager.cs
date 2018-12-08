using System.Collections.Generic;
using KBS.Infrastructure.Models;

namespace KBS.Infrastructure
{
    public interface IManager
    {
        TestEnvironment CreateTestEnvironment(TestConfiguration configuration);
        TestEnvironment GetTestEnvironment(string name);
        List<TestEnvironment> GetTestEnvironments();
    }
}
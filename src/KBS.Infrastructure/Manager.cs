using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.TestCases;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        public Task CreateTest(TestCaseConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public Task<TestEnviroment> GetTest(int identifier)
        {
            throw new NotImplementedException();
        }

        public Task<List<TestEnviroment>> GetTests()
        {
            throw new NotImplementedException();
        }
    }
}

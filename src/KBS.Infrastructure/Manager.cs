using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.FauxApplication.Model;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        public Task CreateTest(TestConfiguration configuration)
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

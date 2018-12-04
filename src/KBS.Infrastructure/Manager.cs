using System;
using System.Collections.Generic;
using KBS.FauxApplication;

namespace KBS.Infrastructure
{
    public class Manager : IManager
    {
        public List<TestEnviroment> GetTests()
        {
            return new List<TestEnviroment>();
        }
        
        public TestEnviroment GetTest(int identifier)
        {
            return new TestEnviroment();
         }

        public void CreateTest(ITestConfiguration configuration)
        {
            throw new NotImplementedException();
        }
        
    }
}

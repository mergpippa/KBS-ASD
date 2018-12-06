using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBS.FauxApplication;

namespace KBS.Infrastructure
{
    public interface IManager
    {
        string GetState();

        void StartTest(ITestConfiguration configuration);
    }
}

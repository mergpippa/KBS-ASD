using System;
using KBS.FauxApplication;

namespace KBS.Infrastructure
{
    public interface IManager
    {
        string GetState();

        void StartTest(ITestConfiguration configuration);
    }
}

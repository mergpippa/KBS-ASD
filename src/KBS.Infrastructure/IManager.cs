using System;
namespace KBS.Infrastructure
{
    public interface IManager
    {
        string GetResult();
        void StartTest(Configuration configuration);
    }
}

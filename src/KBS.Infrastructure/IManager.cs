using System;
namespace KBS.Infrastructure
{
    public interface IManager
    {
        string GetState();
        void StartTest(Configuration configuration);
    }
}

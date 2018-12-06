using System;
using System.Threading;
using KBS.Infrastructure.Resources;

namespace KBS.Infrastructure
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int testEnvironmentState;



            Resources.ResourceGroup.CreatingResourceGroup();
            testEnvironmentState = (int) Data.TestEnvironmentState.Initial | (int) Data.TestEnvironmentState.CreatingResourceGroup;
            Console.WriteLine(Convert.ToString(testEnvironmentState, 2));

            if (Convert.ToString(testEnvironmentState, 2).Equals("11"))
            {
                Resources.ResourceGroup.CreatedResourceGroup();
                testEnvironmentState = testEnvironmentState | (int) Data.TestEnvironmentState.CreatedResourceGroup;
                Console.WriteLine(Convert.ToString(testEnvironmentState, 2));
            }

            if(Convert.ToString(testEnvironmentState, 2).Equals("111"))
            {
                Resources.MessageBroker.CreatingMessageBroker();
                testEnvironmentState = (int) Data.TestEnvironmentState.CreatingMessageBroker;
                Console.WriteLine(Convert.ToString(testEnvironmentState, 2));
            }
            
            Console.ReadKey();
        }
    }
}

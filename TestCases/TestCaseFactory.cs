using KBS.TestCases.Exceptions;
using KBS.TestCases.Model;
using KBS.TestCases.TestCases.RequestResponse;
using KBS.TestCases.TestCases.Webshop;

namespace KBS.TestCases
{
    public enum TestCaseType
    {
        // Request response test case
        RequestResponse = 0,

        // Real world test case
        Webshop = 1,
    }

    public static class TestCaseFactory
    {
        public static ITestCase Create(TestCaseType testCaseType)
        {
            switch (testCaseType)
            {
                case TestCaseType.RequestResponse:
                    return new RequestResponseTestCase();

                case TestCaseType.Webshop:
                    return new WebshopTestCase();
            }

            throw new UnknownTestCaseException(testCaseType.ToString());
        }
    }
}

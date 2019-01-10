using KBS.FauxApplication;
using Xunit;

namespace KBS.FauxApplicationTests
{
    public class ProgramTests
    {
        [Fact]
        public void Should_SuccessfullyRunFauxApplicationWithDefaultSettings()
        {
            const string base64JsonString = "e30=";

            Program.Main(new string[] { base64JsonString });
        }
    }
}

using System;
using KBS.Configuration;
using Xunit;

namespace KBS.ConfigurationTests
{
    public class ConfigurationTests
    {
        public ConfigurationTests()
        {
            Environment.SetEnvironmentVariable("myEnvVarString", "myRandomValue");
            Environment.SetEnvironmentVariable("myEnvVarInt", 54125.ToString());

            BaseConfiguration.SetCommandLineArgsConfiguration("{myArg:\"A string\",myOtherArg:\"12345\"}");
        }

        [Fact]
        public void Should_ReturnValueFromEnvironmentVariables()
        {
            var value = BaseConfiguration.GetFromEnvironment<string>("myEnvVarString");

            Assert.Equal("myRandomValue", value);
        }

        [Fact]
        public void Should_ReturnCorrectTypeFromEnvironmentVariables()
        {
            var value = BaseConfiguration.GetFromEnvironment<int>("myEnvVarInt");

            Assert.Equal(54125, value);
        }

        [Fact]
        public void Should_ReturnValueFromCommandLineArguments()
        {
            const string expectedValue = "A string";

            var value = BaseConfiguration.GetFromArguments<string>("myArg");

            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void Should_ReturnConvertValueToCorrectType_When_GettingValueUsingCommandLineArguments()
        {
            const int expectedValue = 12345;

            var value = BaseConfiguration.GetFromArguments("myOtherArg", default(int));

            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void Should_ReturnFallbackValueFromCommandLineArguments_When_ArgumentDoesNotExist()
        {
            const int expectedValue = 99999;

            var value = BaseConfiguration.GetFromArguments("myUndefinedArg", 99999);

            Assert.Equal(expectedValue, value);
        }
    }
}

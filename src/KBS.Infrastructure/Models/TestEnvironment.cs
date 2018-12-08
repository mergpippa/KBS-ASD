using KBS.Infrastructure.Data;

namespace KBS.Infrastructure.Models
{
    public class TestEnvironment
    {
        public TestEnvironmentStatus Status { get; set; }
        public TestConfiguration Configuration;

        public TestEnvironment(TestConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}

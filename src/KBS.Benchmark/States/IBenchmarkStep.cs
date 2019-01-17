using System.Threading.Tasks;

namespace KBS.Benchmark.States
{
    public interface IBenchmarkStep
    {
        Task Next(Benchmark benchmark);
    }
}

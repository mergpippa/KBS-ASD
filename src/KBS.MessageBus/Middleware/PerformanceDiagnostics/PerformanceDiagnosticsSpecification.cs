using System.Collections.Generic;
using System.Linq;
using GreenPipes;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsSpecification<T> :
        IPipeSpecification<T>
        where T : class, PipeContext
    {
        public void Apply(IPipeBuilder<T> builder)
        {
            builder.AddFilter(new PerformanceDiagnosticsFilter<T>());
        }

        public IEnumerable<ValidationResult> Validate()
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}

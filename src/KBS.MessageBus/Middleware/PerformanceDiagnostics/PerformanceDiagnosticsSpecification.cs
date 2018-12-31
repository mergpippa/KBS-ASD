using System.Collections.Generic;
using System.Linq;
using GreenPipes;
using KBS.Telemetry;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsSpecification<T> :
        IPipeSpecification<T>
        where T : class, PipeContext
    {
        private readonly ITelemetryClient TelemetryClient;

        public PerformanceDiagnosticsSpecification(ITelemetryClient telemetryClient)
        {
            TelemetryClient = telemetryClient;
        }

        public void Apply(IPipeBuilder<T> builder)
        {
            builder.AddFilter(new PerformanceDiagnosticsFilter<T>(TelemetryClient));
        }

        public IEnumerable<ValidationResult> Validate()
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}

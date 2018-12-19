using System.Collections.Generic;
using System.Linq;
using GreenPipes;
using Microsoft.ApplicationInsights;

namespace KBS.MessageBus.Middleware.PerformanceDiagnostics
{
    public class PerformanceDiagnosticsSpecification<T> :
        IPipeSpecification<T>
        where T : class, PipeContext
    {
        private readonly TelemetryClient TelemetryClient;

        public PerformanceDiagnosticsSpecification(TelemetryClient telemetryClient)
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

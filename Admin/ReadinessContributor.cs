using System;
using Steeltoe.Management.Endpoint.Health;

namespace QAware.OSS.Admin
{
    public class ReadinessContributor : IHealthContributor
    {
        public string Id { get; } = "readiness";

        public Health Health()
        {
            Health result = new Health();
            result.Details.Add("message", "Ready for BASTA! 2017.");
            result.Status = HealthStatus.UP;

            return result;
        }
    }
}

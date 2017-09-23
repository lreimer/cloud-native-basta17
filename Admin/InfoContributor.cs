using System;
using System.Collections.Generic;
using Steeltoe.Management.Endpoint.Info;

namespace QAware.OSS.Admin
{
    public class InfoContributor : IInfoContributor
    {
        public void Contribute(IInfoBuilder builder)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("conference", "BASTA! 2017");
            result.Add("session", "Cloud-native .NET-Microservices mit Kubernetes.");
            builder.WithInfo(result);
        }
    }
}

using Microsoft.Extensions.Configuration;
using Serilog.Configuration;
using System;

namespace Serilog.Sinks.Grafana.Loki
{
    public class LokiConfigurationReader : ILoggerSinkSettings
    {
        private readonly string _sectionName;

        internal LokiConfigurationReader(string sectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
                throw new ArgumentNullException(nameof(sectionName));

            _sectionName = sectionName;
        }

        public LoggerConfiguration Configure(LoggerSinkConfiguration sinkConfiguration, IConfiguration configuration)
        {
            var configSection = configuration.GetSection(_sectionName);

            var uri = configSection.GetValue<string>("uri");
            var labels = configSection.GetSection("labels").Get<LokiLabel[]>();
            var propertiesAsLabels = configSection.GetSection("propertiesAsLabels").Get<string[]>();

            return sinkConfiguration.GrafanaLoki(uri, labels: labels, propertiesAsLabels: propertiesAsLabels);
        }
    }
}

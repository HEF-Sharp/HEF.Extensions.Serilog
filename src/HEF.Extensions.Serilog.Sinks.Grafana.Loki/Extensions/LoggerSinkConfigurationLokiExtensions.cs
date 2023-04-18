using Serilog.Configuration;
using System;

namespace Serilog.Sinks.Grafana.Loki
{
    public static class LoggerSinkConfigurationLokiExtensions
    {
        public const string DefaultSectionName = "Loki";

        public static LoggerConfiguration GrafanaLoki(this LoggerSinkSettingsConfiguration sinkSettingConfiguration)
            => GrafanaLoki(sinkSettingConfiguration, DefaultSectionName);

        public static LoggerConfiguration GrafanaLoki(this LoggerSinkSettingsConfiguration sinkSettingConfiguration, string sectionName)
        {
            if (sinkSettingConfiguration == null)
                throw new ArgumentNullException(nameof(sinkSettingConfiguration));

            if (string.IsNullOrWhiteSpace(sectionName))
                throw new ArgumentNullException(nameof(sectionName));

            return sinkSettingConfiguration.Settings(new LokiConfigurationReader(sectionName));
        }
    }
}

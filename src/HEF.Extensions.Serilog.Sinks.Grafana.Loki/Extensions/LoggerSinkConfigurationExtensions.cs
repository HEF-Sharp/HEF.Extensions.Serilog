using Microsoft.Extensions.Configuration;
using System;

namespace Serilog.Configuration
{
    public static class LoggerSinkConfigurationExtensions
    {
        public static LoggerSinkSettingsConfiguration ReadFrom(
            this LoggerSinkConfiguration sinkConfiguration, IConfiguration configuration)
        {
            if (sinkConfiguration == null)
                throw new ArgumentNullException(nameof(sinkConfiguration));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            return new LoggerSinkSettingsConfiguration(sinkConfiguration, configuration);
        }
    }
}

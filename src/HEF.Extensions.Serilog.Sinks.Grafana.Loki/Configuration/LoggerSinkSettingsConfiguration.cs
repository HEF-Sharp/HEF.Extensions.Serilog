using Microsoft.Extensions.Configuration;
using System;

namespace Serilog.Configuration
{
    public class LoggerSinkSettingsConfiguration
    {
        private readonly LoggerSinkConfiguration _sinkConfiguration;

        private readonly IConfiguration _configuration;

        internal LoggerSinkSettingsConfiguration(LoggerSinkConfiguration sinkConfiguration, IConfiguration configuration)
        {
            _sinkConfiguration = sinkConfiguration ?? throw new ArgumentNullException(nameof(sinkConfiguration));

            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public LoggerConfiguration Settings(ILoggerSinkSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            return settings.Configure(_sinkConfiguration, _configuration);
        }
    }
}

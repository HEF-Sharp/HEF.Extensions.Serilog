using Microsoft.Extensions.Configuration;

namespace Serilog.Configuration
{
    public interface ILoggerSinkSettings
    {
        LoggerConfiguration Configure(LoggerSinkConfiguration sinkConfiguration, IConfiguration configuration);
    }
}
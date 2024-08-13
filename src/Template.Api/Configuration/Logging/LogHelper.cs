using Serilog.Events;

namespace Template.Api.Configuration.Logging;

public static class LogHelper
{
    public static LogEventLevel ExcludeHealthChecks(HttpContext ctx, double _, Exception? ex)
    {
        if (ex is not null || ctx.Response.StatusCode > 499)
            return LogEventLevel.Error;

        return IsHealthCheckEndpoint(ctx) ? LogEventLevel.Verbose : LogEventLevel.Information;
    }

    private static bool IsHealthCheckEndpoint(HttpContext ctx)
    {
        var endpoint = ctx.GetEndpoint();
        if (endpoint is not null)
        {
            return string.Equals(
                endpoint.DisplayName,
                "Health checks",
                StringComparison.Ordinal);
        }
        
        return false;
    }
}
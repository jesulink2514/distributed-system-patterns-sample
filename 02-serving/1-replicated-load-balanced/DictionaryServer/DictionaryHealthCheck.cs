using DictionaryServer.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DictionaryServer;

public class DictionaryHealthCheck : IHealthCheck
{
    private readonly DictionaryProvider dictionaryProvider;

    public DictionaryHealthCheck(DictionaryProvider dictionaryProvider)
    {
        this.dictionaryProvider = dictionaryProvider;
    }
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (this.dictionaryProvider.IsLoaded)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Data loaded."));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy("Data not loaded yet."));
    }
}
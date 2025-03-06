﻿namespace WorkerService;

public class SecondWorker : BackgroundService
{
    private readonly ILogger<SecondWorker> _logger;

    public SecondWorker(ILogger<SecondWorker> logger)
    {
        _logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("SecondWorker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(2000, stoppingToken);
        }
    }
    
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await base.StopAsync(cancellationToken);
        _logger.LogInformation("SecondWorker stopped.");
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("SecondWorker started.");
        return base.StartAsync(cancellationToken);
    }
}
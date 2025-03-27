namespace WorkerService;

public class TimerService : IHostedService, IDisposable, IAsyncDisposable
{
    private readonly ILogger<TimerService> _logger;
    private Timer _timer;
    private uint _counter;
    
    public TimerService(ILogger<TimerService> logger)
    {
        _logger = logger;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation($"{nameof(TimerService)} running at: {DateTimeOffset.Now}");
        }
        
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("TimerService stopped.");
        }
        
        _timer?.Change(Timeout.Infinite, 0);
        
        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var counter = Interlocked.Increment(ref _counter);
        _logger.LogInformation("TimerService running at: {time}, counter: {counter}", DateTimeOffset.Now, counter);
    }

    public void Dispose()
    {
        _timer.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _timer.DisposeAsync();
    }
}
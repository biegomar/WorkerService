namespace WorkerService;

public class BusinessService : IBusinessService
{
    private readonly ILogger<Worker> _logger;

    public BusinessService(ILogger<Worker> logger)
    {
        _logger = logger;
    }
    
    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation($"{nameof(BusinessService)} running at: {DateTimeOffset.Now}");
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}
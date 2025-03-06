namespace WorkerService;

public interface IBusinessService
{
    Task DoWork(CancellationToken stoppingToken);
}
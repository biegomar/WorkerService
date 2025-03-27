using WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<SecondWorker>();
builder.Services.AddHostedService<TimerService>();

var host = builder.Build();
host.Run();
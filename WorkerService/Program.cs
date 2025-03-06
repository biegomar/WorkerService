using WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<SecondWorker>();

var host = builder.Build();
host.Run();
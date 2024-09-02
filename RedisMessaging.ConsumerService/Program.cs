using RedisMessaging.ConsumerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDbContext<RedisMessaging.DataAccess.EfCoreSqlServer.AppDbContext>();

var host = builder.Build();
host.Run();

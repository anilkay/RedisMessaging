using RedisMessaging.Data.CommonModels;
using RedisMessaging.DataAccess.EfCoreSqlServer;
using RedisMessaging.Library;

namespace RedisMessaging.ConsumerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger,IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ConsumerRedisConnector consumerRedisConnector = new ConsumerRedisConnector("192.168.1.104:16379", "sensor");

            var subscriber = consumerRedisConnector.subscriber;

            using IServiceScope scope = _serviceProvider.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();


            subscriber.Subscribe("sensor",  (ch, msg) =>
            {
                SensorData sensorData = (SensorData)SensorData.FromJson(msg);

               Data.DBModels.SensorData dbSensorData = new Data.DBModels.SensorData
                {
                    BackendWriteTime = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    SensorName = sensorData.SensorName,
                    SensorType = sensorData.SensorType,
                    SensorValue = sensorData.SensorValue,
                };

                context.SensorDatas.Add(dbSensorData);
                context.SaveChanges();


                Console.WriteLine(ch + ": " + msg);
            });

            await Task.Delay(Timeout.Infinite, stoppingToken);

        }
    }
}

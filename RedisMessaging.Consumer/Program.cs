// See https://aka.ms/new-console-template for more information
using RedisMessaging.Data.CommonModels;
using RedisMessaging.Library;
using StackExchange.Redis;
using System.Text.Json;


ConsumerRedisConnector consumerRedisConnector = new ConsumerRedisConnector("192.168.1.104:16379", "sensor");

var subscriber=consumerRedisConnector.subscriber;



subscriber.Subscribe("sensor", (ch, msg) =>
{
    SensorData sensorData=(SensorData)SensorData.FromJson(msg);
    Console.WriteLine(ch + ": " + msg);
});

Console.ReadLine();



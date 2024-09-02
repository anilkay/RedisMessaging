// See https://aka.ms/new-console-template for more information
using RedisMessaging.Data.CommonModels;
using RedisMessaging.Library;
using StackExchange.Redis;
using System.Text.Json;

Console.WriteLine("Hello, World!");

PublisherRedisConnector publisherRedisConnector = new PublisherRedisConnector("192.168.1.104:16379","sensor");

SensorData sensorData = new SensorData
{
    SensorName = "Temperature",
    SensorType="Digital",
    SensorValue=22
};


await publisherRedisConnector.PublishMessage(sensorData);
Console.ReadLine();




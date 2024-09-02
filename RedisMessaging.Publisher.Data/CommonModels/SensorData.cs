using RedisMessaging.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisMessaging.Data.CommonModels
{
    public class SensorData : IJsonSerializable
    {
        public string SensorName { get; set; }
        public string SensorType { get; set; }
        public double SensorValue { get; set; }

        public static object FromJson(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException();
            }
            return JsonSerializer.Deserialize<SensorData>(json);
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

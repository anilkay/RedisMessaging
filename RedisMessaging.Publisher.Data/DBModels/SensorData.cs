using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMessaging.Data.DBModels
{
    public class SensorData
    {
        public Guid Id { get; set; }

        public string SensorName { get; set; }
        public string SensorType { get; set; }
        public double SensorValue { get; set; }

        public DateTime BackendWriteTime { get; set; }

    }
}

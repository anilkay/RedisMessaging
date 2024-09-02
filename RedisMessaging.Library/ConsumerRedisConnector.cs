using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMessaging.Library
{
    public  class ConsumerRedisConnector : RedisConnector
    {
        public readonly ISubscriber subscriber;
        public ConsumerRedisConnector(string connectionString, string channelName, int selectedDbNumber = 1) : base(connectionString, selectedDbNumber)
        {
            subscriber= _multiplexer.GetSubscriber();
        }
    }
}

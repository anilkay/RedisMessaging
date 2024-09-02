using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMessaging.Library
{
    public class PublisherRedisConnector : RedisConnector
    {
        private readonly string _channelName;

        public PublisherRedisConnector(string connectionString, string channelName, int selectedDbNumber = 1) : base(connectionString, selectedDbNumber)
        {
            _channelName = channelName;
        }

        public async  Task<bool> PublishMessage(IJsonSerializable message)
        {
            long numberOfClientReceivedMessage=await  _selectedDb.PublishAsync(_channelName, message.GetJson());
            return numberOfClientReceivedMessage > 0;
        }

    }
}

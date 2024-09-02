using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMessaging.Library
{
    public  class RedisConnector
    {
        protected readonly IDatabase _selectedDb;
        protected readonly ConnectionMultiplexer _multiplexer;

        public RedisConnector(string connectionString,int selectedDbNumber=1) 
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(connectionString);
            _selectedDb = connection.GetDatabase(selectedDbNumber);
            _multiplexer = connection;
        }
    }
}

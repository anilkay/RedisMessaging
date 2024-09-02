using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMessaging.Library
{
    public  interface IJsonSerializable
    {
        public string GetJson();
        public static abstract object FromJson(string json);
    }
}

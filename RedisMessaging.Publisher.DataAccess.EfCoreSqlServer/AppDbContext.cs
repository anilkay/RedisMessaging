using Microsoft.EntityFrameworkCore;
using RedisMessaging.Data.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisMessaging.DataAccess.EfCoreSqlServer
{
    public  class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Sensor;Integrated Security=True;TrustServerCertificate=True");

        }

        public DbSet<Data.DBModels.SensorData> SensorDatas { get; set; }
    }
}

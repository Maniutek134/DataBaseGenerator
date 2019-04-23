using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCreator
{
    public class TestTempContext : DbContext
    {
        public DbSet<DBWeatherCondition> WeatherCondition { get; set; }
        public DbSet<DBTrafficIntensity> Intensity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DELKC8L;Database=DataBaseGdynia;Trusted_Connection=True;");
        }
    }

    public class DBWeatherCondition
    {  
        public int id { get; set; }
        public float temperature { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
        public int visibility { get; set; }
        public float windSpeed { get; set; }
        public float windDeg { get; set; }
        public DateTime measureTime { get; set; }
        public ICollection<DBTrafficIntensity> dbTrafficIntensity { get; set; }
    }

    public class DBTrafficIntensity
    {
        public int id { get; set; }
        public int roadSegmentId { get; set; }
        public float intenstiy { get; set; }
        public DateTime measureTime { get; set; }
        public DBWeatherCondition dbTemperature { get; set; }
    }
}

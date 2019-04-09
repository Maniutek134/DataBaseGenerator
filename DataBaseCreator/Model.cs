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
        public DbSet<DBTemperature> Temperature { get; set; }
        public DbSet<DBTrafficIntensity> Intensity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DELKC8L;Database=DataBaseGdynia;Trusted_Connection=True;");
        }
    }

    public class DBTemperature
    {  
        public int id { get; set; }
        public float airTemperature { get; set; }
        public float surfaceTemperature { get; set; }
        public float chemicalConcentration { get; set; }
        public float visibility { get; set; }
        public float waterIceThickness { get; set; }
        public float windSpeed { get; set; }
        public DateTime measureTime { get; set; } 

        public ICollection<DBTrafficIntensity> DBTrafficIntensity { get; set; }
    }

    public class DBTrafficIntensity
    {
        public int id { get; set; }
        public int roadSegmentId { get; set; }
        public float intenstiy { get; set; }
        public DateTime measureTime { get; set; }
        public int TestTempID { get; set; }

        public DBTemperature DBTemperature { get; set; }
    }
}

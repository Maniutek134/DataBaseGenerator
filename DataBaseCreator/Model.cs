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
        public DbSet<TestTemp> Temp { get; set; }
        public DbSet<TrafficIntensity> Intensity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QUBV4T1;Database=TemperatureTest;Trusted_Connection=True;");
        }
    }

    public class TestTemp
    {  
        public int id { get; set; }
        public float airTemperature { get; set; }
        public float surfaceTemperature { get; set; }
        public float chemicalConcentration { get; set; }
        public float visibility { get; set; }
        public float waterIceThickness { get; set; }
        public float windSpeed { get; set; }
        public DateTime measureTime { get; set; } 

        public ICollection<TrafficIntensity> TrafficIntensity { get; set; }
    }

    public class TrafficIntensity
    {
        public int id { get; set; }
        public int roadSegmentId { get; set; }
        public float intenstiy { get; set; }
        public DateTime measureTime { get; set; }
       // [ForeignKey("TestTemp")]
        public int TestTempID { get; set; }

        public  TestTemp TestTemp { get; set; }
    }
}

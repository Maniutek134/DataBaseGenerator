using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCreator
{
    class WeatherConditon
    {
        public float temp { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
        public int visibility { get; set; }
        public float windSpeed { get; set; }
        public float windDeg { get; set; }
        public DateTime measureTime { get; set; }
    }
    class APIWeatherConditon
    {
        public Main main;
        public int visibility;
        public Wind wind;

    }
    class Main {
        public float temp;
        public float pressure;
        public float humidity;
    }
    class Wind {
        public float speed;
        public float deg;
    }
}

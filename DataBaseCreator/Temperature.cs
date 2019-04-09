using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCreator
{
    class Temperature
    {
        public float airTemperature { get; set; }
        public float surfaceTemperature { get; set; }
        public float chemicalConcentration { get; set; }
        public float visibility { get; set; }
        public float waterIceThickness { get; set; }
        public float windSpeed { get; set; }
        public DateTime measureTime { get; set; }
    }

    class APITemp : Temperature
    {
        public int id { get; set; }
        public int weatherStationId { get; set; }
        public float strenghtWind { get; set; }
        public float windDirection { get; set; }
        public float dewPoint { get; set; }

    }
}


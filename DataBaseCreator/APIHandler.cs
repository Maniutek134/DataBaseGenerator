using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataBaseCreator
{


    public class Temp
    {
        public float airTemperature { get; set; }
        public float surfaceTemperature { get; set; }
        public float chemicalConcentration { get; set; }
        public float visibility { get; set; }
        public float waterIceThickness { get; set; }
        public float windSpeed { get; set; }
        public DateTime measureTime { get; set; }
    }

    public class APITemp : Temp
    {
        public int id { get; set; }
        public int weatherStationId { get; set; }
        public float strenghtWind { get; set; }
        public float windDirection { get; set; }
        public float dewPoint { get; set; }

    }

    class APIHandler
    {
        static HttpClient client = new HttpClient();

        public async Task<List<APITemp>> getCurrentAPITemps()
        {
            var temps = new List<APITemp>();
            string json;

            HttpResponseMessage response = await client.GetAsync(
                "http://api.zdiz.gdynia.pl/ri/rest/weather_stations_data");
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                temps = JsonConvert.DeserializeObject<List<APITemp>>(json);

            }
            return temps;
        }

        public async Task<Temp> getCurrentTemp()
        {
            Temp temp = new Temp();

            float airTemperature = 0;
            float surfaceTemperature = 0;
            float chemicalConcentration = 0;
            float visibility = 0;
            float waterIceThickness = 0;
            float windSpeed = 0;
            DateTime measureTime = DateTime.Now;

            List<APITemp> temps = await getCurrentAPITemps();

            foreach (Temp item in temps)
            {
                airTemperature += item.airTemperature;
                surfaceTemperature += item.surfaceTemperature;
                chemicalConcentration += item.chemicalConcentration;
                visibility += item.visibility;
                waterIceThickness += item.waterIceThickness;
                windSpeed += item.windSpeed;
            }


            temp.airTemperature = airTemperature / temps.Count;
            temp.surfaceTemperature = surfaceTemperature / temps.Count;
            temp.chemicalConcentration = chemicalConcentration / temps.Count;
            temp.visibility = visibility / temps.Count;
            temp.waterIceThickness = waterIceThickness / temps.Count;
            temp.windSpeed = windSpeed / temps.Count;
            temp.measureTime = measureTime;

            //Console.WriteLine(temp.airTemperature);

            return temp;
        }
    }
}



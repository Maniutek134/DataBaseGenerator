using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataBaseCreator
{

    class TemperatureCollector
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

        public async Task<Temperature> getCurrentTemp()
        {
            Temperature temperature = new Temperature();

            float airTemperature = 0;
            float surfaceTemperature = 0;
            float chemicalConcentration = 0;
            float visibility = 0;
            float waterIceThickness = 0;
            float windSpeed = 0;
            DateTime measureTime = DateTime.Now;

            List<APITemp> temps = await getCurrentAPITemps();

            foreach (Temperature item in temps)
            {
                airTemperature += item.airTemperature;
                surfaceTemperature += item.surfaceTemperature;
                chemicalConcentration += item.chemicalConcentration;
                visibility += item.visibility;
                waterIceThickness += item.waterIceThickness;
                windSpeed += item.windSpeed;
            }


            temperature.airTemperature = airTemperature / temps.Count;
            temperature.surfaceTemperature = surfaceTemperature / temps.Count;
            temperature.chemicalConcentration = chemicalConcentration / temps.Count;
            temperature.visibility = visibility / temps.Count;
            temperature.waterIceThickness = waterIceThickness / temps.Count;
            temperature.windSpeed = windSpeed / temps.Count;
            temperature.measureTime = measureTime;

            //Console.WriteLine(temp.airTemperature);

            return temperature;
        }
    }
}



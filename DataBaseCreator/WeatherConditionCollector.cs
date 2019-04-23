using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataBaseCreator
{

    class WeatherConditionCollector
    {
        static HttpClient client = new HttpClient();

        public async Task<APIWeatherConditon> getCurrentAPIWeatherCondition()
        {
            var apiWeatherCondition = new APIWeatherConditon();
            string json;

            HttpResponseMessage response = await client.GetAsync(
                "http://api.openweathermap.org/data/2.5/weather?id=3099424&appid=91750e79f1dbe133071608ad955ec17c&units=metric");
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                apiWeatherCondition = JsonConvert.DeserializeObject<APIWeatherConditon>(json);

            }
            return apiWeatherCondition;
        }

        public async Task<WeatherConditon> getCurrentWeatherCondition()
        {
            WeatherConditon weatherCondition = new WeatherConditon();
            DateTime measureTime = DateTime.Now;

            APIWeatherConditon apiWeatherCondition = await getCurrentAPIWeatherCondition();
            weatherCondition.temp = apiWeatherCondition.main.temp;
            weatherCondition.pressure = apiWeatherCondition.main.pressure;
            weatherCondition.humidity = apiWeatherCondition.main.humidity;
            weatherCondition.visibility = apiWeatherCondition.visibility;
            weatherCondition.windSpeed = apiWeatherCondition.wind.speed;
            weatherCondition.windDeg = apiWeatherCondition.wind.deg;
            weatherCondition.measureTime = measureTime;
            //foreach (Temperature item in temps)
            //{
            //    airTemperature += item.airTemperature;
            //    surfaceTemperature += item.surfaceTemperature;
            //    chemicalConcentration += item.chemicalConcentration;
            //    visibility += item.visibility;
            //    waterIceThickness += item.waterIceThickness;
            //    windSpeed += item.windSpeed;
            //}


            //temperature.airTemperature = airTemperature / temps.Count;
            //temperature.surfaceTemperature = surfaceTemperature / temps.Count;
            //temperature.chemicalConcentration = chemicalConcentration / temps.Count;
            //temperature.visibility = visibility / temps.Count;
            //temperature.waterIceThickness = waterIceThickness / temps.Count;
            //temperature.windSpeed = windSpeed / temps.Count;
            //temperature.measureTime = measureTime;

            //Console.WriteLine(temp.airTemperature);

            return weatherCondition;
        }
    }
}



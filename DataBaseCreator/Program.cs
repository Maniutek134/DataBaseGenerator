using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCreator
{
    class Program
    {
        async static Task Main(string[] args)
        {
            //for(int i=0; i<6; i++)
            //{
            //    await RunAsync();

            //    System.Threading.Thread.Sleep(300000);
            //}

            
            while (DateTime.Now.Day <= 27) {
                await RunAsync();

                System.Threading.Thread.Sleep(300000);
           }
             
        }

        static async Task RunAsync()
        {
            using (var db = new TestTempContext())
            {
                WeatherConditionCollector weatherConditionCollector = new WeatherConditionCollector();
                WeatherConditon wetherCondition = await weatherConditionCollector.getCurrentWeatherCondition();

                var dbEntityWeatherCondition = new DBWeatherCondition
                {
                    temperature = wetherCondition.temp,
                    pressure = wetherCondition.pressure,
                    humidity = wetherCondition.humidity,
                    visibility = wetherCondition.visibility,
                    windSpeed = wetherCondition.windSpeed,
                    windDeg = wetherCondition.windDeg,
                    measureTime = wetherCondition.measureTime

                };

                db.WeatherCondition.Add(dbEntityWeatherCondition);

                IntensityCollector intensityCollector = new IntensityCollector();
                List<Traffic> traffics = await intensityCollector.getCurrentTraffic();


                foreach (Traffic traffic in traffics)
                {
                    db.Intensity.Add(new DBTrafficIntensity
                    {
                        roadSegmentId = traffic.roadSegmentId,
                        intenstiy = traffic.intensity,
                        measureTime = traffic.measureTime,
                        dbTemperature = dbEntityWeatherCondition
                    });

                }

                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

            }


        }
    }
}

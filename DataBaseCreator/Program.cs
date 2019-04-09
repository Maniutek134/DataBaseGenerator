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
            for(int i=0; i<6; i++)
            {
                await RunAsync();

                System.Threading.Thread.Sleep(10000);
            }
             
        }

        static async Task RunAsync()
        {
            using (var db = new TestTempContext())
            {
                TemperatureCollector temperatureCollector = new TemperatureCollector();
                Temperature temp = await temperatureCollector.getCurrentTemp();

                var dbEntityTemp = new DBTemperature
                {
                    airTemperature = temp.airTemperature,
                    surfaceTemperature = temp.surfaceTemperature,
                    chemicalConcentration = temp.chemicalConcentration,
                    visibility = temp.visibility,
                    waterIceThickness = temp.waterIceThickness,
                    windSpeed = temp.windSpeed,
                    measureTime = temp.measureTime

                };

                db.Temperature.Add(dbEntityTemp);

                IntensityCollector intensityCollector = new IntensityCollector();
                List<Traffic> traffics = await intensityCollector.getCurrentTraffic();


                foreach (Traffic traffic in traffics)
                {
                    db.Intensity.Add(new DBTrafficIntensity
                    {
                        roadSegmentId = traffic.roadSegmentId,
                        intenstiy = traffic.intensity,
                        measureTime = traffic.measureTime,
                        DBTemperature = dbEntityTemp
                    });
                    
                }

                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);



            }


        }
    }
}

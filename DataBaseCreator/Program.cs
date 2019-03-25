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

                System.Threading.Thread.Sleep(600000);
            }
             
        }

        static async Task RunAsync()
        {
            using (var db = new TestTempContext())
            {
                APIHandler apiHandler = new APIHandler();
                Temp temp = await apiHandler.getCurrentTemp();

                db.Temp.Add(new TestTemp
                {
                    //id = 1,
                    airTemperature = temp.airTemperature,
                    surfaceTemperature = temp.surfaceTemperature,
                    chemicalConcentration =temp.chemicalConcentration,
                    visibility = temp.visibility,
                    waterIceThickness = temp.waterIceThickness,
                    windSpeed = temp.windSpeed,
                    measureTime = temp.measureTime

                });


                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
            }


        }
    }
}

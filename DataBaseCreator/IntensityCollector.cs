using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataBaseCreator
{
    class IntensityCollector
    {
        static HttpClient client = new HttpClient();

        public async Task<List<FullTraffic>> getCurrentTrafficStats()
        {
            var temps = new List<FullTraffic>();
            string json;

            HttpResponseMessage response = await client.GetAsync(
                "http://api.zdiz.gdynia.pl/ri/rest/traffic_intensities");
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                temps = JsonConvert.DeserializeObject<List<FullTraffic>>(json);

            }
            return temps;
        }

        public async Task<List<Traffic>> getCurrentTemp()
        {
            var tempTraffic = new List<FullTraffic>();
            var traffic = new List<Traffic>();
            DateTime measureTime = DateTime.Now;

            List<FullTraffic> allIntensity = await getCurrentTrafficStats();

            tempTraffic = allIntensity.GetRange(0, 10);

            foreach(FullTraffic fullTraffic in tempTraffic)
            {
                var traf = new Traffic();
                traf.roadSegmentId = fullTraffic.roadSegmentId;
                traf.intensity = fullTraffic.intensity;
                traf.measureTime = measureTime;
                traffic.Add(traf);
            }

            //Console.WriteLine(temp.airTemperature);

            return traffic;
        }
    }


}

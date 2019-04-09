using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCreator
{
    class Traffic
    {
        public int roadSegmentId { set; get; }
        public float intensity { set; get; }
        public DateTime measureTime { set; get; }
    }

    class FullTraffic : Traffic
    {
        public int eventId { set; get; }

    }
}

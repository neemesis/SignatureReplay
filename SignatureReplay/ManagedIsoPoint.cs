using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureReplay
{
    [Serializable]
    public class ManagedIsoPoint
    {
        public long time { get; set; }  // in ticks
        public int pressure { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
}

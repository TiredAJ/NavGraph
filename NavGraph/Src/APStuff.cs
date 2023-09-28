using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavGraph.Src
{
    public class NetGraph : Graph<APNode>
    {
        public NetGraph() : base()
        {
        }

        public override void Deserialise(Stream _InputStream)
        {
            throw new NotImplementedException();
        }

        public override int NumberOfConnections(int _UID)
        {
            throw new NotImplementedException();
        }
    }

    public class APNode
    {
        public int UID { get; internal set; }
        public string BSSID { get; set; }
        public string SSID { get; set; }
        public Int16 ApproxDistance { get; set; }
    }

    public interface IAPInfo
    {
        public List<int> RelevantNodes { get; internal set; }
    }
}

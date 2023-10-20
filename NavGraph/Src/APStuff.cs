﻿using NavGraphTools.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NavGraphTools.Src
{
    public class NetGraph : Graph<APNode>
    {
        public NetGraph() : base()
        {
        }

        public override void Deserialise(Stream _InputStream)
        {
            using (StreamReader Reader = new StreamReader(_InputStream))
            { Nodes = JsonSerializer.Deserialize<Dictionary<int, APNode>>(Reader.ReadToEnd()); }
        }

        public override int NumberOfConnections(int _UID)
        {
            throw new NotImplementedException();
        }
    }

    [JsonSerializable(typeof(APNode))]
    public class APNode
    {
        [JsonInclude]
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

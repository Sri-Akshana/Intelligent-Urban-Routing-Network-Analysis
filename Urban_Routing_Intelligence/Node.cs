using System;
using System.Collections.Generic;
using System.Text;

namespace Urban_Routing_Intelligence
{
    public class Node
    {
        public string NodeID { get; set; }
        public string LocationName { get; set; }
        public string Area { get; set; }
        public string NodeType { get; set; }

        public Node(string nodeID, string locationName, string area, string nodeType)
        {
            NodeID = nodeID;
            LocationName = locationName;
            Area = area;
            NodeType = nodeType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Urban_Routing_Intelligence
{
    public class Edge
    {
        public string EdgeID { get; set; }
        public string FromNode { get; set; }
        public string ToNode { get; set; }
        public double DistanceKm { get; set; }
        public double TravelTimeMinutes { get; set; }
        public double SpeedLimitKmh { get; set; }
        public string RoadType { get; set; }
        public string Congestion { get; set; }
        public string RoadName { get; set; }

        public Edge(
            string edgeID,
            string fromNode,
            string toNode,
            double distanceKm,
            double travelTimeMinutes,
            double speedLimitKmh,
            string roadType,
            string congestion,
            string roadName)
        {
            EdgeID = edgeID;
            FromNode = fromNode;
            ToNode = toNode;
            DistanceKm = distanceKm;
            TravelTimeMinutes = travelTimeMinutes;
            SpeedLimitKmh = speedLimitKmh;
            RoadType = roadType;
            Congestion = congestion;
            RoadName = roadName;
        }
    }


}

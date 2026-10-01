using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class BottleneckAnalysis
{
    public void AnalyseBottlenecks(Graph graph)
    {
        Console.WriteLine();
        Console.WriteLine("Bottleneck / Critical Node Analysis");
        Console.WriteLine("------------------------------------");

        Dictionary<string, int> incomingConnections =
            new Dictionary<string, int>();

        Dictionary<string, int> outgoingConnections =
            new Dictionary<string, int>();

        foreach (string nodeID in graph.Nodes.Keys)
        {
            incomingConnections[nodeID] = 0;
            outgoingConnections[nodeID] = 0;
        }

        foreach (var item in graph.AdjacencyList)
        {
            string fromNode = item.Key;

            foreach (Edge edge in item.Value)
            {
                outgoingConnections[fromNode]++;

                if (incomingConnections.ContainsKey(edge.ToNode))
                {
                    incomingConnections[edge.ToNode]++;
                }
            }
        }

        string highestNode = "";
        int highestConnections = -1;

        foreach (string nodeID in graph.Nodes.Keys)
        {
            int totalConnections =
                incomingConnections[nodeID] +
                outgoingConnections[nodeID];

            if (totalConnections > highestConnections)
            {
                highestConnections = totalConnections;
                highestNode = nodeID;
            }
        }

        Console.WriteLine(
            "Potential Critical Node: " +
            highestNode);

        Console.WriteLine(
            "Incoming Connections: " +
            incomingConnections[highestNode]);

        Console.WriteLine(
            "Outgoing Connections: " +
            outgoingConnections[highestNode]);

        Console.WriteLine(
            "Total Connections: " +
            highestConnections);

        Console.WriteLine();
        Console.WriteLine(
            "Top 5 Nodes by Number of Connections:");

        List<string> nodes =
            new List<string>(graph.Nodes.Keys);

        nodes.Sort(
            delegate (string nodeA, string nodeB)
            {
                int connectionsA =
                    incomingConnections[nodeA] +
                    outgoingConnections[nodeA];

                int connectionsB =
                    incomingConnections[nodeB] +
                    outgoingConnections[nodeB];

                return connectionsB.CompareTo(connectionsA);
            });

        int numberToDisplay =
            Math.Min(5, nodes.Count);

        for (int i = 0; i < numberToDisplay; i++)
        {
            string nodeID = nodes[i];

            int totalConnections =
                incomingConnections[nodeID] +
                outgoingConnections[nodeID];

            Console.WriteLine(
                (i + 1) +
                ". " +
                nodeID +
                " - " +
                totalConnections +
                " connections");
        }

        Console.WriteLine();
        Console.WriteLine(
            "Note: A node with many connections is identified as a potential bottleneck or critical point.");
    }
}
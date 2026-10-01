using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class Graph
{
    public Dictionary<string, Node> Nodes { get; set; }

    public Dictionary<string, List<Edge>> AdjacencyList { get; set; }

    public Graph()
    {
        Nodes = new Dictionary<string, Node>();
        AdjacencyList = new Dictionary<string, List<Edge>>();
    }

    public void AddNode(Node node)
    {
        if (!Nodes.ContainsKey(node.NodeID))
        {
            Nodes.Add(node.NodeID, node);
            AdjacencyList.Add(node.NodeID, new List<Edge>());
        }
    }

    public void AddEdge(Edge edge)
    {
        if (!Nodes.ContainsKey(edge.FromNode))
        {
            Console.WriteLine("From node not found: " + edge.FromNode);
            return;
        }

        if (!Nodes.ContainsKey(edge.ToNode))
        {
            Console.WriteLine("To node not found: " + edge.ToNode);
            return;
        }

        AdjacencyList[edge.FromNode].Add(edge);
    }

    public List<Edge> GetNeighbours(string nodeID)
    {
        if (AdjacencyList.ContainsKey(nodeID))
        {
            return AdjacencyList[nodeID];
        }

        return new List<Edge>();
    }
}

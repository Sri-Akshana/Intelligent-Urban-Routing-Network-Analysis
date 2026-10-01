using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class ConnectivityAnalysis
{
    public void AnalyseConnectivity(Graph graph)
    {
        Console.WriteLine();
        Console.WriteLine("Connectivity Analysis");
        Console.WriteLine("---------------------");

        if (graph.Nodes.Count == 0)
        {
            Console.WriteLine("The graph contains no nodes.");
            return;
        }

        string startNode = "";

        foreach (string nodeID in graph.Nodes.Keys)
        {
            startNode = nodeID;
            break;
        }

        BFS bfs = new BFS();

        List<string> visitedNodes =
            bfs.Search(graph, startNode);

        Console.WriteLine(
            "Starting Node: " + startNode);

        Console.WriteLine(
            "Total Nodes: " + graph.Nodes.Count);

        Console.WriteLine(
            "Reachable Nodes: " + visitedNodes.Count);

        if (visitedNodes.Count == graph.Nodes.Count)
        {
            Console.WriteLine(
                "Connectivity Result: All nodes are reachable from the starting node.");
        }
        else
        {
            Console.WriteLine(
                "Connectivity Result: The graph contains unreachable nodes.");

            Console.WriteLine();
            Console.WriteLine("Unreachable Nodes:");

            foreach (string nodeID in graph.Nodes.Keys)
            {
                if (!visitedNodes.Contains(nodeID))
                {
                    Console.Write(nodeID + " ");
                }
            }

            Console.WriteLine();
        }
    }
}

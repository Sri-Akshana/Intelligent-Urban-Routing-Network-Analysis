using System;
using System.Diagnostics;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class PerformanceAnalysis
{
    public void MeasurePerformance(
        Graph graph,
        string startNode)
    {
        Console.WriteLine();
        Console.WriteLine("Performance / Scalability Analysis");
        Console.WriteLine("-----------------------------------");

        Console.WriteLine(
            "Dataset Size: " +
            graph.Nodes.Count +
            " Nodes");

        int edgeCount = 0;

        foreach (List<Edge> edges in graph.AdjacencyList.Values)
        {
            edgeCount += edges.Count;
        }

        Console.WriteLine(
            "Number of Edges: " +
            edgeCount);

        // -------------------------
        // BFS Performance
        // -------------------------

        BFS bfs = new BFS();

        Stopwatch bfsTimer =
            Stopwatch.StartNew();

        List<string> bfsResult =
            bfs.Search(graph, startNode);

        bfsTimer.Stop();

        Console.WriteLine();
        Console.WriteLine(
            "BFS Time: " +
            bfsTimer.Elapsed.TotalMilliseconds.ToString("F4") +
            " ms");

        Console.WriteLine(
            "BFS Nodes Visited: " +
            bfsResult.Count);

        // -------------------------
        // DFS Performance
        // -------------------------

        DFS dfs = new DFS();

        Stopwatch dfsTimer =
            Stopwatch.StartNew();

        List<string> dfsResult =
            dfs.Search(graph, startNode);

        dfsTimer.Stop();

        Console.WriteLine(
            "DFS Time: " +
            dfsTimer.Elapsed.TotalMilliseconds.ToString("F4") +
            " ms");

        Console.WriteLine(
            "DFS Nodes Visited: " +
            dfsResult.Count);

        // -------------------------
        // Dijkstra Performance
        // -------------------------

        Dijkstra dijkstra =
            new Dijkstra();

        string endNode = "";

        foreach (string nodeID in graph.Nodes.Keys)
        {
            endNode = nodeID;
        }

        Stopwatch dijkstraTimer =
            Stopwatch.StartNew();

        dijkstra.FindShortestPath(
            graph,
            startNode,
            endNode
        );

        dijkstraTimer.Stop();

        Console.WriteLine(
            "Dijkstra Time: " +
            dijkstraTimer.Elapsed.TotalMilliseconds.ToString("F4") +
            " ms");

        // -------------------------
        // Summary
        // -------------------------

        Console.WriteLine();
        Console.WriteLine("Performance Summary:");

        Console.WriteLine(
            "BFS: " +
            bfsTimer.Elapsed.TotalMilliseconds.ToString("F4") +
            " ms");

        Console.WriteLine(
            "DFS: " +
            dfsTimer.Elapsed.TotalMilliseconds.ToString("F4") +
            " ms");

        Console.WriteLine(
            "Dijkstra: " +
            dijkstraTimer.Elapsed.TotalMilliseconds.ToString("F4") +
            " ms");
    }
}